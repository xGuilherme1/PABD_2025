using ApiLocadora.Models;

namespace ApiLocadora.DbContext
{
    public static class FilmeDbContext
    {
        public static List<Filme> Filmes { get; set; } = new List<Filme>
        {
            new Filme
            {
                Titulo = "Velozes e Furiosos",
                AnoLancamento = 2001,
                Diretor = "Rob Cohen",
                Avaliacao = 7.2
            },
            new Filme
            {
                Titulo = "Velozes e Furiosos 2",
                AnoLancamento = 2003,
                Diretor = "John Singleton",
                Avaliacao = 6.5
            }
        };

        public static List<Genero> Generos { get; set; } = new List<Genero>
        {
            new Genero 
            { 
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), 
                Nome = "Ação" 
            }
        };

        public static List<Estudio> Estudios { get; set; } = new List<Estudio>
        {
            new Estudio 
            { 
                Id = Guid.Parse("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 
                Nome = "Universal Pictures",
                Distribuidor = "Universal Pictures"
            },
        };
    }
}
