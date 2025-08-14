
using GestaoPedidosAPI.Services;
using GestaoPedidosAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly SolicitacaoService _solicitacaoService;

        public SolicitacaoController(SolicitacaoService solicitacaoService)
        {
            _solicitacaoService = solicitacaoService;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarSolicitacao([FromBody] Solicitacao solicitacao)
        {
            try
            {
                await _solicitacaoService.CriarSolicitacao(solicitacao);
                return Ok("Solicitação criada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("editar")]
        public async Task<IActionResult> EditarSolicitacao([FromBody] Solicitacao solicitacao)
        {
            try
            {
                await _solicitacaoService.EditarSolicitacao(solicitacao);
                return Ok("Solicitação editada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("inativar/{solicitacaoId}")]
        public async Task<IActionResult> InativarSolicitacao(int solicitacaoId)
        {
            try
            {
                await _solicitacaoService.InativarSolicitacao(solicitacaoId);
                return Ok("Solicitação inativada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ativar/{solicitacaoId}")]
        public async Task<IActionResult> AtivarSolicitacao(int solicitacaoId)
        {
            try
            {
                await _solicitacaoService.AtivarSolicitacao(solicitacaoId);
                return Ok("Solicitação ativada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
