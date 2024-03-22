using SistemadeTarefas.Models;

namespace SistemadeTarefas.Repositorios.Interfaces
{
    public interface IAutorRepositorio
    {
        Task<List<AutorModel>> BuscarTodosAutores();
        Task<AutorModel> BuscarPorId(int id);
        Task<AutorModel> Adicionar(AutorModel autor);
        Task<AutorModel> Atualizar(AutorModel autor, int id);
        Task<bool> Apagar(int id);
    }
}
