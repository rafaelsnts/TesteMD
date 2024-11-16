namespace TesteMD.Forms.Produtos
{
    partial class form_ProdutoPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridProdutos = new System.Windows.Forms.DataGridView();
            this.menuStripProduto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEditarInformacoesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExcluirProdutoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBuscarProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).BeginInit();
            this.menuStripProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridProdutos
            // 
            this.gridProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridProdutos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridProdutos.BackgroundColor = System.Drawing.Color.White;
            this.gridProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProdutos.ContextMenuStrip = this.menuStripProduto;
            this.gridProdutos.Location = new System.Drawing.Point(-3, 90);
            this.gridProdutos.Name = "gridProdutos";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProdutos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridProdutos.RowHeadersVisible = false;
            this.gridProdutos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProdutos.Size = new System.Drawing.Size(1268, 571);
            this.gridProdutos.TabIndex = 1;
            // 
            // menuStripProduto
            // 
            this.menuStripProduto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEditarInformacoesMenu,
            this.btnExcluirProdutoMenu});
            this.menuStripProduto.Name = "menuStripProduto";
            this.menuStripProduto.Size = new System.Drawing.Size(174, 48);
            // 
            // btnEditarInformacoesMenu
            // 
            this.btnEditarInformacoesMenu.Name = "btnEditarInformacoesMenu";
            this.btnEditarInformacoesMenu.Size = new System.Drawing.Size(173, 22);
            this.btnEditarInformacoesMenu.Text = "Editar Informações";
            this.btnEditarInformacoesMenu.Click += new System.EventHandler(this.btnEditarInformacoesMenu_Click);
            // 
            // btnExcluirProdutoMenu
            // 
            this.btnExcluirProdutoMenu.Name = "btnExcluirProdutoMenu";
            this.btnExcluirProdutoMenu.Size = new System.Drawing.Size(173, 22);
            this.btnExcluirProdutoMenu.Text = "Excluir";
            this.btnExcluirProdutoMenu.Click += new System.EventHandler(this.btnExcluirProdutoMenu_Click);
            // 
            // txtBuscarProduto
            // 
            this.txtBuscarProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarProduto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtBuscarProduto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscarProduto.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProduto.Location = new System.Drawing.Point(59, 24);
            this.txtBuscarProduto.Multiline = true;
            this.txtBuscarProduto.Name = "txtBuscarProduto";
            this.txtBuscarProduto.Size = new System.Drawing.Size(1207, 41);
            this.txtBuscarProduto.TabIndex = 0;
            this.txtBuscarProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscarProduto.TextChanged += new System.EventHandler(this.txtBuscarProduto_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(562, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Buscar Produto por Nome";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox1.Image = global::TesteMD.Properties.Resources.search_50px;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // form_ProdutoPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 657);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtBuscarProduto);
            this.Controls.Add(this.gridProdutos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_ProdutoPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.form_ProdutoPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).EndInit();
            this.menuStripProduto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView gridProdutos;
        private System.Windows.Forms.TextBox txtBuscarProduto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip menuStripProduto;
        private System.Windows.Forms.ToolStripMenuItem btnEditarInformacoesMenu;
        private System.Windows.Forms.ToolStripMenuItem btnExcluirProdutoMenu;
    }
}