using System.Collections.Generic;
using TesteMD.Domain.Models;

namespace TesteMD.Domain.Interface
{
    /// <summary>
    /// Interface que define os métodos necessários para manipulação de dados de produtos.
    /// </summary>
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void AtualizarEstoque(int produtoId, int quantidadeVendida);
        void RemoverProduto(int id);
        List<Produto> BuscarTodos();
        Produto BuscarPorId(int id);
        Produto BuscarPorCodigoBarras(string codigoBarras);
        bool IsProdutoPossuiVendas(int produtoId);
        Produto BuscarProdutoPorNome(string nomeProduto);

    }
}
