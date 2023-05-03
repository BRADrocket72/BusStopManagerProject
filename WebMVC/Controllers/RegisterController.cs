using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers;

public class RegisterController : Controller
{
    private readonly ILogger<RegisterController> _logger;

    public RegisterController(ILogger<RegisterController> logger)
    {
        _logger = logger;
    }



    public IActionResult Register()
    {

        return View();
    }

    public IActionResult RegisterUser()
    {
        return View();
    }

    public void OnPost()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5279/");
        var responseTask = client.GetAsync("route/getall");
        responseTask.Wait();
        var result = responseTask.Result;

        if (result.IsSuccessStatusCode)
        {
            var readTask = result.Content.ReadFromJsonAsync<List<RouteViewModel>>();
            // routes = readTask.Result;
        }
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
