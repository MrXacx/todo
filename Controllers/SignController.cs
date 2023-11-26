using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using todo.Models;

namespace todo.Controllers;

public class SignController : Controller
{
    private readonly ILogger<SignController> _logger;

    public SignController(ILogger<SignController> logger)
    {
        _logger = logger;
    }

    public IActionResult In()
    {
        return View();
    }

    [HttpPost]
    public IActionResult In(UserModel User)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index", "Task");
        }

        ViewBag.Error = "Model inválida";
        return View();
    }

    public IActionResult Up()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Up(UserModel User)
    {
        if (ModelState.IsValid)
        {
            return RedirectToActionPreserveMethod("In", routeValues: User);
        }

        ViewBag.Error = "Model inválida";

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
