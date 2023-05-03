using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class BusDriverController : Controller
    {
        private readonly ILogger<BusDriverController> _logger;

        public BusDriverController(ILogger<BusDriverController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BusDriverViewModel model)
        {
            int totalPassengers = model.Boarding - model.Exiting;
            ViewData["TotalPassengers"] = totalPassengers;

            _logger.LogInformation("Total passengers: {TotalPassengers}", totalPassengers);

            return View();
        }
    }
}
