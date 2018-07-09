using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Way.Base.ControllerBase;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Resources;
using Way.Domain.Services;
using Way.infra.DefRepositories;
using Way.infra.Persistencia;

namespace Way.Controllers.Api
{
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        private UsuarioService _Service = null;

        public LoginController(WayContext DBContext, string LogFolder = "Logs") : base(DBContext, LogFolder)
        {
            _Service = new UsuarioService(new DefRepositorioUsuario(DBContext));
        }

        [HttpPost]
        public IActionResult Login(LoginUsuarioRequest LoginData)
        {
            try
            {
                LoginUsuarioRespost resultLogin = _Service.AutenticaUsuario(LoginData);
                return new JsonResult(resultLogin);
            }
            catch (Exception Erro)
            {
                Task.Run(() => { ServicoLog.AddLog(Erro.Message); });
            }
            return new JsonResult(MensagensEntidades.ErroInesperado);
        }

        [HttpPut]
        public void Logout(Guid IdSessao)
        {
            try
            {
                _Service.InativarSessao(IdSessao);
            }
            catch(Exception Erro)
            {
                Task.Run(() => { ServicoLog.AddLog(Erro.Message); });
            }
        }

        //http://localhost:50921/api/login?idSessao=7a437821-9cda-4ab0-8c6a-79415277dc92
        [HttpGet]
        public IActionResult SessaoAtiva(string idSessao) {
            try{
                bool Ativa = _Service.SessaoAtiva(new Guid(idSessao));
                return new JsonResult(new SessaoAtivaRespost() { SessaoAtiva = Ativa});
            }
            catch(Exception Erro)
            {
                Task.Run(() => { ServicoLog.AddLog(Erro.Message); });
            }
            return new JsonResult(MensagensEntidades.ErroInesperado);
        }

    }
}