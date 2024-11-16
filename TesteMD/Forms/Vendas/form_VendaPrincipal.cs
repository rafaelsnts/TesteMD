using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TesteMD.Domain.Interface;
using TesteMD.Domain.Models;
using TesteMD.Infra.Repository;
using TesteMD.Infra.Services;

namespace TesteMD.Forms.Vendas
{
    public partial class form_VendaPrincipal : Form
    {
        IProdutoRepository _produtoRepository = new ProdutoRepository();
        IVendaRepository _vendaRepository = new VendaRepository();
        private VendaService _vendaService;

        BindingList<Venda> bindingListVendas;
        public form_VendaPrincipal()
        {
            InitializeComponent();
            PopularGridvendas();
            ConfigurarDataGridViewVendas();
            _vendaService = new VendaService(new VendaRepository());
        }

        /// <summary>
        /// Configura as colunas do grid de vendas, definindo a visibilidade e a ordem de exibição das colunas.
        /// </summary>
        private void ConfigurarDataGridViewVendas()
        {
            gridVendas.Columns["VendaId"].Visible = false;
            gridVendas.Columns["ClienteId"].Visible = false;
            gridVendas.Columns["ValorTotal"].Visible = false;
            gridVendas.Columns["ProdutoId"].Visible = false;
            gridVendas.Columns["Cliente"].Visible = false;

            gridVendas.Columns["Data"].DisplayIndex = 0;
            gridVendas.Columns["Produto"].DisplayIndex = 1;
            gridVendas.Columns["PrecoUnitario"].DisplayIndex = 2;
            gridVendas.Columns["Quantidade"].DisplayIndex = 3;
        }


        /// <summary>
        /// Inicializa a lista de vendas e define o BindingSource como fonte de dados do grid de vendas.
        /// </summary>
        private void PopularGridvendas()
        {
            bindingListVendas = new BindingList<Venda>();
            bindingSource1.DataSource = bindingListVendas;
            gridVendas.DataSource = bindingSource1;
            gridVendas.Refresh();
        }

