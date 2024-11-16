using System;

namespace TesteMD.Domain.Models
{
    /// <summary>
    /// Representa uma venda realizada no sistema, incluindo informações sobre o cliente, produto e valores.
    /// </summary>
    public class Venda
    {
        public int VendaId { get; set; } 
        public DateTime Data { get; set; } 
        public int ClienteId { get; set; } 
        public decimal ValorTotal { get; set; } 
        public int ProdutoId { get; set; } 
        public int Quantidade { get; set; } 
        public decimal PrecoUnitario { get; set; }

        // Relacionamento com Cliente e Produto
        public string Cliente { get; set; }
        public string Produto { get; set; }
    }
}
