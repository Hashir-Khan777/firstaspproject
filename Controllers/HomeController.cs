using Microsoft.AspNetCore.Mvc;

namespace firstaspapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
