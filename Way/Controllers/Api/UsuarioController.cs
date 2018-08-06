using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Way.Base.ControllerBase;
using Way.Domain.Arguments.Filters;
using Way.Domain.Arguments.Request;
using Way.Domain.Arguments.Respost;
using Way.Domain.Resources;
using Way.Domain.Services;
using Way.infra.DefRepositories;
using Way.infra.Persistencia;

namespace Way.Controllers.Api
{
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        private UsuarioService _Service = null;

        public UsuarioController(WayContext DBContext) : base(DBContext){

            _Service = new UsuarioService(new DefRepositorioUsuario(DBContext));

        }

        [HttpGet]
        public IActionResult Usuarios(FiltroUsuario Filtro)
        {
            try
            {
                bool Ativa = _Service.SessaoAtiva(Filtro.IdSessao);
                if (!Ativa) Redirect("/login");
                return new JsonResult(_Service.ListarUsuario(Filtro));
            }
            catch(Exception Erro)
            {
                Task.Run(() => { ServicoLog.AddLog(Erro.Message); });
            }
            return new JsonResult(MensagensEntidades.ErroInesperado);
        }

        [HttpPost]
        public IActionResult CadastroUsuario (UsuarioRequest Data)
        {
            try
            {
                return new JsonResult(_Service.CadastraUsuario(Data));
            }
            catch(Exception Erro)
            {
                ServicoLog.AddLogByExceptionAsync(Erro, Data.ToString());
            }
            return new JsonResult(MensagensEntidades.ErroInesperado);
        }
    }
}
