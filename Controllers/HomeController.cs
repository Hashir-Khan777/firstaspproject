using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
