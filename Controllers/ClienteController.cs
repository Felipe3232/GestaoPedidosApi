
using GestaoPedidosAPI.Services;
using GestaoPedidosAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using GestaoPedidosAPI.Data.Repository;

namespace GestaoPedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly ClienteRepository _clienteRepository;

        public ClienteController(ClienteService clienteService, ClienteRepository clienteRepository)
        {
            _clienteService = clienteService;
            _clienteRepository = clienteRepository;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> ObterPeloId(int id)
        {
            try
            {
                var entity = await _clienteRepository.ObterPeloIdAsync(id);
                if (entity == null)
                    return NotFound($"Não foi possível encontrar a entidade com o ID {id}.");

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listagem")]
        public async Task<ActionResult<IEnumerable<Cliente>>> ObterListagem()
        {
            try
            {
                var list = await _clienteRepository.ObterListagem();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarCliente([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteService.CriarCliente(cliente);
                return Ok("Cliente criado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("editar")]
        public async Task<IActionResult> EditarCliente([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteService.EditarCliente(cliente);
                return Ok("Cliente editado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("inativar/{clienteId}")]
        public async Task<IActionResult> InativarCliente(int clienteId)
        {
            try
            {
                await _clienteService.InativarCliente(clienteId);
                return Ok("Cliente inativado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ativar/{clienteId}")]
        public async Task<IActionResult> AtivarCliente(int clienteId)
        {
            try
            {
                await _clienteService.AtivarCliente(clienteId);
                return Ok("Cliente ativado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
