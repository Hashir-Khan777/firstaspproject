using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace firstaspapp.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
