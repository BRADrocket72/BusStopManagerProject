using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        _logger.LogInformation("Login page accessed.");
        return View();
    }

    public IActionResult LoginUser(){
        _logger.LogInformation("User login attempted.");
        return View();
    }

    public IActionResult Register()
    {
        _logger.LogInformation("Registration page accessed.");
        return View();
    }

        public IActionResult RegisterUser()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5279/");
        var responseTask = client.GetAsync("user/register");
        responseTask.Wait();
        var result = responseTask.Result;

        if (result.IsSuccessStatusCode)
        {
           
        }
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogError("An error occurred on the login page.");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
