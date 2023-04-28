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
        List<RouteViewModel> routes = new List<RouteViewModel> { new RouteViewModel { Id = Guid.NewGuid(), Order = 2 } };
        return View(routes);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
