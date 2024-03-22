using SistemadeTarefas.Enums;

namespace SistemadeTarefas.Models
{
    public class EmprestimoModel
    {
        public int Id { get; set; }
        public DateOnly DataEmprestimo { get; set; }
        public DateOnly DataDevolucao { get; set; }
        public StatusEmprestimo? Status { get; set; }
        public int LivroId { get; set; }
        public LivroModel? Livro { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }

    }
}
