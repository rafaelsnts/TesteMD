using System.Collections.Generic;
using TesteMD.Domain.Models;

/// <summary>
/// Interface que define os métodos necessários para manipulação de dados de vendas.
/// </summary>
public interface IVendaRepository
{
    void AdicionarVenda(Venda venda);                
    Venda ObterVendaPorId(int vendaId);             
    List<Venda> ObterTodasVendas();
    Dictionary<string, int> ObterVendasMensais();
    Dictionary<string, int> ObterVendasSemanais();
}

