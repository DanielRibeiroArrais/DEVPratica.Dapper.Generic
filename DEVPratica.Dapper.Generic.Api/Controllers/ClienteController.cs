using AutoMapper;
using DEVPratica.Dapper.Generic.Domain.Entities.Cliente;
using DEVPratica.Dapper.Generic.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DEVPratica.Dapper.Generic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IMapper mapper, ILogger<ClienteController> logger, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _clienteRepository = clienteRepository;
        }

        [HttpGet("obter-todos")]
        [ProducesResponseType(typeof(List<Cliente>), 200)]
        public async Task<IActionResult> ObterTodosAsync()
        {
            _logger.LogDebug($"Repo Cliente, Buscando dados da tabela Cliente");
            var result = _mapper.Map<List<Cliente>>(await _clienteRepository.ObterTodosAsync<Cliente>());
            _logger.LogInformation("Consulta finalizada");
            
            return CustomResponse(result.Any() ? result : new List<Cliente>());
        }

        [HttpGet("id/{id}/obter")]
        [ProducesResponseType(typeof(Cliente), 200)]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            _logger.LogInformation("Consulta iniciada");
            var result = await _clienteRepository.ObterPorIdAsync<Cliente>(id);
            _logger.LogInformation("Consulta finalizada");

            return CustomResponse(_mapper.Map<Cliente>(result));
        }
    }
}
