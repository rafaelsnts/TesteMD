using System;
using System.Windows.Forms;
using TesteMD.Domain.Interface;
using TesteMD.Domain.Models;
using TesteMD.Infra.Repository;

namespace TesteMD.Forms.Vendas
{
    public partial class form_BuscarProdutoManual : Form
    {
        public form_BuscarProdutoManual()
        {
            InitializeComponent();
            CarregarComboboxProdutos();
            ZerarSelecaoCombobox();
        }

        /// <summary>
        /// Zera a selação do combobox de produtos para que o evento SelectedIndexChanged não seja chamado
        /// </summary>
        private void ZerarSelecaoCombobox()
        {
            cmbProdutos.SelectedIndexChanged -= cmbProdutos_SelectedIndexChanged;
            cmbProdutos.SelectedIndex = -1;
            cmbProdutos.SelectedIndexChanged += cmbProdutos_SelectedIndexChanged;
        }

        /// <summary>
        /// Carrega os produtos do repository no ComboBox, definindo o nome como DisplayMember e o ID como ValueMember.
        /// </summary>
        private void CarregarComboboxProdutos()
        {
            IProdutoRepository _produtoRepository = new ProdutoRepository();

            try
            {
                var produtos = _produtoRepository.BuscarTodos();

                cmbProdutos.DataSource = produtos;
                cmbProdutos.DisplayMember = "NomeProduto";
                cmbProdutos.ValueMember = "ProdutoId";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CarregarInformacoesProdutoSelecionado();
        }

        /// <summary>
        /// Exibe as informações do produto selecionado no ComboBox nos campos apropriados.
        /// </summary>
        private void CarregarInformacoesProdutoSelecionado()
        {
            try
            {
                var produto = (Produto)cmbProdutos.SelectedItem;
                txtPrecoUnitarioProduto.Text = produto.PrecoUnitario.ToString();
                txtCodBarrasProduto.Text = produto.CodigoBarras;
                updownQtdEstoque.Value = Convert.ToDecimal(produto.QuantidadeEstoque);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao carregar informações do produto: {e.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento disparado ao alterar o produto selecionado no ComboBox, carregando as informações do produto.
        /// </summary>
        private void cmbProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarInformacoesProdutoSelecionado();
        }
    }
}
