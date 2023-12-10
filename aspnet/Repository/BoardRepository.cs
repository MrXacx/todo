using todo.Data;
using todo.Exceptions;
using todo.Models;

namespace todo.Repository;

public class BoardRepository : ITodoRepository<BoardModel>
{
    private readonly TodoContext context;

    public BoardRepository(TodoContext context)
    {
        this.context = context;
    }

    public BoardModel Create(BoardModel Board)
    {
        context.Boards.Add(Board);
        context.SaveChanges();
        return Board;
    }

    public BoardModel Read(int Id)
    {
        return context.Boards.FirstOrDefault((Board) => Board.Id == Id) ?? throw new NoContentRetrieveException();
    }
    public List<BoardModel> List(int OwnerId)
    {
        return context.Boards.ToList().FindAll((B) => B.Owner == OwnerId);
    }

    public BoardModel Update(BoardModel Board)
    {
        var RetrievedBoard = Read(Board.Id);

        RetrievedBoard.Title = Board.Title;
        RetrievedBoard.Description = Board.Description;

        context.Boards.Update(RetrievedBoard);
        context.SaveChanges();

        return RetrievedBoard;
    }

    public bool Delete(int Id)
    {
        var RetrievedBoard = Read(Id);

        context.Boards.Remove(RetrievedBoard);
        return context.SaveChanges() == 1;
    }
}