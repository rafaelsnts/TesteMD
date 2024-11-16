namespace TesteMD.Forms._1___Principal
{
    partial class form_GraficoVendasMenuInicial
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chartVendasMensais = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVendasSemanais = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendasMensais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendasSemanais)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(541, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gráfico Vendas Mensais";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(537, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gráfico Vendas Semanais";
            // 
            // chartVendasMensais
            // 
            chartArea3.Name = "ChartArea1";
            this.chartVendasMensais.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartVendasMensais.Legends.Add(legend3);
            this.chartVendasMensais.Location = new System.Drawing.Point(0, 377);
            this.chartVendasMensais.Name = "chartVendasMensais";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartVendasMensais.Series.Add(series3);
            this.chartVendasMensais.Size = new System.Drawing.Size(1264, 278);
            this.chartVendasMensais.TabIndex = 5;
            this.chartVendasMensais.Text = "chart2";
            // 
            // chartVendasSemanais
            // 
            chartArea4.Name = "ChartArea1";
            this.chartVendasSemanais.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartVendasSemanais.Legends.Add(legend4);
            this.chartVendasSemanais.Location = new System.Drawing.Point(0, 38);
            this.chartVendasSemanais.Name = "chartVendasSemanais";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartVendasSemanais.Series.Add(series4);
            this.chartVendasSemanais.Size = new System.Drawing.Size(1264, 278);
            this.chartVendasSemanais.TabIndex = 4;
            this.chartVendasSemanais.Text = "chart1";
            // 
            // form_GraficoVendasMenuInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 657);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartVendasMensais);
            this.Controls.Add(this.chartVendasSemanais);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_GraficoVendasMenuInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_GraficoVendasMenuInicial";
            this.Load += new System.EventHandler(this.form_GraficoVendasMenuInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartVendasMensais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVendasSemanais)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVendasMensais;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVendasSemanais;
    }
}