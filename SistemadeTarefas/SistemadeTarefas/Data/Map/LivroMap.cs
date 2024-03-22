using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;

namespace SistemadeTarefas.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<LivroModel>
    {
        public void Configure(EntityTypeBuilder<LivroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Genero).IsRequired().HasMaxLength(180);
            builder.Property(x => x.AnoPublicacao).IsRequired().HasMaxLength(180);
            builder.Property(x => x.ISBN).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Sinopse).IsRequired().HasMaxLength(180);
        }
    }
}
