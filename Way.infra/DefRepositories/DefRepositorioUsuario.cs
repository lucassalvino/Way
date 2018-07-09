using System;
using System.Linq;
using System.Collections.Generic;
using Way.Domain.Arguments;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Interfaces.Repositories;
using Way.infra.ManagerTables;
using Way.infra.Mapeadores;
using Way.infra.Persistencia;
using Way.Domain;
using Way.Domain.Resources;
using System.Threading.Tasks;
using Way.Domain.Services;

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
                ret.Error = MensagensEntidades.ErroInesperado;
                Task.Run(()=> { new LogService().AddLog(Erro.Message); });
            }

            return ret;
        }

        public UsuarioRespost CadastraUsuario(UsuarioRequest Usuario)
        {
            throw new NotImplementedException();
        }

        public BaseArgumentos EditaUsuario(Guid IdUsuario, UsuarioRequest Usuario)
        {
            throw new NotImplementedException();
        }

        public BaseArgumentos Inativar(Guid IdUsuario)
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
            throw new NotImplementedException();
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
    }
}
