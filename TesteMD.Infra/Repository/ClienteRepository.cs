using System;
using System.Collections.Generic;
using Npgsql;
using TesteMD.Domain.Data;
using TesteMD.Domain.Interface;
using TesteMD.Domain.Models;

namespace TesteMD.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DatabaseConnection conexao;

        public ClienteRepository()
        {
            conexao = new DatabaseConnection();
        }

        /// <summary>
        /// Adiciona um novo cliente ao banco de dados.
        /// </summary>
        /// <param name="cliente">Objeto contendo os dados do cliente a ser adicionado.</param>
        public void Adicionar(Cliente cliente)
        {
            var query = $"INSERT INTO tb_clientes (cl_nome, cl_rua, cl_telefone, cl_email, cl_data_cadastro, cl_cep, cl_bairro, cl_cidade, cl_numero, cl_estado ) " +
                        $"VALUES (@nomeCliente, @rua, @telefone, @email, @dataCadastro, @cep, @bairro, @cidade, @numero, @estado)";

            using (var conn = conexao.Conectar())
            {
                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomeCliente", cliente.Nome);
                cmd.Parameters.AddWithValue("@rua", cliente.Rua);
                cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@dataCadastro", cliente.DataCadastro);
                cmd.Parameters.AddWithValue("@cep", cliente.Cep);
                cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
                cmd.Parameters.AddWithValue("@numero", cliente.Numero);
                cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Atualiza as informações de um cliente existente no banco de dados.
        /// </summary>
        /// <param name="cliente">Objeto contendo os dados atualizados do cliente.</param>
        public void Atualizar(Cliente cliente)
        {
            var query = $"UPDATE tb_clientes SET " +
                        $"cl_nome = @nomeCliente, cl_rua = @rua, " +
                        $"cl_telefone = @telefone, cl_email = @email," +
                        $"cl_data_cadastro = @dataCadastro," +
                        "cl_cep = @cep, " + "cl_bairro = @bairro, " +
                        "cl_cidade = @cidade, " + "cl_numero = @numero, " +
                        "cl_estado = @estado" +
                        $" WHERE cl_id = @id";

            using (var conn = conexao.Conectar())
            {
                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomeCliente", cliente.Nome);
                cmd.Parameters.AddWithValue("@rua", cliente.Rua);
                cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@dataCadastro", cliente.DataCadastro);
                cmd.Parameters.AddWithValue("@cep", cliente.Cep);
                cmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                cmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
                cmd.Parameters.AddWithValue("@numero", cliente.Numero);
                cmd.Parameters.AddWithValue("@estado", cliente.Estado);
                cmd.Parameters.AddWithValue("@id", cliente.Id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Remove um cliente do banco de dados com base no ID.
        /// </summary>
        /// <param name="id">ID do cliente a ser removido.</param>
        public void Remover(int id)
        {
            var query = $"DELETE FROM tb_clientes WHERE cl_id = @id";

            using (var conn = conexao.Conectar())
            {
                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Busca um cliente no banco de dados pelo ID.
        /// </summary>
        /// <param name="id">ID do cliente a ser buscado.</param>
        /// <returns>Objeto Cliente com os dados do cliente ou null caso não encontrado.</returns>
        public Cliente BuscarPorId(int id)
        {
            var query = $"SELECT cl_id, cl_nome, cl_rua, cl_telefone, cl_email, cl_data_cadastro," +
                        $" cl_cep, cl_bairro, cl_cidade, cl_numero, cl_estado " +
                        $"FROM tb_clientes WHERE cl_id = @id";

            using (var conn = conexao.Conectar())
            {
                var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Cliente
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Rua = reader.GetValue(2).ToString() == "" ? "----" : reader.GetValue(2).ToString(),
                        Telefone = reader.GetValue(3).ToString() == "" ? "----" : reader.GetValue(3).ToString(),
                        Email = reader.GetString(4),
                        DataCadastro = reader.GetDateTime(5),
                        Cep = reader.GetValue(6).ToString() == "" ? "----" : reader.GetValue(6).ToString(),
                        Bairro = reader.GetValue(7).ToString() == "" ? "----" : reader.GetValue(7).ToString(),
                        Cidade = reader.GetValue(8).ToString() == "" ? "----" : reader.GetValue(8).ToString(),
                        Numero = reader.GetValue(9).ToString() == "" ? "----" : reader.GetValue(9).ToString(),
                        Estado = reader.GetValue(10).ToString() == "" ? "----" : reader.GetValue(10).ToString(),

                    };
                }
                return null;
            }
        }

        /// <summary>
        /// Busca todos os clientes cadastrados no banco de dados.
        /// </summary>
        /// <returns>Lista de objetos Cliente.</returns>
        public List<Cliente> BuscarTodos()
        {
            var clientes = new List<Cliente>();

            try
            {
                using (var conn = conexao.Conectar())
                {
                    const string query = "SELECT cl_id, cl_nome, cl_rua, cl_telefone, cl_email, cl_data_cadastro," +
                                         " cl_cep, cl_bairro, cl_cidade, cl_numero, cl_estado" +
                                         " FROM tb_clientes";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientes.Add(new Cliente
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("cl_id")),
                                    Nome = reader.GetString(1),
                                    Rua = reader.GetValue(2).ToString() == "" ? "----" : reader.GetValue(2).ToString(),
                                    Telefone = reader.GetValue(3).ToString() == "" ? "----" : reader.GetValue(3).ToString(),
                                    Email = reader.GetString(4),
                                    DataCadastro = reader.GetDateTime(5),
                                    Cep = reader.GetValue(6).ToString() == "" ? "----" : reader.GetValue(6).ToString(),
                                    Bairro = reader.GetValue(7).ToString() == "" ? "----" : reader.GetValue(7).ToString(),
                                    Cidade = reader.GetValue(8).ToString() == "" ? "----" : reader.GetValue(8).ToString(),
                                    Numero = reader.GetValue(9).ToString() == "" ? "----" : reader.GetValue(9).ToString(),
                                    Estado = reader.GetValue(10).ToString() == "" ? "----" : reader.GetValue(10).ToString(),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao buscar todos os clientes: {ex.Message}");
                throw;
            }

            return clientes;
        }

        /// <summary>
        /// Verifica se um cliente está vinculado a alguma venda.
        /// </summary>
        /// <param name="clienteId">ID do cliente a ser verificado.</param>
        /// <returns>True se o cliente estiver vinculado a uma venda, caso contrário, false.</returns>
        public bool IsClienteVinculadoAVendas(int clienteId)
        {
            using (var conn = conexao.Conectar())
            {
                var query = "SELECT COUNT(*) FROM tb_vendas WHERE ven_fk_id_cliente = @clienteId";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

    }
}
