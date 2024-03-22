using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemadeTarefas.Models;

namespace SistemadeTarefas.Data.Map
{
    public class ReservaMap : IEntityTypeConfiguration<ReservaModel>
    {
        public void Configure(EntityTypeBuilder<ReservaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataReserva).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(180);
            builder.HasOne(x => x.Livro);
            builder.HasOne(x => x.Usuario);
            builder.Property(x => x.LivroId);
            builder.Property(x => x.UsuarioId);
        }
    }
}
