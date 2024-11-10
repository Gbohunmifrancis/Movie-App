using Microsoft.AspNetCore.Mvc;

namespace Movie_App.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
}