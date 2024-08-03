using Microsoft.AspNetCore.Mvc;

namespace wlogit.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
