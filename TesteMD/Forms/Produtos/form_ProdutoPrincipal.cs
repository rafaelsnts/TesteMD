using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using TesteMD.Domain.Data;
using TesteMD.Infra.Repository;
using TesteMD.Infra.Services;

namespace TesteMD.Forms.Produtos
{
    public partial class form_ProdutoPrincipal : Form
    {
        public form_ProdutoPrincipal()
        {
            InitializeComponent();
        }

        private void ConfigurarDataGridViewProdutos()
        {
            gridProdutos.Columns[0].HeaderText = "ID";
            gridProdutos.Columns[0].Visible = false;
            gridProdutos.Columns[1].HeaderText = "Data de Cadastro";
            gridProdutos.Columns[2].HeaderText = "Nome Produto";
            gridProdutos.Columns[3].HeaderText = "Descrição";
            gridProdutos.Columns[4].HeaderText = "Preço Unitário";
            gridProdutos.Columns[4].DefaultCellStyle.Format = "C";
            gridProdutos.Columns[5].HeaderText = "Qtd. em Estoque";
            gridProdutos.Columns[6].HeaderText = "Cód. de Barras";
            gridProdutos.Columns[6].Visible = false;
        }

        public void PreencherGridProdutos()
        {
            var conexao = new DatabaseConnection();

            try
            {
                string sqlQuery = @"SELECT prd_id, prd_data_cadastro, prd_nome, prd_descricao, prd_preco_unitario, prd_quantidade_estoque, prd_codigo_barras
                                FROM tb_produtos";
                using (var connection = conexao.Conectar())
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlQuery, connection))
                    {
                        if (connection != null)
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            gridProdutos.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}");
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        private void form_ProdutoPrincipal_Load(object sender, EventArgs e)
        {
            PreencherGridProdutos();
            ConfigurarDataGridViewProdutos();
        }

        private void btnEditarInformacoesMenu_Click(object sender, EventArgs e)
        {
            var idLinhaSelecionada = gridProdutos.CurrentRow.Cells["prd_id"].Value;
            int idProduto = Convert.ToInt32(idLinhaSelecionada);

            form_AlterarInformacoesProduto formAlterarInformacoesProduto = new form_AlterarInformacoesProduto(this);
            formAlterarInformacoesProduto.ProdutoId = idProduto;
            formAlterarInformacoesProduto.ShowDialog();
        }

        private void btnExcluirProdutoMenu_Click(object sender, EventArgs e)
        {
            ProdutoService produtoService = new ProdutoService(new ProdutoRepository());

            try
            {
                var idLinhaSelecionada = gridProdutos.CurrentRow.Cells["prd_id"].Value;
                int idProduto = Convert.ToInt32(idLinhaSelecionada);
              
                if (produtoService.IsProdutoTemVendas(idProduto))
                {
                    MessageBox.Show("Não é possível excluir o produto, pois ele está vinculado a uma venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                var resultado = MessageBox.Show("Deseja realmente excluir o produto selecionado?", "Excluir Produto", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    produtoService.RemoverProduto(idProduto);
                    MessageBox.Show("Produto excluído com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir produto: {ex.Message}");
            }
            finally
            {
                PreencherGridProdutos();
            }
        }

        /// <summary>
        /// Essa tabela faz a busca dos produtos de acordo com o nome do produto ou o codigo de barras
        /// </summary>
        /// <param name="_produto">texto digitado pelo usuario</param>
        private void CarregarTabelaBuscaProduto(string _produto)
        {
            var conexao = new DatabaseConnection();

            try
            {
                string sqlQuery = "SELECT prd_id, prd_nome, prd_descricao, prd_preco_unitario, prd_quantidade_estoque, prd_codigo_barras " +
                                  "FROM tb_produtos " +
                                  "WHERE prd_codigo_barras ILIKE @produto " +
                                  "OR prd_nome ILIKE @produto";

                using (var connection = conexao.Conectar())
                {
                    using (var cmd = new NpgsqlCommand(sqlQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@produto", $"%{_produto}%");
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            if (connection != null)
                            {
                                DataTable dt = new DataTable();
                                da.Fill(dt);
                                gridProdutos.DataSource = dt;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao carregar produtos: {e.Message}");
            }
            finally
            {
                conexao.Desconectar();
            }

        }
        private void txtBuscarProduto_TextChanged(object sender, EventArgs e)
        {
            CarregarTabelaBuscaProduto(txtBuscarProduto.Text);
        }
    }
}



