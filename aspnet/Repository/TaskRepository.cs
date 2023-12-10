using todo.Data;
using todo.Exceptions;
using todo.Models;

namespace todo.Repository;

public class TaskRepository : ITodoRepository<TaskModel>
{
    private readonly TodoContext context;

    public TaskRepository(TodoContext context)
    {
        this.context = context;
    }

    public TaskModel Create(TaskModel Task)
    {
        context.Tasks.Add(Task);
        context.SaveChanges();
        return Task;
    }

    public TaskModel Read(int Id)
    {
        return context.Tasks.FirstOrDefault((Task) => Task.Id == Id) ?? throw new NoContentRetrieveException();
    }
    public List<TaskModel> List(int BoardId)
    {
        return context.Tasks.ToList().FindAll((T) => T.BoardId == BoardId);
    }

    public TaskModel Update(TaskModel Task)
    {
        var RetrievedTask = Read(Task.Id);

        RetrievedTask.Content = Task.Content;
        RetrievedTask.Date = Task.Date;

        context.Tasks.Update(RetrievedTask);
        context.SaveChanges();

        return RetrievedTask;
    }

    public bool Delete(int Id)
    {
        var RetrievedTask = Read(Id);

        context.Tasks.Remove(RetrievedTask);
        return context.SaveChanges() == 1;
    }
}