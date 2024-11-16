using System;
using System.Windows.Forms;
using TesteMD.Forms.Clientes;
using TesteMD.Forms.Produtos;
using TesteMD.Forms.Relatórios;
using TesteMD.Forms.ReportView;
using TesteMD.Forms.Vendas;

namespace TesteMD.Forms._1___Principal
{
    public partial class form_MenuPrincipal : Form
    {
        Form formEmAberto = null;
        public form_MenuPrincipal()
        {
            InitializeComponent();
            CarregarFormPainelCentral(new form_GraficoVendasMenuInicial());
        }

        /// <summary>
        ///     Carrega o form dentro do panel do form principal, configura o novo form chamado dentro do panel
        /// e o ajusta para preencher todo o espaço do panel
        /// </summary>
        /// <param name="Form">Instância do formulário a ser carregado no painel central.</param>
        public void CarregarFormPainelCentral(object Form)
        {
            if (this.pnl_Inicio.Controls.Count > 0)
            {
                this.pnl_Inicio.Controls.RemoveAt(0);
            }
            Form form = Form as Form;
            formEmAberto = Form as Form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnl_Inicio.Controls.Add(form);
            form.Show();
        }
        /// <summary>
        /// Abre o formulário de cadastro de cliente como uma janela modal. 
        /// Se um formulário principal (`formEmAberto`) estiver ativo, ele é passado como referência 
        /// para o formulário de cadastro, caso contrário, o formulário de cadastro é instanciado sem parâmetros.
        /// </summary>
        /// <param name="sender">Objeto que disparou o evento.</param>
        /// <param name="e">Argumentos do evento.</param>
        private void novoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formEmAberto != null)
            {
                form_CadastrarCliente form_CadastrarCliente = new form_CadastrarCliente(formEmAberto as form_ClientePrincipal);
                form_CadastrarCliente.ShowDialog();
            }
            else
            {
                form_CadastrarCliente form_CadastrarCliente = new form_CadastrarCliente();
                form_CadastrarCliente.ShowDialog();
            }
            
        }

        private void exibirClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarFormPainelCentral(new form_ClientePrincipal());
        }

        private void exibirProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarFormPainelCentral(new form_ProdutoPrincipal());
        }

        private void novoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formEmAberto != null)
            {
                form_CadastrarProduto formCadastrarProduto = new form_CadastrarProduto(formEmAberto as form_ProdutoPrincipal);
                formCadastrarProduto.ShowDialog();
            }
            else
            {
                form_CadastrarProduto form_CadastrarCliente = new form_CadastrarProduto();
                form_CadastrarCliente.ShowDialog();
            }
        }

        private void btnPDV_Click(object sender, EventArgs e)
        {
            CarregarFormPainelCentral(new form_VendaPrincipal());
        }

        private void form_MenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                form_BuscarProdutoManual buscarProdutoManual = new form_BuscarProdutoManual();
                buscarProdutoManual.ShowDialog();
            }
        }

        private void inícioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregarFormPainelCentral(new form_GraficoVendasMenuInicial());
        }

        private void relatoriosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_RelatorioClientes formRelatorioClientes = new form_RelatorioClientes();
            formRelatorioClientes.ShowDialog();
        }

        private void relatorioEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_RelatorioEstoqueProdutos formRelatorioEstoque = new form_RelatorioEstoqueProdutos();
            formRelatorioEstoque.ShowDialog();
        }

        private void relatorioDeVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_RelatorioVendas formRelatorioVendas = new form_RelatorioVendas();
            formRelatorioVendas.ShowDialog();
        }
    }
}
