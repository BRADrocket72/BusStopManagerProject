using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using System;


namespace WebMVC.Controllers;

public class StopsController : Controller
{
    private readonly ILogger<StopsController> _logger;

    public StopsController(ILogger<StopsController> logger)
    {
        _logger = logger;
    }


    public IActionResult StopsMap()
    {
        List<MapPointViewModel> stops = new List<MapPointViewModel> { new MapPointViewModel { lat = -25.344, lng = 131.031 }, new MapPointViewModel { lat = -20.344, lng = 121.031 } };

        return View(stops);
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
