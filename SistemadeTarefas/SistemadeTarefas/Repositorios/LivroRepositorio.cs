using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repositorios.Interfaces;
using SistemaDeTarefas.Data;

namespace SistemadeTarefas.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;
        public LivroRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }
        public async Task<LivroModel> Adicionar(LivroModel livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();

            return livro;
        }

        public async Task<LivroModel> BuscarPorId(int id)
        {
            return await _dbContext.Livros.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<LivroModel> Atualizar(LivroModel livro, int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);


            if (livroPorId == null)
            {
                throw new Exception($"Livro do ID: {id} não foi encontrado");
            }

            livroPorId.Titulo = livro.Titulo;
            livroPorId.Genero = livro.Genero;
            livroPorId.AnoPublicacao = livro.AnoPublicacao;
            livroPorId.ISBN = livro.ISBN;
            livroPorId.Sinopse = livro.Sinopse;

            _dbContext.Livros.Update(livroPorId);
            await _dbContext.SaveChangesAsync();

            return livroPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if (livroPorId == null)
            {
                throw new Exception($"Editora do Id: {id} não foi encontrado");
            }

            _dbContext.Livros.Remove(livroPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<LivroModel>> BuscarTodosLivros()
        {
            return await _dbContext.Livros.ToListAsync();
        }
    }
}
