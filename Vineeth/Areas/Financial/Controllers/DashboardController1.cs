using Microsoft.AspNetCore.Mvc;

namespace Vineeth.Areas.Financial.Controllers
{
    [Area("Financial")]
    [Route("Financial/[Controller]/[action]")]
    public class DashboardController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Graph()
        {
            return View();
        }
    }
}
