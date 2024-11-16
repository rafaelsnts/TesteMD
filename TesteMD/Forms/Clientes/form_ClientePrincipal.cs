using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using TesteMD.Domain.Data;
using TesteMD.Infra.Repository;
using TesteMD.Infra.Services;

namespace TesteMD.Forms.Clientes
{
    public partial class form_ClientePrincipal : Form
    {
        public form_ClientePrincipal()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Configura as colunas do grid para exibir as informações dos clientes com cabeçalhos personalizados e visibilidade ajustada.
        /// </summary>
        private void ConfigurarDataGridViewClientes()
        {
            gridClientes.Columns["cl_id"].HeaderText = "ID";
            gridClientes.Columns["cl_id"].Visible = false;
            gridClientes.Columns["cl_data_cadastro"].HeaderText = "Data de Cadastro";
            gridClientes.Columns["cl_nome"].HeaderText = "Nome Cliente";
            gridClientes.Columns["cl_telefone"].HeaderText = "Telefone";
            gridClientes.Columns["cl_email"].HeaderText = "Email";
            gridClientes.Columns["cl_cep"].HeaderText = "Cep";
            gridClientes.Columns["cl_rua"].HeaderText = "Rua";
            gridClientes.Columns["cl_numero"].HeaderText = "Nº";
            gridClientes.Columns["cl_bairro"].HeaderText = "Bairro";
            gridClientes.Columns["cl_cidade"].HeaderText = "Cidade";
            gridClientes.Columns["cl_estado"].HeaderText = "Estado";
        }

        /// <summary>
        /// Preenche o grid com a lista de clientes do banco de dados, executando uma query para recuperar os dados.
        /// </summary>
        public void PreencherGridClientes()
        {
            var conexao = new DatabaseConnection();

            try
            {
                string sqlQuery = @"SELECT cl_id, cl_data_cadastro, cl_nome, cl_telefone, cl_email, cl_cep, cl_rua, cl_numero, cl_bairro, cl_cidade, cl_estado 
                                 FROM tb_clientes";
                using (var connection = conexao.Conectar())
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlQuery, connection))
                    {
                        if (connection != null)
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            gridClientes.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}");
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        /// <summary>
        /// Evento disparado ao carregar o formulário principal de clientes, preenchendo o grid e configurando suas colunas.
        /// </summary>
        private void form_ClientePrincipal_Load(object sender, System.EventArgs e)
        {
            PreencherGridClientes();
            ConfigurarDataGridViewClientes();
        }

        /// <summary>
        /// Evento para busca de cliente em tempo real enquanto o usuário digita, filtrando o grid pelo nome do cliente.
        /// </summary>
        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            CarregarTabelaPorNomeCliente(txtBuscarCliente.Text);
        }

        /// <summary>
        /// Carrega a tabela de clientes com base no nome fornecido, utilizando uma query com o nome parcial ou completo do cliente.
        /// </summary>
        private void CarregarTabelaPorNomeCliente(string _nomeCliente)
        {
            var conexao = new DatabaseConnection();

            try
            {
                string sqlQuery = $"SELECT cl_id, cl_data_cadastro, cl_nome, cl_telefone, cl_email, cl_cep, cl_rua, cl_numero, cl_bairro, cl_cidade, cl_estado " +
                                  $"FROM tb_clientes " +
                                  $"WHERE cl_nome ILIKE '%{_nomeCliente}%'";

                using (var connection = conexao.Conectar())
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlQuery, connection))
                    {
                        if (connection != null)
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            gridClientes.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao carregar clientes: {e.Message}");
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        /// <summary>
        /// Evento de clique do botão para editar informações do cliente. Obtém o ID do cliente selecionado e abre o formulário de edição.
        /// </summary>
        private void btnEditarInformacoesMenu_Click(object sender, EventArgs e)
        {
            try
            {
                var idLinhaSelecionada = gridClientes.CurrentRow.Cells["cl_id"].Value;
                int idCliente = Convert.ToInt32(idLinhaSelecionada);

                form_AlterarInformacoesCliente alterarInformacoesCliente = new form_AlterarInformacoesCliente(this);
                alterarInformacoesCliente.ClienteId = idCliente;
                alterarInformacoesCliente.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar informações do cliente: {ex.Message}");
            }
        }

        /// <summary>
        /// Evento de clique do botão para excluir o cliente selecionado. Verifica se o cliente está vinculado a uma venda antes de excluí-lo.
        /// </summary>
        private void btnExcluirClienteMenu_Click(object sender, EventArgs e)
        {
            ClienteService clienteService = new ClienteService(new ClienteRepository());
            try
            {
                var idLinhaSelecionada = gridClientes.CurrentRow.Cells["cl_id"].Value;
                int idCliente = Convert.ToInt32(idLinhaSelecionada);

                if (clienteService.IsClienteVinculadoAVendas(idCliente))
                {
                    MessageBox.Show("Não é possível excluir o cliente, pois ele está vinculado a uma venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var resultado = MessageBox.Show("Deseja realmente excluir o cliente selecionado?", "Excluir Cliente", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
               
                if (resultado == DialogResult.Yes)
                {
                    
                    clienteService.RemoverCliente(idCliente);
                    MessageBox.Show("Cliente excluído com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir cliente: {ex.Message}");
            }
            finally
            {
                PreencherGridClientes();
            }
        }
    }
}

