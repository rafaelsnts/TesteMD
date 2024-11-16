using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TesteMD.Domain.Models;
using TesteMD.Infra.Repository;
using TesteMD.Infra.Services;

namespace TesteMD.Forms.Produtos
{
    public partial class form_CadastrarProduto : Form
    {
        private ProdutoService _produtoService;
        private form_ProdutoPrincipal formProdutoPrincipal = null;
        public form_CadastrarProduto(form_ProdutoPrincipal _formProdutoPrincipal)
        {
            InitializeComponent();
            _produtoService = new ProdutoService(new ProdutoRepository());
            formProdutoPrincipal = _formProdutoPrincipal;
        }

        public form_CadastrarProduto()
        {
            InitializeComponent();
            _produtoService = new ProdutoService(new ProdutoRepository());
        }

        private void LimparCampos()
        {
            txtNomeProduto.Text = "";
            txtDescricaoProduto.Text = "";
            txtPrecoUnitarioProduto.Text = "";
            updownQtdEstoque.Value = 0;
            txtCodBarrasProduto.Text = "";
            dtpDataCadastro.Value = DateTime.Now;
        }

        private bool IsCamposProdutoPreenchidos()
        {
            if (string.IsNullOrEmpty(txtNomeProduto.Text))
            {
                MessageBox.Show("O nome do produto é obrigatório.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtPrecoUnitarioProduto.Text))
            {
                MessageBox.Show("O preço do produto é obrigatório.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtPrecoUnitarioProduto.Text))
            {
                MessageBox.Show("O preço do produto é obrigatório.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsCamposProdutoPreenchidos() == true)
                {
                    var produto = new Produto
                    {
                        NomeProduto = txtNomeProduto.Text,
                        Descricao = txtDescricaoProduto.Text,
                        PrecoUnitario = Convert.ToDecimal(txtPrecoUnitarioProduto.Text.Replace("R$ ", ""), CultureInfo.CurrentCulture),
                        QuantidadeEstoque = Convert.ToInt32(updownQtdEstoque.Value),
                        CodigoBarras = txtCodBarrasProduto.Text,
                        DataCadastro = dtpDataCadastro.Value
                    };

                    _produtoService.AdicionarProduto(produto);

                    AtualizarTabelaProdutosFormPrincipal();

                    MessageBox.Show("Produto cadastrado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTabelaProdutosFormPrincipal()
        {
            if (formProdutoPrincipal != null)
                formProdutoPrincipal.PreencherGridProdutos();
        }
        private void txtPrecoUnitarioProduto_TextChanged(object sender, EventArgs e)
        {
            FormatarPrecoUnitario(sender);
        }

        private void FormatarPrecoUnitario(object sender)
        {
            TextBox txt = sender as TextBox;

            if (string.IsNullOrEmpty(txt.Text))
            {
                txt.Text = "R$ 0.00";
                txt.SelectionStart = txt.Text.Length - 3;
                return;
            }

            string apenasDigitos = Regex.Replace(txt.Text, @"[^\d]", "");
            decimal valorDigitado = decimal.Parse(apenasDigitos);

            txt.Text = string.Format("R$ {0:N2}", valorDigitado / 100);
            txt.SelectionStart = txt.Text.Length;
        }
    }
}
