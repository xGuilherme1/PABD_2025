using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Dtos
{
    public class FilmeDto
    {
        [Required]
        public required string Titulo { get; set; }

        [Required]
        public required int AnoLancamento { get; set; }

        [Required]
        public required string Diretor { get; set; }

        [Required]
        public required double Avaliacao { get; set; }

        [Required]
        public required Guid GeneroId { get; set; }

        [Required]
        public required Guid EstudioId { get; set; }
    }
}