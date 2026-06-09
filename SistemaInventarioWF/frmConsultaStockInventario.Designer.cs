namespace SistemaInventarioWF
{
    partial class frmConsultaStockInventario
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoInventario = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvInventarioStock = new System.Windows.Forms.DataGridView();
            this.txtBuscarInsumo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioStock)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(51, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(610, 37);
            this.label1.TabIndex = 18;
            this.label1.Text = "CONSULTA DE STOCK DE INVENTARIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(413, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 27);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tipo de Inventario";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cboTipoInventario
            // 
            this.cboTipoInventario.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoInventario.FormattingEnabled = true;
            this.cboTipoInventario.Location = new System.Drawing.Point(418, 206);
            this.cboTipoInventario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTipoInventario.Name = "cboTipoInventario";
            this.cboTipoInventario.Size = new System.Drawing.Size(298, 33);
            this.cboTipoInventario.TabIndex = 21;
            this.cboTipoInventario.SelectedIndexChanged += new System.EventHandler(this.cboTipoInventario_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnBuscar.Location = new System.Drawing.Point(807, 177);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(172, 62);
            this.btnBuscar.TabIndex = 26;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvInventarioStock
            // 
            this.dgvInventarioStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventarioStock.Location = new System.Drawing.Point(58, 304);
            this.dgvInventarioStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvInventarioStock.Name = "dgvInventarioStock";
            this.dgvInventarioStock.RowHeadersWidth = 62;
            this.dgvInventarioStock.Size = new System.Drawing.Size(1310, 601);
            this.dgvInventarioStock.TabIndex = 27;
            this.dgvInventarioStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventarioStock_CellContentClick);
            // 
            // txtBuscarInsumo
            // 
            this.txtBuscarInsumo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarInsumo.Location = new System.Drawing.Point(58, 206);
            this.txtBuscarInsumo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscarInsumo.Name = "txtBuscarInsumo";
            this.txtBuscarInsumo.Size = new System.Drawing.Size(298, 33);
            this.txtBuscarInsumo.TabIndex = 29;
            this.txtBuscarInsumo.TextChanged += new System.EventHandler(this.txtBuscarInsumo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(53, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 27);
            this.label3.TabIndex = 28;
            this.label3.Text = "Código del insumo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConsultaStockInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 782);
            this.Controls.Add(this.txtBuscarInsumo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvInventarioStock);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboTipoInventario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConsultaStockInventario";
            this.Text = "frmConsultaStockInventario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoInventario;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvInventarioStock;
        private System.Windows.Forms.TextBox txtBuscarInsumo;
        private System.Windows.Forms.Label label3;
    }
}