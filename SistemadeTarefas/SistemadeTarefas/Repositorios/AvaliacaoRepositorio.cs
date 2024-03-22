using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repositorios.Interfaces;
using SistemaDeTarefas.Data;

namespace SistemadeTarefas.Repositorios
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;
        public AvaliacaoRepositorio(SistemaTarefasDbContext sistemaBibliotecaDBContex)
        {
            _dbContext = sistemaBibliotecaDBContex;
        }
        public async Task<AvaliacaoModel> Adicionar(AvaliacaoModel avaliacao)
        {
            await _dbContext.Avaliacoes.AddAsync(avaliacao);
            await _dbContext.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<AvaliacaoModel> BuscarPorId(int id)
        {
            return await _dbContext.Avaliacoes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AvaliacaoModel> Atualizar(AvaliacaoModel avaliacao, int id)
        {
            AvaliacaoModel avaliacaoPorId = await BuscarPorId(id);


            if (avaliacaoPorId == null)
            {
                throw new Exception($"Avaliacao do ID: {id} não foi encontrado");
            }

            avaliacaoPorId.Pontuacao = avaliacao.Pontuacao;
            avaliacaoPorId.Comentario = avaliacao.Comentario;
            avaliacaoPorId.DataAvaliacao = avaliacao.DataAvaliacao;

            _dbContext.Avaliacoes.Update(avaliacaoPorId);
            await _dbContext.SaveChangesAsync();

            return avaliacaoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            AvaliacaoModel avaliacaoPorId = await BuscarPorId(id);
            if (avaliacaoPorId == null)
            {
                throw new Exception($"Avaliacao do Id: {id} não foi encontrado");
            }

            _dbContext.Avaliacoes.Remove(avaliacaoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<AvaliacaoModel>> BuscarTodasAvaliacoes()
        {
            return await _dbContext.Avaliacoes.ToListAsync();
        }
    }
}