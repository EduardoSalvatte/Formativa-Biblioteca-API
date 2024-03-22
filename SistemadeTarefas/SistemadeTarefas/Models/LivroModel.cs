
namespace SistemadeTarefas.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int AnoPublicacao { get; set; }
        public int ISBN { get; set; }
        public string Sinopse { get; set; }
    }
}
