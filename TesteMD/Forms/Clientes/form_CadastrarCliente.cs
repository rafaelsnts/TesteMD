using System;
using System.Windows.Forms;
using TesteMD.Domain.Models;
using TesteMD.Infra.Repository;
using TesteMD.Infra.Services;

namespace TesteMD.Forms.Clientes
{
    public partial class form_CadastrarCliente : Form
    {
        private ClienteService _clienteService;
        private form_ClientePrincipal formClientePrincipal = null;

        public form_CadastrarCliente(form_ClientePrincipal _formClientePrincipal)
        {
            InitializeComponent();
            _clienteService = new ClienteService(new ClienteRepository());
            formClientePrincipal = _formClientePrincipal;
        }

        public form_CadastrarCliente()
        {
            InitializeComponent();
            _clienteService = new ClienteService(new ClienteRepository());
        }

        /// <summary>
        /// Limpa todos os campos do formulário, redefinindo-os para valores em branco ou padrão.
        /// </summary>
        private void LimparCampos()
        {
            txtNomeCliente.Text = "";
            txtRuaCliente.Text = "";
            txtTelefoneCliente.Text = "";
            txtEmailCliente.Text = "";
            dtpDataCadastro.Value = DateTime.Now;
            txtCep.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtBairro.Text = "";
            txtNumeroEndereco.Text = "";
        }

        /// <summary>
        /// Evento para o botão de cadastrar cliente. Valida os campos obrigatórios, cria e adiciona um novo cliente, atualiza a tabela de clientes e limpa os campos.
        /// </summary>
        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNomeCliente.Text))
                {
                    MessageBox.Show("O nome do cliente é obrigatório.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cliente = new Cliente
                {
                    Nome = txtNomeCliente.Text,
                    Rua = txtRuaCliente.Text,
                    Telefone = txtTelefoneCliente.Text,
                    Email = txtEmailCliente.Text,
                    DataCadastro = dtpDataCadastro.Value,
                    Cep = txtCep.Text,
                    Cidade = txtCidade.Text,
                    Estado = txtEstado.Text,
                    Bairro = txtBairro.Text,
                    Numero = txtNumeroEndereco.Text
                };

                _clienteService.AdicionarCliente(cliente);

                AtualizarTabelaClientesFormPrincipal();

                MessageBox.Show("Cliente cadastrado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Atualiza a tabela de clientes na tela principal ao cadastrar um novo cliente ou salvar uma alteração.
        /// </summary>
        private void AtualizarTabelaClientesFormPrincipal()
        {
            if (formClientePrincipal != null)
                formClientePrincipal.PreencherGridClientes();
        }

        /// <summary>
        /// Formata o campo de telefone para incluir parênteses e hífen automaticamente enquanto o usuário digita.
        /// </summary>
        private void FormatarCampoTelefone(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            TextBox Tel = sender as TextBox;
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                Tel.SelectionStart = Tel.Text.Length + 1;

                if (Tel.Text.Length == 0 || Tel.Text.Length == 1)
                    Tel.Text += "(";
                else if (Tel.Text.Length == 3)
                    Tel.Text += ")";
                else if (Tel.Text.Length == 9)
                    Tel.Text += "-";
                Tel.SelectionStart = Tel.Text.Length + 1;
            }
        }

        /// <summary>
        /// Evento do campo de telefone que chama o método de formatação para assegurar o formato correto do número.
        /// </summary>
        private void txtTelefoneCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatarCampoTelefone(sender, e);
        }


        /// <summary>
        /// Busca automaticamente informações de endereço com base no CEP inserido e preenche os campos correspondentes.
        /// </summary>
        public void PreencherInformacoesCep()
        {
            if (!string.IsNullOrWhiteSpace(txtCep.Text))
            {
                try
                {
                    CEP cep = new CEP(txtCep.Text);

                    txtRuaCliente.Text = cep.logradouro;
                    txtBairro.Text = cep.bairro;
                    txtCidade.Text = cep.localidade;
                    txtEstado.Text = cep.uf;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar informações do CEP: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Evento acionado ao sair do campo de CEP, chamando o método para preencher automaticamente as informações do endereço.
        /// </summary>
        private void txtCep_Leave(object sender, EventArgs e)
        {
            PreencherInformacoesCep();
        }


        /// <summary>
        /// Impede a inserção de letras no campo, permitindo apenas números e backspace.
        /// </summary>
        private void ImpedirDigitarLetras(KeyPressEventArgs _event)
        {
            if (!char.IsDigit(_event.KeyChar) && _event.KeyChar != (char)8)
            {
                _event.Handled = true;
            }
        }

        /// <summary>
        /// Evento do campo de CEP que chama o método para impedir a digitação de letras.
        /// </summary>
        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            ImpedirDigitarLetras(e);
        }
    }
}
