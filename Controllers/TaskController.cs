using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using todo.Exceptions;
using todo.Models;
using todo.Repository;

namespace todo.Controllers;

public class TaskController : Controller
{
    private readonly ILogger<TaskController> _logger;
    private readonly TaskRepository _TaskRepository;
    private readonly BoardRepository _BoardRepository;

    public TaskController(ITodoRepository<BoardModel> boardRepository, ITodoRepository<TaskModel> taskRepository, ILogger<TaskController> logger)
    {
        _logger = logger;
        _BoardRepository = (BoardRepository)boardRepository;
        _TaskRepository = (TaskRepository)taskRepository;
    }

    [HttpGet("Tasks/{board}")]
    public IActionResult Index(int board)
    {
        var Board = _BoardRepository.Read(board);
        Board.Tasks = _TaskRepository.List(Board.Id);

        return View(Board);
    }

    [HttpGet("Task/Create/{board}")]
    public IActionResult Create(int board)
    {
        if (TempData.TryGetValue("Error", out object? error))
        {
            ViewBag.Error = error;
        }
        ViewBag.Board = _BoardRepository.Read(board);

        return View();
    }

    [HttpPost("Task/Create")]
    public IActionResult Create([FromForm] TaskModel Task)
    {
        if (ModelState.IsValid)
        {
            Task = _TaskRepository.Create(Task);
            return RedirectToAction("Index", new { board = Task.BoardId });
        }

        TempData["Error"] = "Preencha todos os campos.";

        return RedirectToAction("Create", new { board = Task.BoardId });
    }

    [HttpPost("Task/Delete")]
    public IActionResult Delete([FromForm] int board, [FromForm] int task)
    {
        if (_TaskRepository.Read(task).BoardId == board)
        {
            ViewBag.Error = _TaskRepository.Delete(task) ? null : "Não foi possível deletar a tarefa";
        }
        else
        {
            ViewBag.Error = "A tarefa não refere-se ao quadro correto";
        }
        return RedirectToAction("Index", new { board });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
