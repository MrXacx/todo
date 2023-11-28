using todo.Data;
using todo.Exceptions;
using todo.Models;

namespace todo.Repository;

public class AuthorizedAcessRepository : ITodoRepository<AuthorizedAcessModel>
{
    private readonly TodoContext context;

    public AuthorizedAcessRepository(TodoContext context)
    {
        this.context = context;
    }

    public AuthorizedAcessModel Create(AuthorizedAcessModel AuthAcess)
    {
        context.AuthAcesss.Add(AuthAcess);
        context.SaveChanges();
        return AuthAcess;
    }

    public AuthorizedAcessModel Read(int Id)
    {
        return context.AuthAcesss.FirstOrDefault((AuthAcess) => AuthAcess.Id == Id) ?? throw new NoContentRetrieveException();
    }

    public List<AuthorizedAcessModel> List(int BoardId)
    {
        return context.AuthAcesss.ToList();
    }

    public bool Delete(int Id)
    {
        var RetrievedAuthAcess = Read(Id);

        context.AuthAcesss.Remove(RetrievedAuthAcess);
        return context.SaveChanges() == 1;
    }

    public AuthorizedAcessModel Update(AuthorizedAcessModel Model)
    {
        throw new NotImplementedException();
    }
}