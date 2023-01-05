using Microsoft.AspNetCore.Mvc;

namespace Vineeth.Areas.Financial.Controllers
{
    [Route("Financial/[Controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
