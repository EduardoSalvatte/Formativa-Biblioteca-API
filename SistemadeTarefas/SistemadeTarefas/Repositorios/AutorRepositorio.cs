using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repositorios.Interfaces;
using SistemaDeTarefas.Data;

namespace SistemadeTarefas.Repositorios
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;
        public AutorRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }

        public async Task<AutorModel> Adicionar(AutorModel autor)
        {
            await _dbContext.Autores.AddAsync(autor);
            await _dbContext.SaveChangesAsync();

            return autor;
        }

        public async Task<AutorModel> BuscarPorId(int id)
        {
            return await _dbContext.Autores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AutorModel> Atualizar(AutorModel autor, int id)
        {
            AutorModel autorPorId = await BuscarPorId(id);


            if (autorPorId == null)
            {
                throw new Exception($"O id: {id} não existe");
            }

            autorPorId.Nome = autor.Nome;
            autorPorId.Nacionalidade = autor.Nacionalidade;
            autorPorId.DataNascimento = autor.DataNascimento;

            _dbContext.Autores.Update(autorPorId);
            await _dbContext.SaveChangesAsync();

            return autorPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            AutorModel autorPorId = await BuscarPorId(id);
            if (autorPorId == null)
            {
                throw new Exception($"O id: {id} não existe");
            }

            _dbContext.Autores.Remove(autorPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<AutorModel>> BuscarTodosAutores()
        {
            return await _dbContext.Autores.ToListAsync();
        }
    }
}
