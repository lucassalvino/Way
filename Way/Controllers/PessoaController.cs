﻿using Microsoft.AspNetCore.Mvc;
using Way.Base.ControllerBase;
using Way.infra.Persistencia;

namespace Way.Controllers
{
    public class PessoaController : BaseController
    {
        public PessoaController(WayContext DBContext, string LogFolder = "Logs") : base(DBContext, LogFolder){}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetalhePessoa()
        {
            return View();
        }
    }
}