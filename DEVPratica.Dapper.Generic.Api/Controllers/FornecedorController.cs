using AutoMapper;
using DEVPratica.Dapper.Generic.Domain.Entities.Fornecedor;
using DEVPratica.Dapper.Generic.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DEVPratica.Dapper.Generic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<FornecedorController> _logger;
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(IMapper mapper, ILogger<FornecedorController> logger, IFornecedorRepository fornecedorRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet("obter-todos")]
        [ProducesResponseType(typeof(List<Fornecedor>), 200)]
        public async Task<IActionResult> ObterTodosAsync()
        {
            _logger.LogDebug($"Repo Fornecedor, Buscando dados da tabela Fornecedor");
            var result = _mapper.Map<List<Fornecedor>>(await _fornecedorRepository.ObterTodosAsync<Fornecedor>());
            _logger.LogInformation("Consulta finalizada");

            return CustomResponse(result.Any() ? result : new List<Fornecedor>());
        }

        [HttpGet("id/{id}/obter")]
        [ProducesResponseType(typeof(Fornecedor), 200)]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            _logger.LogInformation("Consulta iniciada");
            var result = await _fornecedorRepository.ObterPorIdAsync<Fornecedor>(id);
            _logger.LogInformation("Consulta finalizada");

            return CustomResponse(_mapper.Map<Fornecedor>(result));
        }
    }
}
