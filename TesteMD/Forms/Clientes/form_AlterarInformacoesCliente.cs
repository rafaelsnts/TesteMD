using System;
using System.Windows.Forms;
using TesteMD.Domain.Models;
using TesteMD.Infra.Repository;
using TesteMD.Infra.Services;

namespace TesteMD.Forms.Clientes
{
    public partial class form_AlterarInformacoesCliente : Form
    {
        private int _idCliente;
        private form_ClientePrincipal formClientePrincipal = null;
        private ClienteService _clienteService;
        private form_CadastrarCliente formCadastrarCliente = new form_CadastrarCliente();

        public int ClienteId
        {
            get
            {
                return _idCliente;
            }
            set
            {
                _idCliente = value;
                CarregarDadosClientePorID();
            }
        }
        public form_AlterarInformacoesCliente(form_ClientePrincipal _formClientePrincipal)
        {

            InitializeComponent();
            _clienteService = new ClienteService(new ClienteRepository());
            formClientePrincipal = _formClientePrincipal;
        }

        public form_AlterarInformacoesCliente()
        {
            InitializeComponent();
            _clienteService = new ClienteService(new ClienteRepository());
        }
        /// <summary>
        /// Carrega os dados de um cliente específico pelo ID e preenche os campos do formulário com as informações.
        /// </summary>
        private void CarregarDadosClientePorID()
        {
            var cliente = new ClienteService(new ClienteRepository()).BuscarClientePorId(_idCliente);
            if (cliente != null)
            {
                txtNomeCliente.Text = cliente.Nome;
                txtRuaCliente.Text = cliente.Rua;
                txtTelefoneCliente.Text = cliente.Telefone;
                txtEmailCliente.Text = cliente.Email;
                dtpDataCadastro.Value = cliente.DataCadastro;
                txtCep.Text = cliente.Cep;
                txtCidade.Text = cliente.Cidade;
                txtEstado.Text = cliente.Estado;
                txtBairro.Text = cliente.Bairro;
                txtNumeroEndereco.Text = cliente.Numero;
            }
        }

        /// <summary>
        /// Evento para o botão de alterar informações do cliente. Valida o nome, atualiza o cliente e exibe uma mensagem de sucesso.
        /// </summary>
        private void btnAlterarInformacoesCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeCliente.Text))
            {
                MessageBox.Show("O nome do cliente é obrigatório.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cliente = new Cliente
            {
                Id = _idCliente,
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

            new ClienteService(new ClienteRepository()).AtualizarCliente(cliente);

            AtualizarTabelaClientesFormPrincipal();

            MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// Atualiza a tabela de clientes na tela principal ao salvar uma alteração ou novo cliente.
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
        private void txtCep_Leave(object sender, EventArgs e)
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
        /// Impede o usuario de inserir letras no campo, permitindo apenas números e backspace.
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
