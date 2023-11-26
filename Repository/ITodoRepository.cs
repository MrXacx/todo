using todo.Models;

interface ITodoRepository
{
    IModel create(IModel model);
    IModel read(int Id);
    List<IModel> list(IModel model);
    IModel update(IModel model);
    bool delete(IModel model);
}