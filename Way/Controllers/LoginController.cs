using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Way.Base.ControllerBase;
using Way.infra.Persistencia;

namespace Way.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(WayContext DBContext) : base(DBContext)
        {
        }

        public IActionResult Index()
        {
            DBContext.Configure();
            return View();
        }
    }
}