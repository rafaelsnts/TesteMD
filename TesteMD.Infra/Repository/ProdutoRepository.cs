using Npgsql;
using System;
using System.Collections.Generic;
using TesteMD.Domain.Data;
using TesteMD.Domain.Interface;
using TesteMD.Domain.Models;

namespace TesteMD.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DatabaseConnection conexao;

        public ProdutoRepository()
        {
            conexao = new DatabaseConnection();
        }

        /// <summary>
        /// Adiciona um novo produto no banco de dados.
        /// </summary>
        /// <param name="produto">Objeto do tipo Produto que será adicionado.</param>
        public void Adicionar(Produto produto)
        {
            var query = $"INSERT INTO tb_produtos (prd_nome, prd_descricao, prd_preco_unitario, prd_quantidade_estoque, prd_codigo_barras, prd_data_cadastro ) " +
                        $"VALUES (@nomeProduto, @descricao, @precoUnitario, @quantidadeEstoque, @codigoBarras, @dataCadastro)";

            using (var conn = conexao.Conectar())
            {
                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomeProduto", produto.NomeProduto);
                cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@precoUnitario", produto.PrecoUnitario);
                cmd.Parameters.AddWithValue("@quantidadeEstoque", produto.QuantidadeEstoque);
                cmd.Parameters.AddWithValue("@codigoBarras", produto.CodigoBarras);
                cmd.Parameters.AddWithValue("@dataCadastro", produto.DataCadastro);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Atualiza os dados de um produto existente no banco de dados.
        /// </summary>
        /// <param name="produto">Objeto Produto com os novos dados.</param>
        public void Atualizar(Produto produto)
        {
            var query = $"UPDATE tb_produtos SET " +
                        $"prd_nome = @nomeProduto, prd_descricao = @descricao, " +
                        $"prd_preco_unitario = @precoUnitario, prd_quantidade_estoque = @quantidadeEstoque, " +
                        $"prd_codigo_barras = @codigoBarras, prd_data_cadastro = @dataCadastro " +
                        $"WHERE prd_id = @id";

            using (var conn = conexao.Conectar())
            {
                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomeProduto", produto.NomeProduto);
                cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@precoUnitario", produto.PrecoUnitario);
                cmd.Parameters.AddWithValue("@quantidadeEstoque", produto.QuantidadeEstoque);
                cmd.Parameters.AddWithValue("@codigoBarras", produto.CodigoBarras);
                cmd.Parameters.AddWithValue("@dataCadastro", produto.DataCadastro);
                cmd.Parameters.AddWithValue("@id", produto.ProdutoId);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Busca um produto pelo ID no banco de dados.
        /// </summary>
        /// <param name="produtoId">ID do produto a ser buscado.</param>
        /// <returns>Objeto Produto correspondente ao ID fornecido ou null se não encontrado.</returns>
        public Produto BuscarPorId(int produtoId)
        {
            using (var conn = conexao.Conectar())
            {
                var query = @"SELECT prd_id, prd_nome, prd_descricao, prd_preco_unitario, prd_quantidade_estoque, prd_codigo_barras, prd_data_cadastro
                      FROM tb_produtos WHERE prd_id = @ProdutoId";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("ProdutoId", produtoId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Produto
                            {
                                ProdutoId = reader.GetInt32(0),
                                NomeProduto = reader.GetString(1),
                                Descricao = reader.GetString(2),
                                PrecoUnitario = reader.GetDecimal(3),
                                QuantidadeEstoque = reader.GetInt32(4),
                                CodigoBarras = reader.GetString(5),
                                DataCadastro = reader.GetDateTime(6)
                            };
                        }
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Busca um produto pelo código de barras no banco de dados.
        /// </summary>
        /// <param name="codigoBarras">Código de barras do produto a ser buscado.</param>
        /// <returns>Objeto Produto correspondente ao código de barras fornecido ou null se não encontrado.</returns>
        public Produto BuscarPorCodigoBarras(string codigoBarras)
        {
            var query = "SELECT * FROM tb_produtos WHERE prd_codigo_barras = @codigoBarras";
            using (var conn = conexao.Conectar())
            {
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("codigoBarras", codigoBarras);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Produto
                            {
                                ProdutoId = reader.GetInt32(0),
                                NomeProduto = reader.GetString(1),
                                Descricao = reader.GetString(2),
                                PrecoUnitario = reader.GetDecimal(3),
                                QuantidadeEstoque = reader.GetInt32(4),
                                CodigoBarras = reader.GetString(5),
                                DataCadastro = reader.GetDateTime(6)
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Atualiza o estoque de um produto após uma venda.
        /// </summary>
        /// <param name="produtoId">ID do produto cuja quantidade de estoque será atualizada.</param>
        /// <param name="quantidadeVendida">Quantidade vendida do produto.</param>
        public void AtualizarEstoque(int produtoId, int quantidadeVendida)
        {
            using (var conn = conexao.Conectar())
            {
                var query = "UPDATE tb_produtos SET prd_quantidade_estoque = prd_quantidade_estoque - @QuantidadeVendida WHERE prd_id = @ProdutoId";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProdutoId", produtoId);
                    cmd.Parameters.AddWithValue("@QuantidadeVendida", quantidadeVendida);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retorna todos os produtos cadastrados no banco de dados.
        /// </summary>
        /// <returns>Lista de objetos Produto.</returns>
        public List<Produto> BuscarTodos()
        {
            var produtos = new List<Produto>();

            using (var conn = conexao.Conectar())
            {
                var query = "SELECT * FROM tb_produtos";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            produtos.Add(new Produto
                            {
                                ProdutoId = reader.GetInt32(0),
                                NomeProduto = reader.GetString(1),
                                Descricao = reader.GetString(2),
                                PrecoUnitario = reader.GetDecimal(3),
                                QuantidadeEstoque = reader.GetInt32(4),
                                CodigoBarras = reader.GetString(5),
                                DataCadastro = reader.GetDateTime(6)
                            });
                        }
                    }
                }
            }
            return produtos;
        }


        /// <summary>
        /// Remove um produto do banco de dados.
        /// </summary>
        /// <param name="produtoId">ID do produto a ser removido.</param>
        public void RemoverProduto(int produtoId)
        {
            try
            {
                using (var conn = conexao.Conectar())
                {
                    var query = "DELETE FROM tb_produtos WHERE prd_id = @ProdutoId";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProdutoId", produtoId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// Verifica se um produto foi vendido anteriormente.
        /// </summary>
        /// <param name="produtoId">ID do produto a ser verificado.</param>
        /// <returns>True se o produto foi vendido, caso contrário, False.</returns>
        public bool IsProdutoPossuiVendas(int produtoId)
        {
            using (var conn = conexao.Conectar())
            {
                var query = "SELECT COUNT(*) FROM tb_vendas WHERE ven_fk_id_produto = @produtoId";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@produtoId", produtoId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }



        public Produto BuscarProdutoPorNome(string _nome)
        {
            using (var conn = conexao.Conectar())
            {
                var query = @"SELECT prd_id, prd_nome, prd_descricao, prd_preco_unitario, prd_quantidade_estoque, prd_codigo_barras, prd_data_cadastro
                      FROM tb_produtos WHERE prd_nome = @ProdutoNome";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("ProdutoNome", _nome);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Produto
                            {
                                ProdutoId = reader.GetInt32(0),
                                NomeProduto = reader.GetString(1),
                                Descricao = reader.GetString(2),
                                PrecoUnitario = reader.GetDecimal(3),
                                QuantidadeEstoque = reader.GetInt32(4),
                                CodigoBarras = reader.GetString(5),
                                DataCadastro = reader.GetDateTime(6)
                            };
                        }
                        return null;
                    }
                }
            }
        }
    }
}
