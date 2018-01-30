using Microsoft.AspNetCore.Mvc;

namespace ContactManager.WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Locations()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
