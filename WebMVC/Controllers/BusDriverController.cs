using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class BusDriverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BusDriverViewModel model)
        {
            int totalPassengers = model.Boarding - model.Exiting;
            ViewData["TotalPassengers"] = totalPassengers;

            return View();
        }
    }
}
