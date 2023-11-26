using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using todo.Models;

namespace todo.Controllers;

public class TaskController : Controller
{
    private readonly ILogger<TaskController> _logger;

    public TaskController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new List<TaskModel>());
    }

    [HttpPost]
    public IActionResult Create(TaskModel Task)
    {
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(TaskModel Task)
    {
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(TaskModel Task)
    {
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
