using GestaoPedidosAPI.Data.Repository;
using GestaoPedidosAPI.Domain;
using MySqlX.XDevAPI;

namespace GestaoPedidosAPI.Services
{
    public class ProtocoloService
    {
        private readonly ProtocoloRepository _protocoloRepository;

        public ProtocoloService(ProtocoloRepository protocoloRepository)
        {
            _protocoloRepository = protocoloRepository;
        }

        public async Task CriarProtocolo(Protocolo pedido)
        {
            await _protocoloRepository.InserirAsync(pedido);
        }

        public async Task EditarProtocolo(Protocolo pedido)
        {
            await _protocoloRepository.AlterarAsync(pedido);
        }

        public async Task InativarProtocolo(int pedidoId)
        {


            var pedido   = await _protocoloRepository.ObterPeloIdAsync(pedidoId);
            pedido.Inativar();

            await _protocoloRepository.AlterarAsync(pedido);
        }

        public async Task AtivarProtocolo(int pedidoId)
        {
            var pedido = await _protocoloRepository.ObterPeloIdAsync(pedidoId);
            pedido.Inativar();

            await _protocoloRepository.AlterarAsync(pedido);
        }

    }
}
