using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Models;

namespace SistemadeTarefas.Data.Map
{
    public class AvaliacaoMap : IEntityTypeConfiguration<AvaliacaoModel>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LivroId).IsRequired().HasMaxLength(180);
            builder.HasOne(x => x.Livro);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(180);
            builder.HasOne(x => x.Usuario);
            builder.Property(x => x.Pontuacao).IsRequired().HasMaxLength(180);
            builder.Property(x => x.Comentario).IsRequired().HasMaxLength(180);
            builder.Property(x => x.DataAvaliacao).IsRequired().HasMaxLength(180);
            builder.Property(x => x.DataAvaliacao).IsRequired().HasMaxLength(180);
        }
    }
}
