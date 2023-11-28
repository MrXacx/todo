using todo.Data;
using todo.Exceptions;
using todo.Models;

namespace todo.Repository;

public class AuthorizedAccessRepository : ITodoRepository<AuthorizedAccessModel>
{
    private readonly TodoContext context;

    public AuthorizedAccessRepository(TodoContext context)
    {
        this.context = context;
    }

    public AuthorizedAccessModel Create(AuthorizedAccessModel AuthAcess)
    {
        context.AuthAcesss.Add(AuthAcess);
        context.SaveChanges();
        return AuthAcess;
    }

    public AuthorizedAccessModel Read(int Id)
    {
        return context.AuthAcesss.FirstOrDefault((AuthAcess) => AuthAcess.Id == Id) ?? throw new NoContentRetrieveException();
    }

    public List<AuthorizedAccessModel> List(int BoardId)
    {
        return context.AuthAcesss.ToList();
    }

    public bool Delete(int Id)
    {
        var RetrievedAuthAcess = Read(Id);

        context.AuthAcesss.Remove(RetrievedAuthAcess);
        return context.SaveChanges() == 1;
    }

    public AuthorizedAccessModel Update(AuthorizedAccessModel Model)
    {
        throw new NotImplementedException();
    }
}