namespace TesteMD.Forms.Vendas
{
    partial class form_VendaPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridVendas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalItens = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.btnEfetuarVenda = new System.Windows.Forms.Button();
            this.btnInserirItemGridVendas = new System.Windows.Forms.Button();
            this.btnBuscarProduto = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVendas
            // 
            this.gridVendas.AllowUserToAddRows = false;
            this.gridVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridVendas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridVendas.BackgroundColor = System.Drawing.Color.White;
            this.gridVendas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVendas.Location = new System.Drawing.Point(-2, 86);
            this.gridVendas.Name = "gridVendas";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridVendas.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridVendas.RowHeadersVisible = false;
            this.gridVendas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVendas.Size = new System.Drawing.Size(1250, 489);
            this.gridVendas.TabIndex = 2222;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label1.Location = new System.Drawing.Point(955, 584);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "VALOR TOTAL:";
            // 
            // lblTotalItens
            // 
            this.lblTotalItens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalItens.AutoSize = true;
            this.lblTotalItens.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalItens.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalItens.Location = new System.Drawing.Point(1103, 578);
            this.lblTotalItens.Name = "lblTotalItens";
            this.lblTotalItens.Size = new System.Drawing.Size(94, 32);
            this.lblTotalItens.TabIndex = 4;
            this.lblTotalItens.Text = "R$ 0,00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cliente:";
            // 
            // cmbClientes
            // 
            this.cmbClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(12, 29);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(347, 25);
            this.cmbClientes.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(377, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cod. Barras:";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoBarras.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtCodigoBarras.Location = new System.Drawing.Point(380, 30);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(347, 25);
            this.txtCodigoBarras.TabIndex = 1;
            this.txtCodigoBarras.TextChanged += new System.EventHandler(this.txtCodigoBarras_TextChanged);
            // 
            // btnEfetuarVenda
            // 
            this.btnEfetuarVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEfetuarVenda.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEfetuarVenda.Location = new System.Drawing.Point(909, 29);
            this.btnEfetuarVenda.Name = "btnEfetuarVenda";
            this.btnEfetuarVenda.Size = new System.Drawing.Size(160, 26);
            this.btnEfetuarVenda.TabIndex = 3;
            this.btnEfetuarVenda.Text = "Efetuar Venda (F11)";
            this.btnEfetuarVenda.UseVisualStyleBackColor = true;
            this.btnEfetuarVenda.Click += new System.EventHandler(this.btnEfetuarVenda_Click);
            // 
            // btnInserirItemGridVendas
            // 
            this.btnInserirItemGridVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserirItemGridVendas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserirItemGridVendas.Location = new System.Drawing.Point(743, 29);
            this.btnInserirItemGridVendas.Name = "btnInserirItemGridVendas";
            this.btnInserirItemGridVendas.Size = new System.Drawing.Size(160, 26);
            this.btnInserirItemGridVendas.TabIndex = 2;
            this.btnInserirItemGridVendas.Text = "Inserir Item";
            this.btnInserirItemGridVendas.UseVisualStyleBackColor = true;
            this.btnInserirItemGridVendas.Click += new System.EventHandler(this.btnInserirItemGridVendas_Click);
            // 
            // btnBuscarProduto
            // 
            this.btnBuscarProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarProduto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscarProduto.Location = new System.Drawing.Point(1081, 30);
            this.btnBuscarProduto.Name = "btnBuscarProduto";
            this.btnBuscarProduto.Size = new System.Drawing.Size(160, 25);
            this.btnBuscarProduto.TabIndex = 4;
            this.btnBuscarProduto.Text = "Buscar Produto (F12)";
            this.btnBuscarProduto.UseVisualStyleBackColor = true;
            this.btnBuscarProduto.Click += new System.EventHandler(this.btnBuscarProduto_Click);
            // 
            // form_VendaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 618);
            this.Controls.Add(this.btnBuscarProduto);
            this.Controls.Add(this.btnInserirItemGridVendas);
            this.Controls.Add(this.btnEfetuarVenda);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalItens);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridVendas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "form_VendaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PVD";
            this.Load += new System.EventHandler(this.form_VendaPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_VendaPrincipal_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView gridVendas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalItens;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Button btnEfetuarVenda;
        private System.Windows.Forms.Button btnInserirItemGridVendas;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnBuscarProduto;
    }
}