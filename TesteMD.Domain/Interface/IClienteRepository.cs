using System.Collections.Generic;
using TesteMD.Domain.Models;

namespace TesteMD.Domain.Interface
{

    /// <summary>
    /// Interface que define os métodos necessários para manipulação de dados de clientes.
    /// </summary>
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(int id);
        Cliente BuscarPorId(int id);
        List<Cliente> BuscarTodos();

        bool IsClienteVinculadoAVendas(int clienteId);
    }
}
