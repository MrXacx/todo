namespace todo.Repository;
using todo.Models;

interface ITodoRepository<Model> where Model : IModel // Abstrai interface para receber e retornar qualquer implementação de IModel
{
    Model Create(Model Model);
    Model Read(int Id);
    Model Update(Model Model);
    bool Delete(Model Model);
}