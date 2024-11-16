using System;
using System.Windows.Forms;
using TesteMD.Domain.Models;
using TesteMD.Infra.Repository;
using TesteMD.Infra.Services;

namespace TesteMD.Forms.Produtos
{
    public partial class form_AlterarInformacoesProduto : Form
    {
        private int _idProduto;
        private form_ProdutoPrincipal formProdutoPrincipal = null;
        private ProdutoService _produtoService;

        public int ProdutoId
        {
            get
            {
                return _idProduto;
            }
            set
            {
                _idProduto = value;
                CarregarDadosProdutoPorID();
            }
        }

        public form_AlterarInformacoesProduto(form_ProdutoPrincipal _formProdutoPrincipal)
        {

            InitializeComponent();
            _produtoService = new ProdutoService(new ProdutoRepository());
            formProdutoPrincipal = _formProdutoPrincipal;
        }

        public form_AlterarInformacoesProduto()
        {
            InitializeComponent();
            _produtoService = new ProdutoService(new ProdutoRepository());
        }

        private void CarregarDadosProdutoPorID()
        {
            var produto = new ProdutoService(new ProdutoRepository()).BuscarProdutoPorId(_idProduto);
            if (produto != null)
            {
                txtNomeProduto.Text = produto.NomeProduto;
                txtDescricaoProduto.Text = produto.Descricao;
                txtPrecoUnitarioProduto.Text = produto.PrecoUnitario.ToString();
                updownQtdEstoque.Value = produto.QuantidadeEstoque;
                txtCodBarrasProduto.Text = produto.CodigoBarras;
                dtpDataCadastro.Value = produto.DataCadastro;
            }
        }
        private void btnAtualizarInformacoesProduto_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNomeProduto.Text))
                {
                    MessageBox.Show("O nome do produto é obrigatório.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var produto = new Produto
                {
                    ProdutoId = _idProduto,
                    NomeProduto = txtNomeProduto.Text,
                    Descricao = txtDescricaoProduto.Text,
                    PrecoUnitario = Convert.ToDecimal(txtPrecoUnitarioProduto.Text),
                    QuantidadeEstoque = Convert.ToInt32(updownQtdEstoque.Value),
                    CodigoBarras = txtCodBarrasProduto.Text,
                    DataCadastro = dtpDataCadastro.Value
                };

                new ProdutoService(new ProdutoRepository()).AtualizarProduto(produto);

                AtualizarTabelaProdutosFormPrincipal();

                MessageBox.Show("Produto atualizado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar tabela de produtos: " + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarTabelaProdutosFormPrincipal()
        {
            if (formProdutoPrincipal != null)
                formProdutoPrincipal.PreencherGridProdutos();
        }
    }
}
