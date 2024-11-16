using System;

namespace TesteMD.Domain.Models
{

    /// <summary>
    /// Representa um produto no sistema, contendo informações sobre o produto, preço e estoque.
    /// </summary>
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string CodigoBarras { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
