using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Way.Base.ControllerBase;
using Way.infra.Persistencia;

namespace Way.Controllers
{
    public class UsuarioController : BaseController
    {
        public UsuarioController(WayContext DBContext, string LogFolder = "Logs") : base(DBContext, LogFolder){}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetalheUsuario()
        {
            return View();
        }
    }
}