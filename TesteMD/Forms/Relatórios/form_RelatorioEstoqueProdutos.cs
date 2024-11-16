using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TesteMD.Domain.Interface;
using TesteMD.Domain.Models;
using TesteMD.Infra.Repository;

namespace TesteMD.Forms.Relatórios
{
    public partial class form_RelatorioEstoqueProdutos : Form
    {
        public form_RelatorioEstoqueProdutos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carrega o relatório de estoque de produtos no ReportViewer, buscando todos os produtos do repositório e adicionando-os como fonte de dados.
        /// </summary>
        private void CarregarRelatorioEstoqueProduto()
        {
            IProdutoRepository _produtoRepository = new ProdutoRepository();

            List<Produto> listaProduto = _produtoRepository.BuscarTodos();

            var datasou = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetEstoqueProduto", listaProduto);
            this.reportViewerEstoqueProdutos.LocalReport.DataSources.Clear();
            this.reportViewerEstoqueProdutos.LocalReport.DataSources.Add(datasou);

            this.reportViewerEstoqueProdutos.RefreshReport();
        }

        /// <summary>
        /// Evento disparado ao carregar o formulário de relatório de estoque de produtos, iniciando o carregamento dos dados no ReportViewer.
        /// </summary>
        private void form_RelatorioEstoqueProdutos_Load(object sender, EventArgs e)
        {
            CarregarRelatorioEstoqueProduto();
        }
    }
}
