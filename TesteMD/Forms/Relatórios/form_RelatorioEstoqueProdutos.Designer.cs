namespace TesteMD.Forms.Relatórios
{
    partial class form_RelatorioEstoqueProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewerEstoqueProdutos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ProdutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ProdutoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewerEstoqueProdutos
            // 
            this.reportViewerEstoqueProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetEstoqueProduto";
            reportDataSource1.Value = this.ProdutoBindingSource;
            this.reportViewerEstoqueProdutos.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerEstoqueProdutos.LocalReport.ReportEmbeddedResource = "TesteMD.ReportViewer.DadosRelatorioEstoqueProduto.rdlc";
            this.reportViewerEstoqueProdutos.Location = new System.Drawing.Point(0, 0);
            this.reportViewerEstoqueProdutos.Name = "reportViewerEstoqueProdutos";
            this.reportViewerEstoqueProdutos.ServerReport.BearerToken = null;
            this.reportViewerEstoqueProdutos.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewerEstoqueProdutos.Size = new System.Drawing.Size(611, 342);
            this.reportViewerEstoqueProdutos.TabIndex = 1;
            // 
            // ProdutoBindingSource
            // 
            this.ProdutoBindingSource.DataSource = typeof(TesteMD.Domain.Models.Produto);
            // 
            // ClienteBindingSource
            // 
            this.ClienteBindingSource.DataSource = typeof(TesteMD.Domain.Models.Cliente);
            // 
            // form_RelatorioEstoqueProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 342);
            this.Controls.Add(this.reportViewerEstoqueProdutos);
            this.Name = "form_RelatorioEstoqueProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório Estoque de Produtos";
            this.Load += new System.EventHandler(this.form_RelatorioEstoqueProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProdutoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerEstoqueProdutos;
        private System.Windows.Forms.BindingSource ClienteBindingSource;
        private System.Windows.Forms.BindingSource ProdutoBindingSource;
    }
}