        /// <summary>
        /// Carrega os clientes no ComboBox de clientes, exibindo uma mensagem de erro em caso de falha.
        /// </summary>
        private void CarregarClientesCombobox()
        {
            IClienteRepository _clienteRepository = new ClienteRepository();

            try
            {
                var clientes = _clienteRepository.BuscarTodos();

                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "Nome";
                cmbClientes.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carrega os clientes no ComboBox ao iniciar o formulário e limpa a seleção.
        /// </summary>
        private void form_VendaPrincipal_Load(object sender, EventArgs e)
        {
            CarregarClientesCombobox();
            cmbClientes.SelectedIndex = -1;
        }

        /// <summary>
        /// Valida se um cliente e um produto estão selecionados e exibe mensagens de erro se não estiverem selecionados.
        /// </summary>
        /// <returns>Retorna true se ambos estiverem selecionados, caso contrário, retorna false.</returns>
        private bool IsClienteEProdutoSelecionado()
        {

            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um cliente.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbClientes.Focus();
                return false;
            }
            if (txtCodigoBarras.Text == "")
            {
                MessageBox.Show("Selecione um produto!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Efetua a venda de todos os itens no grid, atualizando o estoque de cada produto.
        /// </summary>
        private void EfetuarVenda()
        {
            try
            {
                if (gridVendas.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum item na lista de vendas.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataGridViewRow row in gridVendas.Rows)
                {
                    Venda venda = new Venda();
                    venda.ClienteId = Convert.ToInt32((cmbClientes.SelectedItem as Cliente).Id);
                    venda.Data = DateTime.Now;
                    venda.ProdutoId = Convert.ToInt32(row.Cells["ProdutoId"].Value);
                    venda.Quantidade = Convert.ToInt32(row.Cells["Quantidade"].Value);
                    venda.PrecoUnitario = Convert.ToDecimal(row.Cells["PrecoUnitario"].Value);
                    venda.ValorTotal = venda.PrecoUnitario * venda.Quantidade;

                    _vendaService.RealizarVenda(venda);

                    AtualizarEstoqueProduto(venda);
                }

                MessageBox.Show("Venda efetuada com sucesso.", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTotalItens.Text = "R$ 0,00";
                bindingListVendas.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao efetuar venda: {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Atualiza o estoque de um produto após a venda, decrementando a quantidade de unidades.
        /// </summary>
        /// <param name="_venda">A venda que será processada, contendo informações do produto vendido.</param>  
        private void AtualizarEstoqueProduto(Venda _venda)
        {
            Produto produto = _produtoRepository.BuscarPorId(_venda.ProdutoId);
            produto.QuantidadeEstoque -= _venda.Quantidade;
            _produtoRepository.Atualizar(produto);
        }

        /// <summary>
        /// Evento acionado ao pressionar o botão de efetuar venda. Chama o método EfetuarVenda.
        /// </summary>
        private void btnEfetuarVenda_Click(object sender, EventArgs e)
        {
            EfetuarVenda();
        }

        /// <summary>
        /// Valida se o produto digitado é válido, exibindo uma mensagem de erro se não for encontrado.
        /// </summary>
        /// <param name="produtoDigitado">Produto a ser validado.</param>
        /// <returns>Retorna true se o produto for válido, caso contrário, retorna false.</returns>
        private bool IsProdutoValido(Produto produtoDigitado)
        {
            if (produtoDigitado == null)
            {
                MessageBox.Show("Produto não encontrado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBarras.Text = string.Empty;
                txtCodigoBarras.SelectAll();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Verifica se o produto possui unidades em estoque. Exibe mensagem de erro se não houver estoque.
        /// </summary>
        /// <param name="produtoDigitado">Produto a ser verificado.</param>
        /// <returns>Retorna true se o produto possui unidades suficientes em estoque, caso contrário, retorna false.</returns>
        private bool IsProdutoPossuiUnidadesEstoque(Produto produtoDigitado)
        {
            if (produtoDigitado.QuantidadeEstoque == 0 || produtoDigitado.QuantidadeEstoque < 0)
            {
                MessageBox.Show("Produto sem unidades em estoque!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBarras.Text = string.Empty;
                txtCodigoBarras.SelectAll();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Verifica se o produto já foi inserido na lista de vendas e se a quantidade não ultrapassa o estoque.
        /// </summary>
        /// <param name="_produtoQueFoiDigitado">Produto a ser verificado.</param>
        /// <returns>Retorna true se o produto foi inserido e a quantidade não ultrapassa o estoque, caso contrário, retorna false.</returns>
        private bool IsProdutoGridUltrapassouLimiteEstoque(Produto _produtoQueFoiDigitado)
        {
            var produtoExistenteNoGrid = bindingListVendas.FirstOrDefault(linha => linha.ProdutoId == _produtoQueFoiDigitado.ProdutoId);

            if (produtoExistenteNoGrid != null)
            {
                if (produtoExistenteNoGrid.Quantidade > _produtoQueFoiDigitado.QuantidadeEstoque)
                {
                    MessageBox.Show($"Produto tem apenas {_produtoQueFoiDigitado.QuantidadeEstoque} unidades em estoque!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Verifica se o produto já foi inserido na lista de vendas. Se sim, apenas incrementa a quantidade.
        /// </summary>
        /// <param name="_produtoQueFoiDigitado">Produto a ser verificado.</param>
        /// <returns>Retorna true se o produto foi inserido, caso contrário, retorna false.</returns>
        private bool IsProdutoJaFoiInserido(Produto _produtoQueFoiDigitado)
        {
            
            var isProdutoExistente = bindingListVendas.Any(x => x.ProdutoId == _produtoQueFoiDigitado.ProdutoId);

            if (isProdutoExistente == true)
            {
                AcrescentarQuantidadeProduto(_produtoQueFoiDigitado);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Acrescenta uma unidade ao produto existente na lista de vendas.
        /// </summary>
        /// <param name="_produtoQueFoiDigitado">Produto para o qual a quantidade será acrescida.</param>
        private void AcrescentarQuantidadeProduto(Produto _produtoQueFoiDigitado)
        {
            var itemExistente = bindingListVendas.FirstOrDefault(x => x.ProdutoId == _produtoQueFoiDigitado.ProdutoId);
            itemExistente.Quantidade++;
            gridVendas.Refresh();
            CalcularTotalItens();
            SetarFocoTextBoxCodigoBarrasProduto();
        }

        /// <summary>
        /// Evento acionado ao pressionar o botão para inserir item na lista de vendas. Chama o método InserirItensNaLista.
        /// </summary>
        private void btnInserirItemGridVendas_Click(object sender, EventArgs e)
        {
            InserirItensNaLista();
        }

        /// <summary>
        /// Define o foco no campo de código de barras, limpando e selecionando o texto.
        /// </summary>
        private void SetarFocoTextBoxCodigoBarrasProduto()
        {
            txtCodigoBarras.TextChanged -= txtCodigoBarras_TextChanged;
            txtCodigoBarras.SelectAll();
            txtCodigoBarras.Text = string.Empty;
            btnInserirItemGridVendas.Focus();
            txtCodigoBarras.Focus();
            txtCodigoBarras.TextChanged += txtCodigoBarras_TextChanged;
        }

        /// <summary>
        /// Calcula o total de itens na lista de vendas e exibe o valor total no label.
        /// </summary>
        private void CalcularTotalItens()
        {
            var soma = bindingListVendas.Sum(x => x.PrecoUnitario * x.Quantidade);
            lblTotalItens.Text = soma.ToString("C2");
        }

        /// <summary>
        /// Atualiza o grid de vendas, vinculando o BindingSource e refrescando o grid.
        /// </summary>
        private void AtualizarGrid()
        {
            gridVendas.DataSource = bindingSource1;
            gridVendas.Refresh();
        }

        /// <summary>
        /// Evento acionado ao modificar o campo de código de barras, chamando o método para inserir itens na lista.
        /// </summary>
        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            InserirItensNaLista();
        }

        /// <summary>
        /// Insere um item na lista de vendas após validar o produto e as condições de estoque.
        /// </summary>
        private void InserirItensNaLista()
        {
            try
            {
                string codigoBarras = txtCodigoBarras.Text;
                Produto produtoDigitado = _produtoRepository.BuscarPorCodigoBarras(codigoBarras);

                if (IsProdutoValido(produtoDigitado) == false)
                    return;

                if (IsProdutoPossuiUnidadesEstoque(produtoDigitado) == false)
                    return;

                if (IsClienteEProdutoSelecionado() == false)
                    return;


                if (IsProdutoGridUltrapassouLimiteEstoque(produtoDigitado))
                {
                    if (IsProdutoJaFoiInserido(produtoDigitado) == false)
                    {
                        var venda = new Venda();

                        venda.ProdutoId = produtoDigitado.ProdutoId;
                        venda.Produto = produtoDigitado.NomeProduto;
                        venda.PrecoUnitario = produtoDigitado.PrecoUnitario;
                        venda.Quantidade = 1;
                        venda.VendaId = 0;
                        venda.ClienteId = Convert.ToInt32((cmbClientes.SelectedItem as Cliente).Id);
                        venda.Data = DateTime.Now;
                        venda.ValorTotal = venda.PrecoUnitario * venda.Quantidade;

                        bindingListVendas.Add(venda);

                        AtualizarGrid();
                        CalcularTotalItens();
                        SetarFocoTextBoxCodigoBarrasProduto();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao inserir item na lista: {e.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Abre o formulário de busca de produto manualmente para permitir ao usuário selecionar um produto.
        /// </summary>
        private void btnBuscarProduto_Click(object sender, EventArgs e)
        {
            form_BuscarProdutoManual form_BuscarProduto = new form_BuscarProdutoManual();
            form_BuscarProduto.ShowDialog();
        }


        /// <summary>
        /// Evento acionado ao pressionar teclas específicas (F11 ou F12) para buscar produtos ou finalizar a venda.
        /// </summary>
        private void form_VendaPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F12)
            {
                form_BuscarProdutoManual form_BuscarProduto = new form_BuscarProdutoManual();
                form_BuscarProduto.ShowDialog();
            }

            if (e.KeyCode == Keys.F11)
            {
                EfetuarVenda();
            }
        }
    }
}
