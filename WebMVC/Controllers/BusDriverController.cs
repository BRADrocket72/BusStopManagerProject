using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult BusLoopSelection()
        {
            List<BusViewModel> buses = new List<BusViewModel> { new BusViewModel { Id = 1, BusNumber = 2 }, new BusViewModel { Id = 2, BusNumber = 3 } };
            List<LoopViewModel> loops = new List<LoopViewModel> { new LoopViewModel { Id = 1, Name = "Red" }, new LoopViewModel { Id = 2, Name = "Blue" } };
            BusLoopSelectionViewModel model = new BusLoopSelectionViewModel { Buses = buses, Loops = loops };
            ViewBag.Bus = new SelectList(buses, "Id", "BusNumber");
            ViewBag.Loops = new SelectList(loops, "Id", "Name");
            return View(model);
        }
    }
}
