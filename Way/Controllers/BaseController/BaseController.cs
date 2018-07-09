using Microsoft.AspNetCore.Mvc;
using System;
using Way.Domain.Services;
using Way.infra.Persistencia;

namespace Way.Base.ControllerBase
{
    public class BaseController : Controller
    {
        private readonly WayContext wayContext;

        public LogService ServicoLog { get; private set; }

        protected WayContext DBContext
        {
            get
            {
                if (wayContext == null)
                    throw new Exception("Contexto da base não foi inicializado!!!");
                return wayContext;
            }
        }

        public BaseController(WayContext DBContext, String LogFolder = "Logs")
        {
            wayContext = DBContext;
            ServicoLog = new LogService(LogFolder);
        }
    }
}
