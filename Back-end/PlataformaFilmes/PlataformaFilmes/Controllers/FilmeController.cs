using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaFilmes.Models;
using PlataformaFilmes.Repositories;

namespace PlataformaFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository;
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]
        /// <summary>
        /// Obtem todos os filmes presentes no banco de dados
        /// </summary>
        public IActionResult ObtemFilmes()
        {
            return Ok(_filmeRepository.ObterTodosFilmes());
        }
        /// <summary>
        /// Obtem o filme pelo id, com seus respectivos comentarios
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult ObtemPorid(int id)
        {
            var filme = _filmeRepository.ObtemFilmeId(id);
            if(filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        /// <summary>
        /// Obtem filmes pelo nome
        /// </summary>
        [HttpGet("busca/{nome}")]
        public IActionResult ObtemPeloNome(string nome)
        {
            var filme = _filmeRepository.ObtemPeloNome(nome);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        /// <summary>
        /// Inclui um filme no banco de dados
        /// </summary>
        [HttpPost]
        public IActionResult IncluiFilme([FromBody] IncluirFilmeModel filme)
        {
            _filmeRepository.IncluiFilme(filme);
            return Ok(filme);
        }

        /// <summary>
        /// Realiza a avaliacao de um filme
        /// </summary>
        [HttpPost("avaliacao")]
        public IActionResult IncluirAvaliacao([FromBody] IncluirAvaliacaoModel avaliacao)
        {
            _filmeRepository.IncluirAvaliacao(avaliacao);
            return Ok(avaliacao);
        }
    }
}
