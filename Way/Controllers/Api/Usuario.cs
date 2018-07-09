using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class Usuario : BaseController
    {
        private UsuarioService _Service = null;

        public Usuario(WayContext DBContext) : base(DBContext){

            _Service = new UsuarioService(new DefRepositorioUsuario(DBContext));

        }
    }
}
