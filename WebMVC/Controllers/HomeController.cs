
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Models;

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
    public IActionResult BusLoopSelection()
    {
        List<BusViewModel> buses = new List<BusViewModel> { new BusViewModel { Id = 1, BusNumber = 2 }, new BusViewModel { Id = 2, BusNumber = 3 } };
        List<LoopViewModel> loops = new List<LoopViewModel> { new LoopViewModel { Id = 1, Name = "Red" }, new LoopViewModel { Id = 2, Name = "Blue" } };
        BusLoopSelectionViewModel model = new BusLoopSelectionViewModel { Buses = buses, Loops = loops };
        ViewBag.Buses = new SelectList(buses, "ID", "BusNumber");
        ViewBag.Loops = new SelectList(loops, "ID", "Name");
        ViewData["Loops"] = loops;
        return View(model);
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
