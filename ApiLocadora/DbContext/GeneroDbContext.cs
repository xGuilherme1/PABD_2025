using ApiLocadora.Models;

namespace ApiLocadora.DbContext
{
    public class GeneroDbContext
    {
        public static List<Genero> Generos { get; set; } = new List<Genero>
        { 
            new Genero
            {
                Nome = "Acao"
            }
        };
    }
}
