namespace todo.Data;

using Microsoft.EntityFrameworkCore;
using todo.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }
    public DbSet<BoardModel> Boards { get; set; }
    public DbSet<AuthorizedAccessModel> AuthAcesss { get; set; }


}