namespace SistemaInventarioWF
{
    partial class frmConsultas_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultas_Menu));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btn_stock = new System.Windows.Forms.Button();
            this.btn_historial = new System.Windows.Forms.Button();
            this.btn_comprasProveedor = new System.Windows.Forms.Button();
            this.btn_ordenes = new System.Windows.Forms.Button();
            this.btnVentaFecha = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(77, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 133);
            this.label2.TabIndex = 18;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(337, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 31);
            this.label1.TabIndex = 17;
            this.label1.Text = "DASHBOARD - CONSULTAS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnInventario.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.DarkRed;
            this.btnInventario.Location = new System.Drawing.Point(476, 518);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(434, 53);
            this.btnInventario.TabIndex = 16;
            this.btnInventario.Text = "CONSULTA DE ENVIOS Y DELIVERY";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btn_stock
            // 
            this.btn_stock.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stock.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btn_stock.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stock.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_stock.Location = new System.Drawing.Point(476, 232);
            this.btn_stock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_stock.Name = "btn_stock";
            this.btn_stock.Size = new System.Drawing.Size(434, 53);
            this.btn_stock.TabIndex = 15;
            this.btn_stock.Text = "CONSULTA DE STOCK DE INVENTARIO";
            this.btn_stock.UseVisualStyleBackColor = false;
            this.btn_stock.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btn_historial
            // 
            this.btn_historial.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_historial.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btn_historial.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_historial.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_historial.Location = new System.Drawing.Point(476, 443);
            this.btn_historial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_historial.Name = "btn_historial";
            this.btn_historial.Size = new System.Drawing.Size(434, 53);
            this.btn_historial.TabIndex = 14;
            this.btn_historial.Text = "CONSULTA DE HISTORIAL DE AUDITORIA";
            this.btn_historial.UseVisualStyleBackColor = false;
            this.btn_historial.Click += new System.EventHandler(this.btnMenuCombos_Click);
            // 
            // btn_comprasProveedor
            // 
            this.btn_comprasProveedor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_comprasProveedor.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btn_comprasProveedor.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_comprasProveedor.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_comprasProveedor.Location = new System.Drawing.Point(476, 372);
            this.btn_comprasProveedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_comprasProveedor.Name = "btn_comprasProveedor";
            this.btn_comprasProveedor.Size = new System.Drawing.Size(434, 53);
            this.btn_comprasProveedor.TabIndex = 13;
            this.btn_comprasProveedor.Text = "CONSULTA DE COMPRAS POR PROVEEDOR";
            this.btn_comprasProveedor.UseVisualStyleBackColor = false;
            this.btn_comprasProveedor.Click += new System.EventHandler(this.btn_comprasProveedor_Click);
            // 
            // btn_ordenes
            // 
            this.btn_ordenes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ordenes.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btn_ordenes.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ordenes.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_ordenes.Location = new System.Drawing.Point(476, 303);
            this.btn_ordenes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ordenes.Name = "btn_ordenes";
            this.btn_ordenes.Size = new System.Drawing.Size(434, 53);
            this.btn_ordenes.TabIndex = 12;
            this.btn_ordenes.Text = "CONSULTA DE ORDENES ACTIVA";
            this.btn_ordenes.UseVisualStyleBackColor = false;
            this.btn_ordenes.Click += new System.EventHandler(this.btn_ordenes_Click);
            // 
            // btnVentaFecha
            // 
            this.btnVentaFecha.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVentaFecha.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnVentaFecha.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentaFecha.ForeColor = System.Drawing.Color.DarkRed;
            this.btnVentaFecha.Location = new System.Drawing.Point(476, 161);
            this.btnVentaFecha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVentaFecha.Name = "btnVentaFecha";
            this.btnVentaFecha.Size = new System.Drawing.Size(434, 53);
            this.btnVentaFecha.TabIndex = 11;
            this.btnVentaFecha.Text = "CONSULTA DE VENTAS POR FECHA";
            this.btnVentaFecha.UseVisualStyleBackColor = false;
            this.btnVentaFecha.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SistemaInventarioWF.Properties.Resources.consultas;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(167, 366);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 143);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // frmConsultas_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 547);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.btn_stock);
            this.Controls.Add(this.btn_historial);
            this.Controls.Add(this.btn_comprasProveedor);
            this.Controls.Add(this.btn_ordenes);
            this.Controls.Add(this.btnVentaFecha);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmConsultas_Menu";
            this.Text = "frmConsultas_Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btn_stock;
        private System.Windows.Forms.Button btn_historial;
        private System.Windows.Forms.Button btn_comprasProveedor;
        private System.Windows.Forms.Button btn_ordenes;
        private System.Windows.Forms.Button btnVentaFecha;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}