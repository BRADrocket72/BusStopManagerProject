using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebMVC.Models;
using Domain;

public class UserController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ILogger<UserController> _logger;

    public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<UserController> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }


    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var user = new Driver
        {
            UserName = model.FirstName + model.LastName,
            FirstName = model.FirstName,
            LastName = model.LastName,
            IsAdmin = false
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        // If the user was successfully created and is the first user in the system, make them an admin
        if (result.Succeeded && _userManager.Users.Count() == 1)
        {
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        return Ok();


    }
}