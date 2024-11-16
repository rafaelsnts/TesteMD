namespace TesteMD.Forms.Relatórios
{
    partial class form_RelatorioVendas
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
            this.reportViewerVendas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.VendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VendaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewerVendas
            // 
            this.reportViewerVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetVendas";
            reportDataSource1.Value = this.VendaBindingSource;
            this.reportViewerVendas.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerVendas.LocalReport.ReportEmbeddedResource = "TesteMD.ReportViewer.DadosRelatorioVendas.rdlc";
            this.reportViewerVendas.Location = new System.Drawing.Point(0, 0);
            this.reportViewerVendas.Name = "reportViewerVendas";
            this.reportViewerVendas.ServerReport.BearerToken = null;
            this.reportViewerVendas.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewerVendas.Size = new System.Drawing.Size(805, 550);
            this.reportViewerVendas.TabIndex = 2;
            // 
            // VendaBindingSource
            // 
            this.VendaBindingSource.DataSource = typeof(TesteMD.Domain.Models.Venda);
            // 
            // form_RelatorioVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 550);
            this.Controls.Add(this.reportViewerVendas);
            this.Name = "form_RelatorioVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Vendas";
            this.Load += new System.EventHandler(this.form_RelatorioVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VendaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerVendas;
        private System.Windows.Forms.BindingSource VendaBindingSource;
    }
}