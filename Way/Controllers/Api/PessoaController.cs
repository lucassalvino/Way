using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Way.Base.ControllerBase;
using Way.infra.Persistencia;

namespace Way.Controllers.Api
{
    [Route("api/[controller]")]
    public class PessoaController : BaseController
    {
        public PessoaController(WayContext DBContext, string LogFolder = "Logs") : base(DBContext, LogFolder){}

        public IActionResult Index()
        {
            return View();
        }
    }
}