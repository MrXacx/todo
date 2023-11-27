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

    public IActionResult Index(int author)
    {
        var User = _AuthorRepository.Read(author);
        User.Tasks = _TaskRepository.List(User.Id);

        if (TempData.TryGetValue("selected_task", out object? task))
        {
            ViewBag.SelectedTask = _TaskRepository.Read((int?)task ?? 0);
        }

        return View(User);
    }

    public IActionResult Create(int author)
    {
        ViewBag.UserName = _AuthorRepository.Read(author).Name;
        ViewBag.UserId = author;
        return View();
    }

    [HttpPost]
    public IActionResult Create(TaskModel Task)
    {
        Task = _TaskRepository.Create(Task);
        return RedirectToAction("Index", new { author = Task.AuthorId });
    }

    public IActionResult Update(int task)
    {
        var Task = _TaskRepository.Read(task);
        ViewBag.UserName = _AuthorRepository.Read(Task.AuthorId).Name;

        return View(Task);
    }

    [HttpPost]
    public IActionResult Update(TaskModel Task)
    {
        if (ModelState.IsValid)
        {
            Task = _TaskRepository.Update(Task);
            return RedirectToAction("Index", new { author = Task.AuthorId });
        }

        return View(Task);
    }

    public RedirectToActionResult Select(int task)
    {
        TempData["selected_task"] = task;
        return RedirectToAction("Index", new { author = _TaskRepository.Read(task).AuthorId });
    }

    public IActionResult Delete(int task)
    {
        ViewBag.Error = _TaskRepository.Delete(task) ? null : "Não foi possível deletar a tarefa";
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
