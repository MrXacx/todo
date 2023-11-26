using todo.Data;
using todo.Exceptions;
using todo.Models;

namespace todo.Repository;

public class UserRepository : ITodoRepository<UserModel>
{
    private readonly TodoContext context;

    public UserRepository(TodoContext context)
    {
        this.context = context;
    }

    public UserModel Create(UserModel User)
    {
        context.Users.Add(User);
        context.SaveChanges();
        return User;
    }

    public UserModel Read(int Id)
    {
        return context.Users.FirstOrDefault((User) => User.Id == Id) ?? throw new NoContentRetrieveException();
    }

    public UserModel Update(UserModel User)
    {
        var RetrievedUser = Read(User.Id);

        RetrievedUser.Name = User.Name;
        RetrievedUser.Password = User.Password;

        context.Users.Update(RetrievedUser);
        context.SaveChanges();

        return RetrievedUser;
    }

    public bool Delete(int Id)
    {
        var RetrievedUser = Read(Id);

        context.Users.Remove(RetrievedUser);
        return context.SaveChanges() == 1;
    }

    public UserModel ReadByCredentials(UserModel User)
    {
        return context.Users.FirstOrDefault((X) => X.Email == User.Email && X.Password == User.Password) ?? throw new NoContentRetrieveException();
    }
}
