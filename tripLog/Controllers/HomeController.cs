using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tripLog.Models;

namespace tripLog.Controllers
{
    public class HomeController : Controller
       
    { 
        private readonly TripLogContext _context;
        public HomeController(TripLogContext context)
        {
            _context = context;
        }
        //home page with trip details
        public IActionResult Index()
        {
            var trips = _context.Trips
                .Include(t => t.Destination)
                .Include(t => t.Accommodation)
                .Include(t => t.Activities)
                .ToList();

            ViewData["Title"] = "Manage Trips";
            ViewData["ActivePage"] = "Home";

            return View(trips);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // removed the item with id and returns to index
            var trip = _context.Trips
                .Include(t => t.Activities)
                .FirstOrDefault(t => t.TripId == id);

            if (trip == null)
            {
                return NotFound();
            }
            trip.Activities.Clear();
            _context.Trips.Remove(trip);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult ManageDestination()
        {
            ViewData["Title"] = "Manage Destinations";
            ViewData["ActivePage"] = "Destinations";
            return View();
        }
        public IActionResult ManageActivity()
        {
            ViewData["Title"] = "Manage Activities";
            ViewData["ActivePage"] = "Activities";
            return View();
        }
        public IActionResult ManageAccommodation()
        {
            ViewData["Title"] = "Manage Accommodations";
            ViewData["ActivePage"] = "Accommodations";
            return View();
        }
    }
}
