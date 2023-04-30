using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class BusDriverController : Controller
    {
        public IActionResult BusDriver()
        {
            ViewData["Boarding"] = 0;
            ViewData["Exiting"] = 0;
            /*
            var model = new BusDriverViewModel
            {
                Boarding = (int)ViewData["Boarding"],
                Exiting = (int)ViewData["Exiting"]
            };
            */
            return View();
        }

        [HttpPost]
        public IActionResult IncreaseBoarding()
        {
            int boarding = (int)ViewData["Boarding"];
            boarding++;
            ViewData["Boarding"] = boarding;
            return View("BusDriver");
        }

        [HttpPost]
        public IActionResult DecreaseBoarding()
        {
            int boarding = (int)ViewData["Boarding"];
            boarding--;
            ViewData["Boarding"] = boarding;
            return View("BusDriver");
        }

        [HttpPost]
        public IActionResult IncreaseExiting()
        {
            int exiting = (int)ViewData["Exiting"];
            exiting++;
            ViewData["Exiting"] = exiting;
            return View("BusDriver");
        }

        [HttpPost]
        public IActionResult DecreaseExiting()
        {
            int exiting = (int)ViewData["Exiting"];
            exiting--;
            ViewData["Exiting"] = exiting;
            return View("BusDriver");
        }
    }
}
