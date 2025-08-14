
using GestaoPedidosAPI.Services;
using GestaoPedidosAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtocoloController : ControllerBase
    {
        private readonly ProtocoloService _protocoloService;

        public ProtocoloController(ProtocoloService protocoloService)
        {
            _protocoloService = protocoloService;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarProtocolo([FromBody] Protocolo protocolo)
        {
            try
            {
                await _protocoloService.CriarProtocolo(protocolo);
                return Ok("Protocolo criado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("editar")]
        public async Task<IActionResult> EditarProtocolo([FromBody] Protocolo protocolo)
        {
            try
            {
                await _protocoloService.EditarProtocolo(protocolo);
                return Ok("Protocolo editado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("inativar/{protocoloId}")]
        public async Task<IActionResult> InativarProtocolo(int protocoloId)
        {
            try
            {
                await _protocoloService.InativarProtocolo(protocoloId);
                return Ok("Protocolo inativado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ativar/{protocoloId}")]
        public async Task<IActionResult> AtivarProtocolo(int protocoloId)
        {
            try
            {
                await _protocoloService.AtivarProtocolo(protocoloId);
                return Ok("Protocolo ativado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
