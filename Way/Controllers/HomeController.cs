using Microsoft.AspNetCore.Mvc;
using Way.Base.ControllerBase;
using Way.infra.Persistencia;

namespace Way.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(WayContext DBContext) : base(DBContext){}

        public IActionResult Index()
        {
            return View();
        }
    }
}
