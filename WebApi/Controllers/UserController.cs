using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebMVC.Models;
using Domain;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<Driver> _userManager;
    private readonly SignInManager<Driver> _signInManager;
    private readonly ILogger<UserController> _logger;

    public UserController(UserManager<Driver> userManager, SignInManager<Driver> signInManager, ILogger<UserController> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var user = new Driver
        {
            UserName = model.FirstName,
            FirstName = model.FirstName,
            LastName = model.LastName,
            IsAdmin = false
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        // If the user was successfully created and is the first user in the system, make them an admin
        if (result.Succeeded && _userManager.Users.Count() == 1)
        {
            await _userManager.AddClaimAsync(user, new Claim("IsAdmin", "true"));
        }

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(string username, string password)
    {
        // Use the SignInManager to sign in the user
        var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return Ok();
        }
        else
        {
            return Unauthorized(result);
        }
    }
}