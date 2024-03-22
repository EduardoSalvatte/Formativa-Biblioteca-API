using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;

namespace SistemadeTarefas.Data.Map
{
    public class EditoraMap : IEntityTypeConfiguration<EditoraModel>
    {
        public void Configure(EntityTypeBuilder<EditoraModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Livro);
            builder.Property(x => x.LivroId).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Localizacao).IsRequired().HasMaxLength(180);
            builder.Property(x => x.AnoFundacao).IsRequired().HasMaxLength(180);
        }
    }
}
