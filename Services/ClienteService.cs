using GestaoPedidosAPI.Data.Repository;
using GestaoPedidosAPI.Domain;
using MySqlX.XDevAPI;

namespace GestaoPedidosAPI.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task CriarCliente(Cliente cliente)
        {
  
            if(!Util.ValidarCPF(cliente.CPF))
                throw new ArgumentException("CPF inválido");

            await _clienteRepository.InserirAsync(cliente);
        }

        public async Task EditarCliente(Cliente cliente)
        {
            if (!Util.ValidarCPF(cliente.CPF))
                throw new ArgumentException("CPF inválido");

            await _clienteRepository.AlterarAsync(cliente);
        }

        public async Task InativarCliente(int clienteId)
        {
            var cliente = await _clienteRepository.ObterPeloIdAsync(clienteId);
            cliente.Inativar();

            await _clienteRepository.AlterarAsync(cliente);
        }

        public async Task AtivarCliente(int clienteId)
        {
            var cliente = await _clienteRepository.ObterPeloIdAsync(clienteId);
            cliente.Ativar();

            await _clienteRepository.AlterarAsync(cliente);
        }

    }
}
