namespace SistemadeTarefas.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}
