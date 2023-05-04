using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using System;
using System.Reflection;
using WebMVC.Helpers;

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
        List<EntryViewModel> entrys = new List<EntryViewModel>
        {
            new EntryViewModel { Id = 2, Boarded = 2, LeftBehind = 7, Timestamp = new DateTime(), Driver = new DriverViewModel { Id = 4, FirstName = "brad", LastName = "test" }, Loop = new LoopViewModel { Id = 9, Name = "Green" } },
            new EntryViewModel { Id = 3, Boarded = 8, LeftBehind = 6, Timestamp = new DateTime(), Driver = new DriverViewModel { Id = 4, FirstName = "brad", LastName = "test" }, Loop = new LoopViewModel { Id = 9, Name = "White" } },
            new EntryViewModel { Id = 4, Boarded = 1, LeftBehind = 6, Timestamp = new DateTime(), Driver = new DriverViewModel { Id = 4, FirstName = "brad", LastName = "test" }, Loop = new LoopViewModel { Id = 9, Name = "Blue" } },
            new EntryViewModel { Id = 5, Boarded = 25, LeftBehind = 5, Timestamp = new DateTime(), Driver = new DriverViewModel { Id = 4, FirstName = "brad", LastName = "test" }, Loop = new LoopViewModel { Id = 9, Name = "Red" } },
            new EntryViewModel { Id = 6, Boarded = 9, LeftBehind = 2, Timestamp = new DateTime(), Driver = new DriverViewModel { Id = 4, FirstName = "brad", LastName = "test" }, Loop = new LoopViewModel { Id = 2, Name = "Green" } },
         };
        return View(entrys);
    }

    public void WriteToCsv()
    {
        List<EntryViewModel> entries = new List<EntryViewModel> { new EntryViewModel { Id = 2, Boarded = 2, LeftBehind = 2, Timestamp = new DateTime(), Driver = new DriverViewModel { Id = 4, FirstName = "brad", LastName = "test" }, Loop = new LoopViewModel { Id = 9, Name = "loop1" } } };

        CSVWriter.WriteCSV<EntryViewModel>(entries, "entries.csv");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
