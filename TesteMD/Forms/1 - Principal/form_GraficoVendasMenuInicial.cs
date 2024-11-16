using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TesteMD.Infra.Services;

namespace TesteMD.Forms._1___Principal
{
    public partial class form_GraficoVendasMenuInicial : Form
    {
        IVendaRepository _vendaRepository = new VendaRepository();
        private VendaService _vendaService;
        public form_GraficoVendasMenuInicial()
        {
            InitializeComponent();
            _vendaService = new VendaService(_vendaRepository);
        }
       
        /// <summary>
        /// Carrega os dados de vendas semanais e os exibe em um gráfico de colunas.
        /// Obtém as vendas semanais através do serviço de vendas (_vendaService),
        /// adiciona os dados ao gráfico e define os títulos dos eixos X e Y.
        /// </summary>
        private void CarregarDadosChartSemanal()
        {

            var vendasSemanais = _vendaService.ObterVendasSemanais();

            var serieVendas = new Series("Vendas Semanais")
            {
                ChartType = SeriesChartType.Column, 
                XValueType = ChartValueType.String, 
                YValueType = ChartValueType.Int32  
            };

           
            foreach (var venda in vendasSemanais)
            {
                serieVendas.Points.AddXY(venda.Key, venda.Value);
            }

            chartVendasSemanais.Series.Clear();
            chartVendasSemanais.Series.Add(serieVendas);
            chartVendasSemanais.ChartAreas[0].AxisX.Title = "Dias da Semana";
            chartVendasSemanais.ChartAreas[0].AxisY.Title = "Total de Vendas";
        }

        /// <summary>
        /// Carrega os dados de vendas mensais e os exibe em um gráfico de colunas.
        /// Obtém as vendas mensais através do serviço de vendas (_vendaService),
        /// adiciona os dados ao gráfico e define os títulos dos eixos X e Y.
        /// </summary>
        private void CarregarDadosChartMensal()
        {
           
            var vendasMensais = _vendaService.ObterVendasMensais();

            var serieVendas = new Series("Vendas Mensais")
            {
                ChartType = SeriesChartType.Column, 
                XValueType = ChartValueType.String, 
                YValueType = ChartValueType.Int32   
            };

           
            foreach (var venda in vendasMensais)
            {
                serieVendas.Points.AddXY(venda.Key, venda.Value);
            }

            chartVendasMensais.Series.Clear();
            chartVendasMensais.Series.Add(serieVendas);
            chartVendasMensais.ChartAreas[0].AxisX.Title = "Meses";
            chartVendasMensais.ChartAreas[0].AxisY.Title = "Total de Vendas";   
        }

        /// <summary>
        /// Carrega os dados dos gráficos de vendas mensais e semanais ao iniciar o formulário.
        /// </summary>
        private void form_GraficoVendasMenuInicial_Load(object sender, EventArgs e)
        {
            CarregarDadosChartMensal();
            CarregarDadosChartSemanal();
        }
    }
}
