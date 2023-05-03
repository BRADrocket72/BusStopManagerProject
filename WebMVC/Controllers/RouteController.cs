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



    public ActionResult RoutesTable()
    {
        List<RouteViewModel> routes = new List<RouteViewModel>();
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5279/");
        var responseTask = client.GetAsync("route/getall");
        responseTask.Wait();
        var result = responseTask.Result;

        if (result.IsSuccessStatusCode)
        {
            var readTask = result.Content.ReadFromJsonAsync<List<RouteViewModel>>();
            routes = readTask.Result;
        }

        return View(routes);
    }






    public IActionResult RouteMap()
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
