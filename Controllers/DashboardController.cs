using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using todo.Exceptions;
using todo.Models;
using todo.Repository;

namespace todo.Controllers;

public class DashboardController : Controller
{
    private readonly ILogger<TaskController> _logger;
    private readonly UserRepository _AuthorRepository;
    private readonly BoardRepository _BoardRepository;
    private readonly AuthorizedAccessRepository _AuthAccessdRepository;

    public DashboardController(
        ITodoRepository<BoardModel> boardRepository,
        ITodoRepository<UserModel> authorRepository,
        ITodoRepository<AuthorizedAccessModel> authAccessRepository,
        ILogger<TaskController> logger)
    {
        _logger = logger;
        _BoardRepository = (BoardRepository)boardRepository;
        _AuthorRepository = (UserRepository)authorRepository;
        _AuthAccessdRepository = (AuthorizedAccessRepository)authAccessRepository;
    }

    [HttpGet("Dashboard/{owner}")]
    public IActionResult Index(int owner)
    {
        var User = _AuthorRepository.Read(owner);
        User.Boards = _BoardRepository.List(User.Id);

        return View(User);
    }

    [HttpGet("Board/Create/{owner}")]
    public IActionResult Create(int owner)
    {
        ViewBag.User = _AuthorRepository.Read(owner);
        if (TempData.TryGetValue("Error", out object? error))
        {
            ViewBag.Error = error;
        }

        return View();
    }

    [HttpPost("Board/Create")]
    public IActionResult Create([FromForm] BoardModel Board)
    {
        if (ModelState.IsValid)
        {
            Board = _BoardRepository.Create(Board);
            return RedirectToAction("Index", new { owner = Board.Owner });
        }

        TempData["Error"] = "Preencha todos os campos.";

        return RedirectToAction("Create", new { owner = Board.Owner });
    }


    [HttpGet("Board/Update/{board}")]
    public IActionResult Update(int board)
    {
        var Board = _BoardRepository.Read(board);
        ViewBag.UserName = _AuthorRepository.Read(Board.Owner).Name;

        return View(Board);
    }

    [HttpPost("Board/Update")]
    public IActionResult Update([FromForm] BoardModel Board)
    {
        if (ModelState.IsValid)
        {
            try
            {
                Board = _BoardRepository.Update(Board);
                return RedirectToAction("Index", new { owner = Board.Owner });
            }
            catch (NoContentRetrieveException)
            {
                ViewBag.Error = "Quadro desconhecido";
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Warning, e.Message);
            }
        }

        return RedirectToAction("Update", new { board = Board.Id });
    }

    [HttpGet("Board/Delete/{board}")]
    public IActionResult Delete(int board)
    {
        ViewBag.Error = _BoardRepository.Delete(board) ? null : "Não foi possível deletar o quadro";
        return RedirectToAction("Index");
    }

    [HttpGet("Board/Subscribe/{board}")]
    public IActionResult Subscribe(int board)
    {
        var Board = _BoardRepository.Read(board);
        return View(Board);
    }

    [HttpGet("Board/Subscribe")]
    public IActionResult Subscribe([FromForm] int board, [FromForm] string user)
    {
        try
        {
            var Board = _BoardRepository.Read(board);
            try
            {
                var UserId = _AuthorRepository.ReadEmail(user);

                if (UserId != Board.Owner)
                {
                    _AuthAccessdRepository.Create(
                        new AuthorizedAccessModel
                        {
                            User = UserId,
                            Board = Board.Id,
                        }
                    );
                }
                else
                {
                    ViewBag.Error = "Você não pode ser adicionado à lista de leitores";
                }
            }
            catch (NoContentRetrieveException)
            {
                ViewBag.Error = "Email não encontrado.";
            }

            return View(Board);
        }
        catch (NoContentRetrieveException)
        {
            ViewBag.Error = "Quadro não encontrado";
            return RedirectToAction("Index", new { owner = 1 });
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
