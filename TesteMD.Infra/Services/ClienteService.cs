using System;
using TesteMD.Domain.Interface;
using TesteMD.Domain.Models;

namespace TesteMD.Infra.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository _clienteRepository)
        {
            this.clienteRepository = _clienteRepository;
        }


        /// <summary>
        /// Adiciona um novo cliente no sistema. 
        /// Se o nome do cliente não for fornecido, exibe uma mensagem de erro.
        /// </summary>
        /// <param name="_cliente">Objeto do tipo Cliente a ser adicionado.</param>
        public void AdicionarCliente(Cliente _cliente)
        {
            if (string.IsNullOrEmpty(_cliente.Nome))
            {
                throw new Exception("Nome do cliente não fornecido.");
            }

            clienteRepository.Adicionar(_cliente);
        }

        /// <summary>
        /// Atualiza os dados de um cliente existente no sistema.
        /// Se o cliente não for encontrado, exibe uma mensagem de erro.
        /// </summary>
        /// <param name="_cliente">Objeto do tipo Cliente com os dados atualizados.</param>
        public void AtualizarCliente(Cliente _cliente)
        {
            if (_cliente.Id <= 0)
            {
                throw new Exception("Cliente não encontrado.");
            }

            clienteRepository.Atualizar(_cliente);
        }

        /// <summary>
        /// Remove um cliente do sistema com base no ID.
        /// Se o ID for inválido, exibe uma mensagem de erro.
        /// </summary>
        /// <param name="_id">ID do cliente a ser removido.</param>
        public void RemoverCliente(int _id)
        {
            if (_id <= 0)
            {
                throw new Exception("ID inválido.");
            }

            clienteRepository.Remover(_id);
        }

        /// <summary>
        /// Busca um cliente pelo ID.
        /// </summary>
        /// <param name="_id">ID do cliente a ser buscado.</param>
        /// <returns>Objeto Cliente correspondente ao ID fornecido.</returns>
        public Cliente BuscarClientePorId(int _id)
        {
            return clienteRepository.BuscarPorId(_id);
        }

        /// <summary>
        /// Verifica se um cliente está vinculado a alguma venda.
        /// </summary>
        /// <param name="clienteId">ID do cliente a ser verificado.</param>
        /// <returns>Retorna true se o cliente estiver vinculado a vendas, caso contrário, false.</returns>
        public bool IsClienteVinculadoAVendas(int clienteId)
        {
            return clienteRepository.IsClienteVinculadoAVendas(clienteId);
        }
    }
}
