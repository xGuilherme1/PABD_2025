using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;
using ApiLocadora.Models;
using ApiLocadora.DbContext;

namespace ApiLocadora.Controllers
{
    [Route("estudios")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Buscar()
        {
            return Ok(EstudioDbContext.Estudios);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] EstudioDto item)
        {
            var novoEstudio = new Estudio()
            {
                Nome = item.Nome,
                Distribuidor = item.Distribuidor
            };

            EstudioDbContext.Estudios.Add(novoEstudio);

            return Ok(novoEstudio);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] EstudioDto item)
        {
            var estudio = EstudioDbContext.Estudios.FirstOrDefault(f => f.Id == id);

            if (estudio == null)
                return NotFound();

            estudio.Nome = item.Nome;
            estudio.Distribuidor = item.Distribuidor;

            return Ok(estudio);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            var estudio = EstudioDbContext.Estudios.FirstOrDefault(f => f.Id == id);

            if (estudio == null)
                return NotFound();

            EstudioDbContext.Estudios.Remove(estudio);
            return NoContent();
        }
    }
}
