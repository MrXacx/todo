using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using todo.Exceptions;
using todo.Models;
using todo.Repository;

namespace todo.Controllers;

public class SignController : Controller
{
    private readonly ILogger<SignController> _logger;
    private readonly UserRepository _repository;

    public SignController(ITodoRepository<UserModel> repository, ILogger<SignController> logger)
    {
        _logger = logger;
        _repository = (UserRepository)repository;
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
            try
            {
                var id = _repository?.ReadByCredentials(User).Id ?? throw new NoContentRetrieveException();
                return RedirectToAction("Index", "Task", routeValues: new { authorId = id });
            }
            catch (NoContentRetrieveException)
            {
                ViewBag.Error = "Email e/ou senha estão incorretos.";
            }
        }
        else ViewBag.Error = "Preencha todos os campos.";
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
            try
            {
                return RedirectToActionPreserveMethod("In", routeValues: _repository?.Create(User));
            }
            catch (NoContentRetrieveException)
            {
                ViewBag.Error = "Não foi possível criar uma conta.";
            }
        }
        else ViewBag.Error = "Preencha todos os campos.";

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
