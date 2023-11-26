using Microsoft.EntityFrameworkCore;

namespace todo.Contexts;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
}