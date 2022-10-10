using Microsoft.AspNetCore.Mvc;

namespace IdentityLibrary.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
