using Microsoft.AspNetCore.Mvc;
using tripLog.Models;

namespace tripLog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ManageDestination()
        {
            return View();
        }
        public IActionResult ManageActivity()
        {
            return View();
        }
        public IActionResult ManageAccommodation()
        {
            return View();
        }
    }
}
