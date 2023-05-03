using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using System;

namespace WebMVC.Controllers;

public class EntryController : Controller
{
    private readonly ILogger<EntryController> _logger;

    public EntryController(ILogger<EntryController> logger)
    {
        _logger = logger;
    }

    public IActionResult EntriesTable()
    {
        List<EntryViewModel> entrys = new List<EntryViewModel> { new EntryViewModel { Id = Guid.NewGuid(), Boarded = 2, LeftBehind = 2, Timestamp = new DateTime(), Driver = new DriverViewModel { Id = Guid.NewGuid(), FirstName = "brad", LastName = "chad" }, Loop = new LoopViewModel { Id = Guid.NewGuid(), Name = "loop1" } } };
        _logger.LogInformation("Successfully retrieved entries.");
        return View(entrys);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
