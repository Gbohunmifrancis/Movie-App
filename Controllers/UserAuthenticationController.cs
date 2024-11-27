using Microsoft.AspNetCore.Mvc;
using Movie_App.Models.DTO;
using Movie_App.Repositories.Abstract;

namespace Movie_App.Controllers;

public class UserAuthenticationController : Controller
{
    // GET
    private readonly IUserAuthenticationService authService;

    public UserAuthenticationController(IUserAuthenticationService _authService)
    {
        this.authService = authService;
    }
    [HttpPost]
    public async Task<IActionResult> Register()
    {
        var model = new RegistrationModel
        {
            Email = "francisgbohunmi@gmail.com",
            Username = "admin",
            Name = "Francis",
            Password = "francis123",
            PasswordConfirm = "francis123",
            Role = "Admin"
        };
        // if you want to register with user, change Role="User"
        var result = await authService.RegisterAsync(model);
        return Ok(result.Message);
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View(); // This returns the login view when accessed via GET
    }
    
    
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await authService.LoginAsync(model);
        if (result.StatusCode == 1)
            return RedirectToAction("Index", "Home");
        else
        {
            TempData["msg"] = "Could not logged in..";
            return RedirectToAction(nameof(Login));
        }
    }

    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();
        return RedirectToAction(nameof(Login));
    }

}
    