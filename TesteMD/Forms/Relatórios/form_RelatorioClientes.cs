using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TesteMD.Domain.Interface;
using TesteMD.Domain.Models;
using TesteMD.Infra.Repository;

namespace TesteMD.Forms.ReportView
{
    public partial class form_RelatorioClientes : Form
    {
        public form_RelatorioClientes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento disparado ao carregar o formulário de relatório de clientes, iniciando o carregamento dos dados no ReportViewer.
        /// </summary>
        private void form_RelatorioClientes_Load(object sender, EventArgs e)
        {
            CarregarRelatorioCliente();
        }

        /// <summary>
        /// Carrega o relatório de clientes no ReportViewer, buscando todos os clientes do repositório e adicionando-os como fonte de dados.
        /// </summary>
        private void CarregarRelatorioCliente()
        {
            IClienteRepository _clienteRepository = new ClienteRepository();

            List<Cliente> listaClientes = _clienteRepository.BuscarTodos();

            var datasou = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetCliente", listaClientes);
            this.reportViewerCliente.LocalReport.DataSources.Clear();
            this.reportViewerCliente.LocalReport.DataSources.Add(datasou);

            this.reportViewerCliente.RefreshReport();

        }

        /// <summary>
        /// Evento disparado ao carregar o componente ReportViewer, carregando o relatório de clientes.
        /// </summary>
        private void reportViewerCliente_Load(object sender, EventArgs e)
        {
            CarregarRelatorioCliente();
        }
    }
}
