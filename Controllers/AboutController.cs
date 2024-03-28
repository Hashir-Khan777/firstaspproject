using Microsoft.AspNetCore.Mvc;

namespace firstaspapp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
