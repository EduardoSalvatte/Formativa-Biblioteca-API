using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repositorios.Interfaces;
using SistemaDeTarefas.Data;

namespace SistemadeTarefas.Repositorios
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;
        public EmprestimoRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }
        public async Task<EmprestimoModel> Adicionar(EmprestimoModel emprestimo)
        {
            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();

            return emprestimo;
        }

        public async Task<EmprestimoModel> BuscarPorId(int id)
        {
            return await _dbContext.Emprestimos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo, int id)
        {
            EmprestimoModel emprestimoPorId = await BuscarPorId(id);


            if (emprestimoPorId == null)
            {
                throw new Exception($"Avaliacao do ID: {id} não foi encontrado");
            }

            emprestimoPorId.DataEmprestimo = emprestimo.DataEmprestimo;
            emprestimoPorId.DataDevolucao = emprestimo.DataDevolucao;
            emprestimoPorId.Status = emprestimo.Status;

            _dbContext.Emprestimos.Update(emprestimoPorId);
            await _dbContext.SaveChangesAsync();

            return emprestimoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            EmprestimoModel emprestimoPorId = await BuscarPorId(id);
            if (emprestimoPorId == null)
            {
                throw new Exception($"Editora do Id: {id} não foi encontrado");
            }

            _dbContext.Emprestimos.Remove(emprestimoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<EmprestimoModel>> BuscarTodosEmprestimos()
        {
            return await _dbContext.Emprestimos.ToListAsync();
        }
    }
}
