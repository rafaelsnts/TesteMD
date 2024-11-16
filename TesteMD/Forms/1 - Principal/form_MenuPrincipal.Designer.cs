namespace TesteMD.Forms._1___Principal
{
    partial class form_MenuPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inícioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatoriosClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatorioEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPDV = new System.Windows.Forms.ToolStripMenuItem();
            this.relatorioDeVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_Inicio = new System.Windows.Forms.Panel();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteTesteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inícioToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.vendasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inícioToolStripMenuItem
            // 
            this.inícioToolStripMenuItem.Name = "inícioToolStripMenuItem";
            this.inícioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inícioToolStripMenuItem.Text = "Início";
            this.inícioToolStripMenuItem.Click += new System.EventHandler(this.inícioToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoClienteToolStripMenuItem,
            this.exibirClientesToolStripMenuItem,
            this.relatoriosClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // novoClienteToolStripMenuItem
            // 
            this.novoClienteToolStripMenuItem.Name = "novoClienteToolStripMenuItem";
            this.novoClienteToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.novoClienteToolStripMenuItem.Text = "Novo Cliente";
            this.novoClienteToolStripMenuItem.Click += new System.EventHandler(this.novoClienteToolStripMenuItem_Click);
            // 
            // exibirClientesToolStripMenuItem
            // 
            this.exibirClientesToolStripMenuItem.Name = "exibirClientesToolStripMenuItem";
            this.exibirClientesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exibirClientesToolStripMenuItem.Text = "Exibir Clientes";
            this.exibirClientesToolStripMenuItem.Click += new System.EventHandler(this.exibirClientesToolStripMenuItem_Click);
            // 
            // relatoriosClientesToolStripMenuItem
            // 
            this.relatoriosClientesToolStripMenuItem.Name = "relatoriosClientesToolStripMenuItem";
            this.relatoriosClientesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.relatoriosClientesToolStripMenuItem.Text = "Relatório Clientes";
            this.relatoriosClientesToolStripMenuItem.Click += new System.EventHandler(this.relatoriosClientesToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoProdutoToolStripMenuItem,
            this.exibirProdutosToolStripMenuItem,
            this.relatorioEstoqueToolStripMenuItem});
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.produtosToolStripMenuItem.Text = "Produtos";
            // 
            // novoProdutoToolStripMenuItem
            // 
            this.novoProdutoToolStripMenuItem.Name = "novoProdutoToolStripMenuItem";
            this.novoProdutoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.novoProdutoToolStripMenuItem.Text = "Novo Produto";
            this.novoProdutoToolStripMenuItem.Click += new System.EventHandler(this.novoProdutoToolStripMenuItem_Click);
            // 
            // exibirProdutosToolStripMenuItem
            // 
            this.exibirProdutosToolStripMenuItem.Name = "exibirProdutosToolStripMenuItem";
            this.exibirProdutosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exibirProdutosToolStripMenuItem.Text = "Exibir Produtos";
            this.exibirProdutosToolStripMenuItem.Click += new System.EventHandler(this.exibirProdutosToolStripMenuItem_Click);
            // 
            // relatorioEstoqueToolStripMenuItem
            // 
            this.relatorioEstoqueToolStripMenuItem.Name = "relatorioEstoqueToolStripMenuItem";
            this.relatorioEstoqueToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.relatorioEstoqueToolStripMenuItem.Text = "Relatório Estoque";
            this.relatorioEstoqueToolStripMenuItem.Click += new System.EventHandler(this.relatorioEstoqueToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPDV,
            this.relatorioDeVendaToolStripMenuItem});
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.vendasToolStripMenuItem.Text = "Vendas";
            // 
            // btnPDV
            // 
            this.btnPDV.Name = "btnPDV";
            this.btnPDV.Size = new System.Drawing.Size(180, 22);
            this.btnPDV.Text = "PDV";
            this.btnPDV.Click += new System.EventHandler(this.btnPDV_Click);
            // 
            // relatorioDeVendaToolStripMenuItem
            // 
            this.relatorioDeVendaToolStripMenuItem.Name = "relatorioDeVendaToolStripMenuItem";
            this.relatorioDeVendaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.relatorioDeVendaToolStripMenuItem.Text = "Relatório de Venda";
            this.relatorioDeVendaToolStripMenuItem.Click += new System.EventHandler(this.relatorioDeVendaToolStripMenuItem_Click);
            // 
            // pnl_Inicio
            // 
            this.pnl_Inicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Inicio.Location = new System.Drawing.Point(0, 24);
            this.pnl_Inicio.Name = "pnl_Inicio";
            this.pnl_Inicio.Size = new System.Drawing.Size(1264, 657);
            this.pnl_Inicio.TabIndex = 1;
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // clienteTesteToolStripMenuItem
            // 
            this.clienteTesteToolStripMenuItem.Name = "clienteTesteToolStripMenuItem";
            this.clienteTesteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // form_MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnl_Inicio);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "form_MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_MenuPrincipal_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inícioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_Inicio;
        private System.Windows.Forms.ToolStripMenuItem novoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exibirClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteTesteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exibirProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnPDV;
        private System.Windows.Forms.ToolStripMenuItem relatoriosClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatorioEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatorioDeVendaToolStripMenuItem;
    }
}