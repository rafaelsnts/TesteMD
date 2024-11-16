using System;
using TesteMD.Domain.Models;
using TesteMD.Infra.Repository;
using TesteMD.Infra.Services;

namespace Aplicacao
{
    public class TestesProcess 
    {
        public bool InserirProdutoTeste()
        {
            bool produtoAdicionado = false;    

            var produtoRecebe = produtoService().BuscarProdutoPorId(1);
            
            if(produtoRecebe != null)
            {
                var produto = new Produto
                {
                    NomeProduto = "Produto 1",
                    Descricao = "Descrição do produto 1",
                    PrecoUnitario = 10.00M,
                    QuantidadeEstoque = 10,
                    CodigoBarras = "123456789",
                    DataCadastro = DateTime.Now
                };

                produtoService().AdicionarProduto(produto);
                produtoAdicionado = true;
            }
            return produtoAdicionado;
        }

        public ProdutoService produtoService()
        {
            var produtoRepository = new ProdutoRepository();
            var produtoService = new ProdutoService(produtoRepository);
            return produtoService;
        }
    }
}
