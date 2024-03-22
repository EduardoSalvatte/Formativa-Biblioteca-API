 namespace SistemadeTarefas.Models
{
    public class AvaliacaoModel
    {
        public int Id { get; set; }
        public int Pontuacao { get; set; }
        public string Comentario { get; set; }
        public DateOnly DataAvaliacao { get; set; }
        public int LivroId { get; set; }
        public LivroModel? Livro { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
