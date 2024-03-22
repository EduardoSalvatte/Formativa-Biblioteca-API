using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;

namespace SistemadeTarefas.Data.Map
{
    public class AutorMap : IEntityTypeConfiguration<AutorModel>
    {
        public void Configure(EntityTypeBuilder<AutorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Nacionalidade).IsRequired().HasMaxLength(180);
            builder.Property(x => x.DataNascimento).IsRequired().HasMaxLength(180);
        }
    }
}
