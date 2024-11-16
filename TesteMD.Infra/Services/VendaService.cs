using System.Collections.Generic;
using TesteMD.Domain.Models;

namespace TesteMD.Infra.Services
{
    public class VendaService
    {
        private readonly IVendaRepository vendaRepository;

        public VendaService(IVendaRepository _vendaRepository)
        {
            this.vendaRepository = _vendaRepository;
        }

        /// <summary>
        /// Obtém o total de vendas mensais do banco de dados, agrupando-as por mês.
        /// </summary>
        /// <returns>Um dicionário com os nomes dos meses como chave e o total de vendas como valor.</returns>
        public Dictionary<string, int> ObterVendasMensais()
        {
            return vendaRepository.ObterVendasMensais();
        }

        /// <summary>
        /// Obtém o total de vendas semanais do banco de dados, agrupando-as por dia da semana.
        /// </summary>
        /// <returns>Um dicionário com os dias da semana como chave e o total de vendas como valor.</returns>
        public Dictionary<string, int> ObterVendasSemanais()
        {
            return vendaRepository.ObterVendasSemanais();
        }

        /// <summary>
        /// Realiza a venda no sistema, inserindo os dados da venda no banco de dados.
        /// </summary>
        /// <param name="_venda">Objeto da venda contendo todas as informações necessárias, como cliente, produto, quantidade, etc.</param>
        public void RealizarVenda(Venda _venda)
        {
            vendaRepository.AdicionarVenda(_venda);
        }
    }
}