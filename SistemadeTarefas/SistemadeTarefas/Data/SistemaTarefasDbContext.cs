using Microsoft.EntityFrameworkCore;
using SistemadeTarefas.Data.Map;
using SistemadeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemaTarefasDbContext : DbContext
    {
        /* Criando nosso construtor */
        public SistemaTarefasDbContext(DbContextOptions<SistemaTarefasDbContext> options)
            : base(options)
        {
        }

        /* Criando nossos Dbs Sets */
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<AvaliacaoModel> Avaliacoes { get; set; }
        public DbSet<EditoraModel> Editor { get; set; }
        public DbSet<EmprestimoModel> Emprestimos { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<ReservaModel> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new AvaliacaoMap());
            modelBuilder.ApplyConfiguration(new EditoraMap());
            modelBuilder.ApplyConfiguration(new EmprestimoMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}