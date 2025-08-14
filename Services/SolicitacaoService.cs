
using GestaoPedidosAPI.Data.Repository;
using GestaoPedidosAPI.Domain;
using MySqlX.XDevAPI;

namespace GestaoPedidosAPI.Services
{
    public class SolicitacaoService
    {
        private readonly SolicitacaoRepository _solicitacaoRepository;

        public SolicitacaoService(SolicitacaoRepository solicitacaoRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
        }

        public async Task CriarSolicitacao(Solicitacao solicitacao)
        {
            await _solicitacaoRepository.InserirAsync(solicitacao);
        }

        public async Task EditarSolicitacao(Solicitacao solicitacao)
        {
            await _solicitacaoRepository.AlterarAsync(solicitacao);
        }

        public async Task InativarSolicitacao(int solicitacaoId)
        {


            var solicitacao = await _solicitacaoRepository.ObterPeloIdAsync(solicitacaoId);
            solicitacao.Inativar();

            await _solicitacaoRepository.AlterarAsync(solicitacao);
        }

        public async Task AtivarSolicitacao(int solicitacaoId)
        {
            var solicitacao = await _solicitacaoRepository.ObterPeloIdAsync(solicitacaoId);
            solicitacao.Inativar();

            await _solicitacaoRepository.AlterarAsync(solicitacao);
        }

    }
}
