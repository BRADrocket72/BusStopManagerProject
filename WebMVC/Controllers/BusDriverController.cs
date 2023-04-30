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
            return View();
        }

        



        /*
        private readonly BusDriverViewModel _model;

        public BusDriverController(BusDriverViewModel model)
        {
            _model = model;
        }

        public IActionResult Index()
        {
            return View(_model);
        }

        public IActionResult IncreaseOnBoard()
        {
            _model.IncreaseOnBoard();
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseOnBoard()
        {
            _model.DecreaseOnBoard();
            return RedirectToAction("Index");
        }

        public IActionResult IncreaseDeparting()
        {
            _model.IncreaseDeparting();
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseDeparting()
        {
            _model.DecreaseDeparting();
            return RedirectToAction("Index");
        }
        */
        
    }
}
