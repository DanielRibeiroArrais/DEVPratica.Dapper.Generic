using AutoMapper;
using DEVPratica.Dapper.Generic.Domain.Entities.Fornecedor;
using DEVPratica.Dapper.Generic.Domain.Entities.Usuario;
using DEVPratica.Dapper.Generic.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DEVPratica.Dapper.Generic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IMapper mapper, ILogger<UsuarioController> logger, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("obter-todos")]
        [ProducesResponseType(typeof(List<Usuario>), 200)]
        public async Task<IActionResult> ObterTodosAsync()
        {
            _logger.LogDebug($"Repo Usuario, Buscando dados da tabela Usuario");
            var result = _mapper.Map<List<Usuario>>(await _usuarioRepository.ObterTodosAsync<Usuario>());
            _logger.LogInformation("Consulta finalizada");

            return CustomResponse(result.Any() ? result : new List<Fornecedor>());
        }

        [HttpGet("id/{id}/obter")]
        [ProducesResponseType(typeof(Usuario), 200)]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            _logger.LogInformation("Consulta iniciada");
            var result = await _usuarioRepository.ObterPorIdAsync<Usuario>(id);
            _logger.LogInformation("Consulta finalizada");

            return CustomResponse(_mapper.Map<Usuario>(result));
        }

        [HttpGet("nome/{nome}/obter-por-nome")]
        [ProducesResponseType(typeof(List<Usuario>), 200)]
        public async Task<IActionResult> ObterPorIdAsync(string nome)
        {
            _logger.LogInformation("Consulta iniciada");
            var result = _mapper.Map<List<Usuario>>(await _usuarioRepository.ObterUsuarioPorNomeAsync(nome));
            _logger.LogInformation("Consulta finalizada");

            return CustomResponse(result.Any() ? result : new List<Fornecedor>());
        }
    }
}
