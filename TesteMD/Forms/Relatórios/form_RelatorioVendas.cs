using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TesteMD.Domain.Models;

namespace TesteMD.Forms.Relatórios
{
    public partial class form_RelatorioVendas : Form
    {
        public form_RelatorioVendas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carrega o relatório de vendas no ReportViewer, buscando todas as vendas do repositório e adicionando-as como fonte de dados.
        /// </summary>
        private void CarregarRelatorioVendas()
        {
            IVendaRepository _vendaRepository = new VendaRepository();

            List<Venda> listaProduto = _vendaRepository.ObterTodasVendas();

            var datasou = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetVendas", listaProduto);
            this.reportViewerVendas.LocalReport.DataSources.Clear();
            this.reportViewerVendas.LocalReport.DataSources.Add(datasou);

            this.reportViewerVendas.RefreshReport();
        }

        /// <summary>
        /// Evento disparado ao carregar o formulário de relatório de vendas, iniciando o carregamento dos dados no ReportViewer.
        /// </summary>
        private void form_RelatorioVendas_Load(object sender, EventArgs e)
        {
            CarregarRelatorioVendas();
        }
    }
}
