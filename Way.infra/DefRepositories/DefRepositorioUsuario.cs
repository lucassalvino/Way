using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Way.Domain;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Arguments.Respost.Views;
using Way.Domain.Entities;
using Way.Domain.Interfaces.Repositories;
using Way.Domain.Resources;
using Way.Domain.Services;
using Way.infra.ManagerTables;
using Way.infra.Mapeadores;
using Way.infra.Persistencia;
using Way.infra.Utilitarios;

namespace Way.infra.DefRepositories
{
    public class DefRepositorioUsuario : BaseManagerTable<MapUsuario>, IUsuarioRepositorio
    {
        public DefRepositorioUsuario(WayContext context) : base(context)
        {
            RealizaSet = true;
        }

        public LoginUsuarioRespost AutenticaUsuario(LoginUsuarioRequest Usuario)
        {
            LoginUsuarioRespost ret = new LoginUsuarioRespost()
            {
                SessaoId = Guid.Empty.ToString()
            };

            try
            {
                MapUsuario result = (from usuario in DBContext.Usuarios
                                           where usuario.Ativo == true &&
                                           Usuario.Login.Equals(usuario.Login) &&
                                           usuario.Senha.ToUpper().Equals(Util.HashSHA256(Usuario.Senha))
                                           select usuario).FirstOrDefault();
                if (result == null)
                {
                    ret.Menssagem = MensagensEntidades.LoginIncorreto;
                }
                else
                {
                    MapSessaoUsuario Sessao = new MapSessaoUsuario()
                    {
                        DataInicioSessao = DateTime.Now,
                        Ativo = true,
                        UsuarioID = result.Id,
                        Id = Guid.NewGuid()
                    };

                    this.InativaSessoesUsuario(result.Id);

                    DBContext.SessaoUsuario.Add(Sessao);
                    DBContext.SaveChanges();

                    ret.SessaoId = Sessao.Id.ToString();
                }
            }
            catch (Exception Erro)
            {
                ret.ErrorMessage = MensagensEntidades.ErroInesperado;
                Task.Run(()=> { new LogService().AddLog(Erro.Message); });
            }

            return ret;
        }

        public UsuarioRespost CadastraUsuario(UsuarioRequest UsuarioValue)
        {
            if (UsuarioValue.IdUsuario != Guid.Empty)
                return EditaUsuario(UsuarioValue.IdUsuario, UsuarioValue);

            DadosSessao StatusSessao = DefRepositorioUsuario.StatusSessao(UsuarioValue.IdSessao, this.DBContext);

            if (StatusSessao == null) return new UsuarioRespost() { IdSessao = Guid.Empty };

            Usuario UsuarioAdiciona = (Usuario)UsuarioValue;
            UsuarioAdiciona.InstituicaoID = StatusSessao.Usuario.InstituicaoID;
            UsuarioAdiciona.VerificaSenha = true;

            UsuarioRespost Retorn = new UsuarioRespost() { IdSessao = UsuarioValue.IdSessao };

            UsuarioAdiciona.ExecuteValidationRoutine();
            if (UsuarioAdiciona.ItsValid && (UsuarioValue.Senha.Equals(UsuarioValue.ReSenha)))
            {
                MapUsuario UsuarioSalvo = (MapUsuario)UsuarioAdiciona;
                DBContext.Usuarios.Add(UsuarioSalvo);
                DBContext.SaveChanges();
                Retorn.Menssagem = MensagensEntidades.UsuarioSalvo;
                Retorn.IdCadasto = UsuarioSalvo.Id;
                Retorn.DefineSucess();
            }
            else
            {
                Retorn.ErrorMessage = String.Format(MensagensEntidades.ErroAoRealizarOperacao, Operacaoes.CadastroUsuario);
                Retorn.Alertas = UsuarioAdiciona.Notifications;
                Retorn.DefineErro();
            }
            return Retorn;
        }

