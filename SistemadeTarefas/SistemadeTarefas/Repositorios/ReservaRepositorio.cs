using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;
using SistemadeTarefas.Repositorios.Interfaces;
using SistemaDeTarefas.Data;

namespace SistemadeTarefas.Repositorios
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;
        public ReservaRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }
        public async Task<ReservaModel> Adicionar(ReservaModel reserva)
        {
            await _dbContext.Reservas.AddAsync(reserva);
            await _dbContext.SaveChangesAsync();

            return reserva;
        }

        public async Task<ReservaModel> BuscarPorId(int id)
        {
            return await _dbContext.Reservas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReservaModel> Atualizar(ReservaModel reserva, int id)
        {
            ReservaModel reservaPorId = await BuscarPorId(id);


            if (reservaPorId == null)
            {
                throw new Exception($"Livro do ID: {id} não foi encontrado");
            }

            reservaPorId.DataReserva = reserva.DataReserva;
            reservaPorId.Status = reserva.Status;

            _dbContext.Reservas.Update(reservaPorId);
            await _dbContext.SaveChangesAsync();

            return reservaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ReservaModel reservaPorId = await BuscarPorId(id);
            if (reservaPorId == null)
            {
                throw new Exception($"Reserva do Id: {id} não foi encontrado");
            }

            _dbContext.Reservas.Remove(reservaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ReservaModel>> BuscarTodasReservas()
        {
            return await _dbContext.Reservas.ToListAsync();
        }
    }
}
