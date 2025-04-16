using ApiLocadora.Models;

namespace ApiLocadora.DbContext
{
    public class EstudioDbContext
    {
        public static List<Estudio> Estudios { get; set; } = new List<Estudio> 
        { 
            new Estudio
            {
                Nome = "Universal Pictures",
                Distribuidor = "Universal Pictures"
            }
        };
    }
}
