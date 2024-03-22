using SistemadeTarefas.Models;

namespace SistemadeTarefas.Repositorios.Interfaces
{
    public interface IEditoraRepositorio
    {
        Task<List<EditoraModel>> BuscarTodasEditoras();
        Task<EditoraModel> BuscarPorId(int id);
        Task<EditoraModel> Adicionar(EditoraModel editora);
        Task<EditoraModel> Atualizar(EditoraModel editora, int id);
        Task<bool> Apagar(int id);
    }
}
