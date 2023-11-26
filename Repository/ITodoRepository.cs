namespace todo.Repository;
using todo.Models;

interface ITodoRepository<Model> where Model : IModel // Abstrai interface para receber e retornar qualquer implementação de IModel
{
    Model create(Model model);
    Model read(int Id);
    List<Model> list(Model model);
    Model update(Model model);
    bool delete(Model model);
}