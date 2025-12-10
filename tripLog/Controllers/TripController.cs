using Microsoft.AspNetCore.Mvc;

namespace tripLog.Controllers
{
    public class TripController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
