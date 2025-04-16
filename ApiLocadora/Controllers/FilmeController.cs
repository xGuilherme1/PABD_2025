using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;
using ApiLocadora.Models;
using ApiLocadora.DbContext;

namespace ApiLocadora.Controllers
{
    [Route("filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Buscar()
        {
            var filmes = FilmeDbContext.Filmes.Select(f => new
            {
                f.Id,
                f.Titulo,
                f.AnoLancamento,
                f.Diretor,
                f.Avaliacao,
                Genero = f.Genero?.Nome,
                Estudio = f.Estudio?.Nome
            });

            return Ok(filmes);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] FilmeDto item)
        {

            var genero = FilmeDbContext.Generos.FirstOrDefault(g => g.Id == item.GeneroId);
            var estudio = FilmeDbContext.Estudios.FirstOrDefault(e => e.Id == item.EstudioId);

            if (genero == null || estudio == null)
            {
                return BadRequest("Gênero ou estúdio não encontrado.");
            }

            var novoFilme = new Filme()
            {
                Titulo = item.Titulo,
                AnoLancamento = item.AnoLancamento,
                Diretor = item.Diretor,
                Avaliacao = item.Avaliacao,
                GeneroId = genero.Id,
                Genero = genero,
                EstudioId = estudio.Id,
                Estudio = estudio
            };

            FilmeDbContext.Filmes.Add(novoFilme);

            return Ok(novoFilme);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] FilmeDto item)
        {
            var filme = FilmeDbContext.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
                return NotFound();

            var genero = FilmeDbContext.Generos.FirstOrDefault(g => g.Id == item.GeneroId);
            var estudio = FilmeDbContext.Estudios.FirstOrDefault(e => e.Id == item.EstudioId);

            if (genero == null || estudio == null)
            {
                return BadRequest("Gênero ou estúdio não encontrado.");
            }

            filme.Titulo = item.Titulo;
            filme.AnoLancamento = item.AnoLancamento;
            filme.Diretor = item.Diretor;
            filme.Avaliacao = item.Avaliacao;
            filme.GeneroId = genero.Id;
            filme.Genero = genero;
            filme.EstudioId = estudio.Id;
            filme.Estudio = estudio;

            return Ok(filme);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            var filme = FilmeDbContext.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme == null)
                return NotFound("Filme não encontrado.");

            FilmeDbContext.Filmes.Remove(filme);
            return NoContent();
        }
    }
}