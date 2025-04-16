using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;
using ApiLocadora.Models;
using ApiLocadora.DbContext;

namespace ApiLocadora.Controllers
{
    [Route("generos")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        [HttpGet]
        public IActionResult Buscar()
        {
            return Ok(GeneroDbContext.Generos);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] GeneroDto item)
        {
            var novoGenero = new Genero()
            {
                Nome = item.Nome
            };

            GeneroDbContext.Generos.Add(novoGenero);

            return Ok(novoGenero);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] GeneroDto item)
        {
            var genero = GeneroDbContext.Generos.FirstOrDefault(f => f.Id == id);

            if (genero == null)
                return NotFound();

            genero.Nome = item.Nome;

            return Ok(genero);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            var genero = GeneroDbContext.Generos.FirstOrDefault(f => f.Id == id);

            if (genero == null)
                return NotFound();

            GeneroDbContext.Generos.Remove(genero);
            return NoContent();
        }
    }
}
