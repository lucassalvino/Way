using Way.infra.Persistencia;
using Way.Domain.Entities;
using Way.Domain.Entities.ValoresPadroes;
using System.Linq;
using Way.infra.Mapeadores;
using Xunit;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Services;
using Way.infra.DefRepositories;
using System.Collections.Generic;

namespace Way.Testes.Testes
{
    public class LoginTestes : BaseTests
    {
        [Fact]
        public void RealizaLoginAdmDefault()
        {
            UsuarioService ServicoUsuario = new UsuarioService(new DefRepositorioUsuario(this.DbContext));

            Usuario AdmDefault = PadraoUsuario.Admin;
            LoginUsuarioRequest RequestLogin = new LoginUsuarioRequest()
            {
                Login = AdmDefault.Login,
                Senha = "D26m04a03"
            };
            LoginUsuarioRespost retorno =  ServicoUsuario.AutenticaUsuario(RequestLogin);

            SessaoUsuario SessaoAtiva = (from sessao in DbContext.SessaoUsuario
                                         where sessao.Ativo == true && sessao.UsuarioID == AdmDefault.Id
                                         select new SessaoUsuario()
                                         {
                                             Id = sessao.Id,
                                             Ativo = sessao.Ativo,
                                             InicioSessao = sessao.DataInicioSessao.DateTime,
                                             UsuarioId = sessao.UsuarioID
                                         }).FirstOrDefault();

            Assert.False(SessaoAtiva == null);

            retorno = ServicoUsuario.AutenticaUsuario(RequestLogin);

            List<MapSessaoUsuario> SessoesAtivas = (from sessao in DbContext.SessaoUsuario
                                                    where sessao.Ativo == true && sessao.UsuarioID == AdmDefault.Id
                                                    select sessao).ToList();

            Assert.False(SessoesAtivas == null);
            Assert.Single(SessoesAtivas);
        }
    }
}
