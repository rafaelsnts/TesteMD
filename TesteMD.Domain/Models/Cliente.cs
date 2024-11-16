using System;

namespace TesteMD.Domain.Models
{
    /// <summary>
    /// Representa um cliente no sistema, contendo informações pessoais e de contato.
    /// </summary>
    public class Cliente
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
    }
}
