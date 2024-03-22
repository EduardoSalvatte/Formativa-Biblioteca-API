using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;

namespace SistemadeTarefas.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<EmprestimoModel>
    {
        public void Configure(EntityTypeBuilder<EmprestimoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Livro);
            builder.Property(x => x.LivroId).IsRequired().HasMaxLength(180);
            builder.HasOne(x => x.Usuario);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(180);
            builder.Property(x => x.DataEmprestimo).IsRequired().HasMaxLength(180);
            builder.Property(x => x.DataDevolucao).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
