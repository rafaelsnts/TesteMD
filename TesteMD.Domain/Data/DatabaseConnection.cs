using System;
using System.Windows.Forms;
using Npgsql;

namespace TesteMD.Domain.Data
{
    public class DatabaseConnection
    {
        private NpgsqlConnection conexao;

        /// <summary>
        /// Estabelece uma conexão com o banco de dados PostgreSQL usando a string de conexão configurada.
        /// Caso a conexão seja bem-sucedida, retorna um objeto NpgsqlConnection.
        /// Caso contrário, exibe uma mensagem de erro e retorna null.
        /// </summary>
        /// <returns>Retorna um objeto NpgsqlConnection ou null em caso de erro.</returns>
        public NpgsqlConnection Conectar()
        {
            try
            {
                string host = "localhost";
                string username = "postgres";
                string password = "9173rafa";
                string database = "TesteMD";

                string conexaoString = $"Host={host};Username={username};Password={password};Database={database}";

                conexao = new NpgsqlConnection(conexaoString);
                conexao.Open();

                return conexao;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar com o banco de dados: {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// Desconecta a conexão aberta com o banco de dados PostgreSQL, se a conexão estiver ativa.
        /// Caso a conexão já esteja fechada ou não tenha sido estabelecida, exibe uma mensagem informando o estado.
        /// </summary>
        public void Desconectar()
        {
            try
            {
                if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                    MessageBox.Show("Conexão com o banco de dados PostgreSQL foi encerrada!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao desconectar do banco de dados. \n\n{ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
