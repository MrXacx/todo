using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using todo.Models;

namespace todo.Controllers;

public class SignUpController : Controller
{
    private readonly ILogger<SignUpController> _logger;

    public SignUpController(ILogger<SignUpController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(UserModel user)
    {
        return RedirectToAction("Index", user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
