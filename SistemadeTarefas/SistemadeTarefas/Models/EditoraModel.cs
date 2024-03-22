namespace SistemadeTarefas.Models
{
    public class EditoraModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public int AnoFundacao { get; set; }
        public virtual LivroModel? Livro { get; set; }
        public int? LivroId { get; set; }
    }
}
