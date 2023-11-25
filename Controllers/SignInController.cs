using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using todo.Models;

namespace todo.Controllers;

public class SignInController : Controller
{
    private readonly ILogger<SignInController> _logger;

    public SignInController(ILogger<SignInController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
