using SistemadeTarefas.Models;

namespace SistemadeTarefas.Repositorios.Interfaces
{
    public interface IAvaliacaoRepositorio
    {
        Task<List<AvaliacaoModel>> BuscarTodasAvaliacoes();
        Task<AvaliacaoModel> BuscarPorId(int id);
        Task<AvaliacaoModel> Adicionar(AvaliacaoModel avaliacao);
        Task<AvaliacaoModel> Atualizar(AvaliacaoModel avaliacao, int id);
        Task<bool> Apagar(int id);
    }
}
