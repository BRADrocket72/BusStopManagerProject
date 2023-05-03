using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Domain;

namespace WebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Index action called");
        return View();
    }
    public IActionResult BusDriver()
    {
        _logger.LogInformation("BusDriver action called");
        return View();
    }

    public IActionResult Privacy()
    {
        _logger.LogInformation("Privacy action called");
        return View();
    }

    /*
    public IActionResult BusDriver()
    {
        return View();
    }
    */
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogError("Error action called");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
