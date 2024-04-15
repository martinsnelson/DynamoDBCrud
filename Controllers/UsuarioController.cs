using DynamoDBCrud.Entity;
using DynamoDBCrud.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DynamoDBCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioRepository _repository;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos() 
        {
            string site = Request.Headers["site"];
            var lista = await _repository.Buscar(site);

            return Ok(lista);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> ObterPorEmail(string email)
        {
            string site = Request.Headers["site"];
            var lista = await _repository.Buscar(site, email);

            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(UsuarioEntity usuario)
        {
            await _repository.Adicionar(usuario);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(UsuarioEntity usuario) 
        {
            await _repository.Atualizar(usuario);

            return Ok();
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Deletar(string email)
        {
            string site = Request.Headers["site"];

            await _repository.Deletar(site, email);

            return Ok();
        }
    }
}