using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Way.infra.Persistencia;

namespace Way.Base.ControllerBase
{
    public class BaseAPIController<T,Y> : BaseController
    {
        public BaseAPIController(WayContext DBContext) : base(DBContext)
        {}

    }
}
