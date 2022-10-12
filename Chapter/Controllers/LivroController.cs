using Chapter.Models;
using Chapter.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;
        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(_livroRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Livro LivroNovo)
        {
            try
            {
                _livroRepository.Cadastrar(LivroNovo);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);

                return Ok("Livro deletado");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpPut ("{id}")]
        public IActionResult Alterar (int id, Livro livro)
        {
            try
            {
                _livroRepository.Alterar(id, livro);

                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
