namespace ApiLocadora.Models
{
    public class Filme
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Titulo { get; set; }

        public int AnoLancamento { get; set; }

        public string Diretor { get; set; }

        public double Avaliacao { get; set; }

        public Guid GeneroId { get; set; }
        public Genero Genero { get; set; }

        public Guid EstudioId { get; set; }
        public Estudio Estudio { get; set; }
    }
}