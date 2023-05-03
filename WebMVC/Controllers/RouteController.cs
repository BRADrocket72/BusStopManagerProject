using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using System;


namespace WebMVC.Controllers;

public class RouteController : Controller
{
    private readonly ILogger<RouteController> _logger;

    public RouteController(ILogger<RouteController> logger)
    {
        _logger = logger;
    }



    public IActionResult RoutesTable()
    {
        _logger.LogInformation("Fetching routes data");
        List<RouteViewModel> routes = new List<RouteViewModel> { new RouteViewModel { Id = Guid.NewGuid(), Order = 2 } };
        return View(routes);
    }




    public IActionResult RouteMap()
    {
        _logger.LogInformation("Fetching route map data");
        List<MapPointViewModel> stops = new List<MapPointViewModel> { new MapPointViewModel { lat = -25.344, lng = 131.031 }, new MapPointViewModel { lat = -20.344, lng = 121.031 } };

        return View(stops);
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogError($"An error occurred while processing the request with ID {Activity.Current?.Id ?? HttpContext.TraceIdentifier}");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
