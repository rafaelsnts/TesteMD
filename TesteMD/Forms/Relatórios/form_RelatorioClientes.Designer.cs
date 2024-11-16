namespace TesteMD.Forms.ReportView
{
    partial class form_RelatorioClientes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewerCliente = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ClienteBindingSource
            // 
            this.ClienteBindingSource.DataSource = typeof(TesteMD.Domain.Models.Cliente);
            // 
            // reportViewerCliente
            // 
            this.reportViewerCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSetCliente";
            reportDataSource3.Value = this.ClienteBindingSource;
            this.reportViewerCliente.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewerCliente.LocalReport.ReportEmbeddedResource = "TesteMD.ReportViewer.RelatorioCliente.rdlc";
            this.reportViewerCliente.Location = new System.Drawing.Point(0, 0);
            this.reportViewerCliente.Name = "reportViewerCliente";
            this.reportViewerCliente.ServerReport.BearerToken = null;
            this.reportViewerCliente.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewerCliente.Size = new System.Drawing.Size(800, 450);
            this.reportViewerCliente.TabIndex = 0;
            this.reportViewerCliente.Load += new System.EventHandler(this.reportViewerCliente_Load);
            // 
            // form_RelatorioClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerCliente);
            this.Name = "form_RelatorioClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Clientes";
            this.Load += new System.EventHandler(this.form_RelatorioClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerCliente;
        private System.Windows.Forms.BindingSource ClienteBindingSource;
    }
}