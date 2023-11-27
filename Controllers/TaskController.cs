using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using todo.Exceptions;
using todo.Models;
using todo.Repository;

namespace todo.Controllers;

public class TaskController : Controller
{
    private readonly ILogger<TaskController> _logger;
    private readonly UserRepository _AuthorRepository;
    private readonly TaskRepository _TaskRepository;

    public TaskController(ITodoRepository<TaskModel> taskRepository, ITodoRepository<UserModel> authorRepository, ILogger<TaskController> logger)
    {
        _logger = logger;
        _TaskRepository = (TaskRepository)taskRepository;
        _AuthorRepository = (UserRepository)authorRepository;
    }

    public IActionResult Index(int authorId)
    {
        var User = _AuthorRepository.Read(authorId);
        User.Tasks = _TaskRepository.List(User.Id);

        ViewBag.UserName = User.Name;
        return View(User.Tasks);
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
