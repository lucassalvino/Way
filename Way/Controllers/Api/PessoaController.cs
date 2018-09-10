using Microsoft.AspNetCore.Mvc;
using System;
using Way.Base.ControllerBase;
using Way.Domain.Arguments.Filters;
using Way.Domain.Resources;
using Way.Domain.Services;
using Way.infra.Persistencia;

namespace Way.Controllers.Api
{
    [Route("api/[controller]")]
    public class PessoaController : BaseController
    {
        public PessoaController(WayContext DBContext, string LogFolder = "Logs") : base(DBContext, LogFolder)
        {
            //_Service = new PessoaService();
        }

        private PessoaService _Service = null;

        [HttpGet]
        public IActionResult Pessoas(FiltroPessoa Filtro)
        {
            try
            {

            }
            catch(Exception Erro)
            {
                ServicoLog.AddLogAsync($"Mensagem: [{Erro.Message}] Pilha Execução: [{Erro.StackTrace}]");
            }
            return new JsonResult(MensagensEntidades.ErroInesperado);
        }
        
    }
}