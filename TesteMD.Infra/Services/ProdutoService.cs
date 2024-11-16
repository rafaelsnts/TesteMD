using System;
using TesteMD.Domain.Interface;
using TesteMD.Domain.Models;

namespace TesteMD.Infra.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository produtoRepository;
        public ProdutoService(IProdutoRepository _produtoRepository)
        {
            this.produtoRepository = _produtoRepository;
        }

        /// <summary>
        /// Adiciona um novo produto ao sistema.
        /// </summary>
        /// <param name="_produto">Objeto do tipo Produto a ser adicionado.</param>
        public void AdicionarProduto(Produto _produto)
        {
            produtoRepository.Adicionar(_produto);
        }

        /// <summary>
        /// Atualiza os dados de um produto existente no sistema.
        /// Caso o produto não seja encontrado, uma exceção será lançada.
        /// </summary>
        /// <param name="_produto">Objeto do tipo Produto com os dados atualizados.</param>
        /// <exception cref="Exception">Lança uma exceção caso o ID do produto seja inválido.</exception>
        public void AtualizarProduto(Produto _produto)
        {
            if (_produto.ProdutoId <= 0)
            {
                throw new Exception("Produto não encontrado.");
            }
            
            produtoRepository.Atualizar(_produto);
        }

        /// <summary>
        /// Remove um produto do sistema com base no ID.
        /// Caso o ID seja inválido, uma exceção será lançada.
        /// </summary>
        /// <param name="_id">ID do produto a ser removido.</param>
        /// <exception cref="Exception">Lança uma exceção caso o ID do produto seja inválido.</exception>
        public void RemoverProduto(int _id)
        {
            if (_id <= 0)
            {
                throw new Exception("ID inválido.");
            }

            produtoRepository.RemoverProduto(_id);
        }

        /// <summary>
        /// Busca um produto pelo ID e retorna o objeto Produto correspondente.
        /// </summary>
        /// <param name="_id">ID do produto a ser buscado.</param>
        /// <returns>Objeto Produto correspondente ao ID fornecido.</returns>
        public Produto BuscarProdutoPorId(int _id)
        {
            return produtoRepository.BuscarPorId(_id);
        }

        /// <summary>
        /// Verifica se um produto está vinculado a alguma venda no sistema.
        /// </summary>
        /// <param name="produtoId">ID do produto a ser verificado.</param>
        /// <returns>Retorna true se o produto estiver vinculado a vendas, caso contrário, retorna false.</returns>
        public bool IsProdutoTemVendas(int produtoId)
        {
            return produtoRepository.IsProdutoPossuiVendas(produtoId);
        }


        public Produto BuscarProdutoPorNome(string _nome)
        {
            return produtoRepository.BuscarProdutoPorNome(_nome);
        }
    }
}