        public UsuarioRespost EditaUsuario(Guid IdUsuario, UsuarioRequest Usuario)
        {
            DadosSessao StatusSessao = DefRepositorioUsuario.StatusSessao(Usuario.IdSessao, this.DBContext);
            if (StatusSessao == null) return new UsuarioRespost() { IdSessao = Guid.Empty };

            MapUsuario BaseUsuario = DBContext.Usuarios.Find(IdUsuario);
            if (BaseUsuario == null) return null;
            Usuario UC = (Usuario)Usuario;
            UsuarioRespost retorno = new UsuarioRespost() { };

            //se a senha for igual o id do usuario não sera editada a senha
            UC.VerificaSenha = !(Usuario.Senha.ToUpper().Equals(IdUsuario.ToString().ToUpper()));
            UC.ExecuteValidationRoutine();
            if (UC.ItsValid)
            {
                #region Edita Usuario
                if (!BaseUsuario.Nome.Equals(UC.Nome))
                {
                    BaseUsuario.Nome = UC.Nome;
                }
                if (!BaseUsuario.Email.Equals(UC.Email))
                {
                    BaseUsuario.Email = UC.Email;
                }
                if ( BaseUsuario.Ativo != UC.Ativo)
                {
                    BaseUsuario.Ativo = UC.Ativo;
                }
                if (!UC.Senha.ToUpper().Equals(BaseUsuario.Id.ToString().ToUpper()) && !BaseUsuario.Senha.Equals(Util.HashSHA256(UC.Senha)))
                {
                    BaseUsuario.Senha = Util.HashSHA256(UC.Senha);
                }
                if (!BaseUsuario.Login.Equals(UC.Login))
                {
                    BaseUsuario.Login = UC.Login;
                }
                DBContext.SaveChanges();
                #endregion

                retorno.Menssagem = MensagensEntidades.UsuarioSalvo;
                retorno.IdCadasto = Usuario.IdUsuario;
                retorno.DefineSucess();
            }
            else
            {
                retorno.ErrorMessage = String.Format(MensagensEntidades.ErroAoRealizarOperacao, Operacaoes.CadastroUsuario);
                retorno.Alertas = UC.Notifications;
                retorno.DefineErro();
            }

            return retorno;
        }

        public UsuarioRespost Inativar(Guid IdUsuario)
        {
            throw new NotImplementedException();
        }

        public void InativaSessoesUsuario(Guid IdUsuario)
        {
            List<MapSessaoUsuario> SessaoAtiva = (from sessao in DBContext.SessaoUsuario
                                                  where sessao.UsuarioID == IdUsuario
                                                  select sessao).ToList();
            if (SessaoAtiva != null)
            {
                foreach (MapSessaoUsuario sessao in SessaoAtiva)
                    sessao.Ativo = false;
                DBContext.SaveChanges();
            }
        }
        
        public void InativaSessao(Guid IdSessao)
        {
            List<MapSessaoUsuario> SessoesAtivas = (from sessao in DBContext.SessaoUsuario
                                                    where sessao.Id == IdSessao
                                                    select sessao).ToList();
            if(SessoesAtivas != null)
            {
                foreach (MapSessaoUsuario sessao in SessoesAtivas)
                    sessao.Ativo = false;
                DBContext.SaveChanges();
            }
        }

        public List<UsuarioView> ListarUsuario(FiltroUsuario Filtro)
        {
            List<UsuarioView> Retorno = new List<UsuarioView>();

            List<MapUsuario> PreRetorno = DBContext.Usuarios
                                          .FromSql(ObtenhaSqlConsultaUsuario(Filtro))
                                          .ToList();

            if(PreRetorno != null && PreRetorno.Count > 0)
            {
                Retorno = PreRetorno.Select(usuario => new UsuarioView()
                {
                    Ativo = usuario.Ativo,
                    Email = usuario.Email,
                    IdEntidade = usuario.Id,
                    IdSessao = Filtro.IdSessao,
                    Login = usuario.Login,
                    Usuario = usuario.Nome
                }).ToList();
            }
            return Retorno;
        }

        public bool SessaoAtiva(Guid IdSessao)
        {
            List<MapSessaoUsuario> SessoesAtivas = (from sessao in DBContext.SessaoUsuario
                                                    where sessao.Id == IdSessao
                                                    select sessao).ToList();
            if (SessoesAtivas != null && SessoesAtivas.Count > 0)
                return SessoesAtivas.FirstOrDefault().Ativo;
            return false;
        }

        public static DadosSessao StatusSessao(Guid SessaoId, WayContext Context)
        {
            DadosSessao Retorno = new DadosSessao();

            Retorno.Usuario = (from sessao in Context.SessaoUsuario
                                       join usuario in Context.Usuarios on sessao.UsuarioID equals usuario.Id
                                       where sessao.Id == SessaoId && 
                                             sessao.Ativo == true && 
                                             usuario.Ativo == true
                                       select usuario).FirstOrDefault();

            return Retorno;
        }

        #region Selects
        private string ObtenhaSqlConsultaUsuario(FiltroUsuario Filtro)
        {
            StringBuilder Sql = new StringBuilder();

            Sql.AppendLine
                (@"select * from Usuarios
                        where Usuarios.InstituicaoID =
                        (select Usuarios.InstituicaoID from SessaoUsuario 
                        inner join Usuarios on Usuarios.Id = SessaoUsuario.UsuarioID
                        where SessaoUsuario.Id = '{0}'
                        and SessaoUsuario.Ativo = 1 and Usuarios.Ativo = 1)
                    ");

            if(Filtro.IdEntidade != Guid.Empty)
            {
                Sql.AppendLine($"and Usuarios.Id = '{Filtro.IdEntidade.ToString()}'");
            }
            return string.Format(Sql.ToString(), Filtro.IdSessao.ToString());
        }
        #endregion
    }
}
