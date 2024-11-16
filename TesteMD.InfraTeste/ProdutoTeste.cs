using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aplicacao;
using TesteMD.Domain.Models;

namespace TesteMD.InfraTeste
{
    [TestClass]
    public class ProdutoTeste

    {
        [TestMethod]
        public void AdicionarProdutoSucesso()
        {

            AplicacaoProcess aplicacaoProcess = new AplicacaoProcess();

            bool produtoAdicionado = aplicacaoProcess.InserirProdutoTeste();

            Assert.IsTrue(produtoAdicionado);
        }

        [TestMethod]
        public void TestarDeletarProdutoPorID()
        {
            var context = new AplicacaoProcess();

            Produto produto = new Produto();
            produto.NomeProduto = "TESTE PRODUTO";
            produto.Descricao = "Descrição do produto 1";
            produto.PrecoUnitario = 10.00M;
            produto.QuantidadeEstoque = 10;
            produto.CodigoBarras = "123456789";
            produto.DataCadastro = DateTime.Now;

            context.produtoService().AdicionarProduto(produto);
            var produtoRecemAdicionado = context.produtoService().BuscarProdutoPorNome("TESTE PRODUTO");

            context.produtoService().RemoverProduto(produtoRecemAdicionado.ProdutoId);

            Assert.IsNull(context.produtoService().BuscarProdutoPorId(produtoRecemAdicionado.ProdutoId));
        }
    }
}
