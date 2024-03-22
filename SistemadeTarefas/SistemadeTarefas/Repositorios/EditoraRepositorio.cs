using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repositorios.Interfaces;
using SistemaDeTarefas.Data;

namespace SistemadeTarefas.Repositorios
{
    public class EditoraRepositorio : IEditoraRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;
        public EditoraRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }
        public async Task<EditoraModel> Adicionar(EditoraModel editora)
        {
            await _dbContext.Editor.AddAsync(editora);
            await _dbContext.SaveChangesAsync();

            return editora;
        }

        public async Task<EditoraModel> BuscarPorId(int id)
        {
            return await _dbContext.Editor.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EditoraModel> Atualizar(EditoraModel editora, int id)
        {
            EditoraModel editoraPorId = await BuscarPorId(id);


            if (editoraPorId == null)
            {
                throw new Exception($"Avaliacao do ID: {id} não foi encontrado");
            }

            editoraPorId.Nome = editora.Nome;
            editoraPorId.Localizacao = editora.Localizacao;
            editoraPorId.AnoFundacao = editora.AnoFundacao;

            _dbContext.Editor.Update(editoraPorId);
            await _dbContext.SaveChangesAsync();

            return editoraPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            EditoraModel editoraPorId = await BuscarPorId(id);
            if (editoraPorId == null)
            {
                throw new Exception($"Editora do Id: {id} não foi encontrado");
            }

            _dbContext.Editor.Remove(editoraPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<EditoraModel>> BuscarTodasEditoras()
        {
            return await _dbContext.Editor.ToListAsync();
        }
    }
}
