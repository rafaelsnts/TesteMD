using Npgsql;
using System.Collections.Generic;
using TesteMD.Domain.Data;
using TesteMD.Domain.Models;

public class VendaRepository : IVendaRepository
{
    private readonly DatabaseConnection conexao;

    public VendaRepository()
    {
        conexao = new DatabaseConnection();
    }

    /// <summary>
    /// Adiciona uma nova venda no banco de dados.
    /// </summary>
    /// <param name="venda">Objeto do tipo Venda que será adicionado.</param>
    public void AdicionarVenda(Venda venda)
    {
        using (var conn = conexao.Conectar())
        {
            var query = @"
                INSERT INTO tb_vendas (ven_fk_id_cliente, ven_data, ven_valor_total, ven_fk_id_produto, ven_quantidade, ven_preco_unitario)
                VALUES (@ClienteId, @Data, @ValorTotal, @ProdutoId, @Quantidade, @PrecoUnitario)";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClienteId", venda.ClienteId);
                cmd.Parameters.AddWithValue("@Data", venda.Data);
                cmd.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                cmd.Parameters.AddWithValue("@ProdutoId", venda.ProdutoId);
                cmd.Parameters.AddWithValue("@Quantidade", venda.Quantidade);
                cmd.Parameters.AddWithValue("@PrecoUnitario", venda.PrecoUnitario);
                cmd.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// Retorna uma venda pelo ID.
    /// </summary>
    /// <param name="id">ID da venda a ser recuperada.</param>
    /// <returns>Objeto Venda correspondente ao ID fornecido ou null se não encontrado.</returns>
    public Venda ObterVendaPorId(int id)
    {
        using (var conn = conexao.Conectar())
        {
            var query = "SELECT * FROM tb_vendas WHERE ven_id = @VendaId";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@VendaId", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Venda
                        {
                            VendaId = reader.GetInt32(0),
                            Data = reader.GetDateTime(1),
                            ClienteId = reader.GetInt32(2),
                            ValorTotal = reader.GetDecimal(3),
                            ProdutoId = reader.GetInt32(4),
                            Quantidade = reader.GetInt32(5),
                            PrecoUnitario = reader.GetDecimal(6)
                        };
                    }
                }
            }
        }
        return null;
    }

    /// <summary>
    /// Retorna as vendas mensais do ano atual.
    /// </summary>
    /// <returns>Um dicionário com o mês e a quantidade total de vendas.</returns>
    public Dictionary<string, int> ObterVendasMensais()
    {
        var vendas = new Dictionary<string, int>();

        using (var conn = conexao.Conectar())
        {
            var query = @"
                SELECT TO_CHAR(ven_data, 'TMMonth') AS mes,
                       SUM(ven_quantidade) AS total_vendas
                FROM tb_vendas
                WHERE EXTRACT(YEAR FROM ven_data) = EXTRACT(YEAR FROM CURRENT_DATE)
                GROUP BY TO_CHAR(ven_data, 'TMMonth'), DATE_PART('month', ven_data)
                ORDER BY DATE_PART('month', ven_data);
                ";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vendas.Add(reader.GetString(0), reader.GetInt32(1));
                    }
                }
            }
        }
        return vendas;
    }

    /// <summary>
    /// Retorna as vendas semanais do ano atual.
    /// </summary>
    /// <returns>Um dicionário com o dia da semana e a quantidade total de vendas.</returns>
    public Dictionary<string, int> ObterVendasSemanais()
    {
        var vendas = new Dictionary<string, int>();

        using (var conn = conexao.Conectar())
        {
            var query = @"
                SELECT CASE DATE_PART('dow', ven_data)
                            WHEN 0 THEN 'Domingo'
                            WHEN 1 THEN 'Segunda-Feira'
                            WHEN 2 THEN 'Terça-Feira'
                            WHEN 3 THEN 'Quarta-Feira'
                            WHEN 4 THEN 'Quinta-Feira'
                            WHEN 5 THEN 'Sexta-Feira'
                            WHEN 6 THEN 'Sábado'
                       END AS dia_semana,
                       SUM(ven_quantidade) AS total_vendas
               FROM tb_vendas
               WHERE EXTRACT(YEAR FROM ven_data) = EXTRACT(YEAR FROM CURRENT_DATE)
               GROUP BY DATE_PART('dow', ven_data)
               ORDER BY DATE_PART('dow', ven_data);
               ";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vendas.Add(reader.GetString(0), reader.GetInt32(1));
                    }
                }
            }
        }
        return vendas;
    }

    /// <summary>
    /// Retorna todas as vendas registradas no banco de dados.
    /// </summary>
    /// <returns>Lista com todos os objetos Venda.</returns>
    public List<Venda> ObterTodasVendas()
    {
        var vendas = new List<Venda>();

        using (var conn = conexao.Conectar())
        {
            var query
                = $"SELECT v.*, c.cl_nome AS nome_cliente, " +
                  $"p.prd_nome AS nome_produto " +
                  $"FROM tb_vendas v " +
                  $"JOIN tb_clientes c " +
                  $"ON v.ven_fk_id_cliente = c.cl_id " +
                  $"JOIN tb_produtos p " +
                  $"ON v.ven_fk_id_produto = p.prd_id;";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vendas.Add(new Venda
                        {
                            VendaId = reader.GetInt32(0),
                            Data = reader.GetDateTime(1),
                            ClienteId = reader.GetInt32(2),
                            ValorTotal = reader.GetDecimal(3),
                            ProdutoId = reader.GetInt32(4),
                            Quantidade = reader.GetInt32(5),
                            PrecoUnitario = reader.GetDecimal(6),
                            Cliente = reader.GetString(7),  
                            Produto = reader.GetString(8)  
                        });
                    }
                }
            }
        }
        return vendas;
    }
}

