namespace SistemaInventarioWF
{
    partial class frmRegistroCompra
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
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProveedores = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCostoUnitario = new System.Windows.Forms.TextBox();
            this.cboInsumo = new System.Windows.Forms.ComboBox();
            this.numUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAgregarInsumo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvDetalleCompra = new System.Windows.Forms.DataGridView();
            this.btnRegistrarCompra = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalCompra = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(31, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(381, 37);
            this.label8.TabIndex = 36;
            this.label8.Text = "REGISTRO DE COMPRA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(32, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(477, 29);
            this.label4.TabIndex = 38;
            this.label4.Text = "DATOS DE PROVEEDOR Y DOCUMENTO";
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtNumDoc.Enabled = false;
            this.txtNumDoc.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDoc.ForeColor = System.Drawing.Color.Black;
            this.txtNumDoc.Location = new System.Drawing.Point(372, 197);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.ReadOnly = true;
            this.txtNumDoc.Size = new System.Drawing.Size(281, 30);
            this.txtNumDoc.TabIndex = 41;
            this.txtNumDoc.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(732, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 27);
            this.label5.TabIndex = 40;
            this.label5.Text = "Fecha:";
            // 
            // cboProveedores
            // 
            this.cboProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedores.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProveedores.ForeColor = System.Drawing.Color.Black;
            this.cboProveedores.FormattingEnabled = true;
            this.cboProveedores.Location = new System.Drawing.Point(263, 137);
            this.cboProveedores.Name = "cboProveedores";
            this.cboProveedores.Size = new System.Drawing.Size(390, 31);
            this.cboProveedores.TabIndex = 39;
            this.cboProveedores.Tag = "ORDENES ACTIVAS";
            this.cboProveedores.SelectedIndexChanged += new System.EventHandler(this.cboProveedores_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(62, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 27);
            this.label1.TabIndex = 42;
            this.label1.Text = "Proveedor:";
            // 
            // dtpFechaCompra
            // 
            this.dtpFechaCompra.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCompra.Location = new System.Drawing.Point(866, 136);
            this.dtpFechaCompra.Name = "dtpFechaCompra";
            this.dtpFechaCompra.Size = new System.Drawing.Size(522, 33);
            this.dtpFechaCompra.TabIndex = 43;
            this.dtpFechaCompra.ValueChanged += new System.EventHandler(this.dtpFechaCompra_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(62, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 27);
            this.label2.TabIndex = 44;
            this.label2.Text = "Num. de documento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(32, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(311, 29);
            this.label3.TabIndex = 46;
            this.label3.Text = "SELECCION DE INSUMOS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(62, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 27);
            this.label6.TabIndex = 50;
            this.label6.Text = "Cantidad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(62, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 27);
            this.label7.TabIndex = 49;
            this.label7.Text = "Insumo:";
            // 
            // txtCostoUnitario
            // 
            this.txtCostoUnitario.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCostoUnitario.Enabled = false;
            this.txtCostoUnitario.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoUnitario.ForeColor = System.Drawing.Color.Black;
            this.txtCostoUnitario.Location = new System.Drawing.Point(943, 320);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.ReadOnly = true;
            this.txtCostoUnitario.Size = new System.Drawing.Size(434, 30);
            this.txtCostoUnitario.TabIndex = 48;
            this.txtCostoUnitario.TextChanged += new System.EventHandler(this.txtCostoUnitario_TextChanged);
            // 
            // cboInsumo
            // 
            this.cboInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInsumo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboInsumo.ForeColor = System.Drawing.Color.Black;
            this.cboInsumo.FormattingEnabled = true;
            this.cboInsumo.Items.AddRange(new object[] {
            "JUAN MARTINEZ",
            "MARIA GUZMAN",
            "ANTONIO RAMIREZ",
            "SANDRA ACEVEDO",
            "NICOL GUTIERREZ",
            "RODRIGO MENDOZA",
            "OSCAR PEREZ"});
            this.cboInsumo.Location = new System.Drawing.Point(204, 320);
            this.cboInsumo.Name = "cboInsumo";
            this.cboInsumo.Size = new System.Drawing.Size(449, 31);
            this.cboInsumo.TabIndex = 47;
            this.cboInsumo.Tag = "ORDENES ACTIVAS";
            this.cboInsumo.SelectedIndexChanged += new System.EventHandler(this.cboInsumo_SelectedIndexChanged);
            // 
            // numUpDownCantidad
            // 
            this.numUpDownCantidad.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDownCantidad.Location = new System.Drawing.Point(204, 379);
            this.numUpDownCantidad.Name = "numUpDownCantidad";
            this.numUpDownCantidad.Size = new System.Drawing.Size(186, 30);
            this.numUpDownCantidad.TabIndex = 51;
            this.numUpDownCantidad.ValueChanged += new System.EventHandler(this.numUpDownCantidad_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(732, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 27);
            this.label9.TabIndex = 52;
            this.label9.Text = "Costo unitario:";
            // 
            // btnAgregarInsumo
            // 
            this.btnAgregarInsumo.BackColor = System.Drawing.Color.White;
            this.btnAgregarInsumo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarInsumo.ForeColor = System.Drawing.Color.DarkRed;
            this.btnAgregarInsumo.Location = new System.Drawing.Point(67, 437);
            this.btnAgregarInsumo.Name = "btnAgregarInsumo";
            this.btnAgregarInsumo.Size = new System.Drawing.Size(586, 54);
            this.btnAgregarInsumo.TabIndex = 53;
            this.btnAgregarInsumo.Text = "AGREGAR INSUMO";
            this.btnAgregarInsumo.UseVisualStyleBackColor = false;
            this.btnAgregarInsumo.Click += new System.EventHandler(this.btnAgregarInsumo_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(33, 532);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(313, 29);
            this.label10.TabIndex = 55;
            this.label10.Text = "DETALLE DE LA COMPRA";
            // 
            // dgvDetalleCompra
            // 
            this.dgvDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleCompra.Location = new System.Drawing.Point(38, 584);
            this.dgvDetalleCompra.Name = "dgvDetalleCompra";
            this.dgvDetalleCompra.RowHeadersWidth = 62;
            this.dgvDetalleCompra.RowTemplate.Height = 28;
            this.dgvDetalleCompra.Size = new System.Drawing.Size(1428, 258);
            this.dgvDetalleCompra.TabIndex = 56;
            this.dgvDetalleCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleCompra_CellContentClick);
            // 
            // btnRegistrarCompra
            // 
            this.btnRegistrarCompra.BackColor = System.Drawing.Color.White;
            this.btnRegistrarCompra.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarCompra.ForeColor = System.Drawing.Color.DarkRed;
            this.btnRegistrarCompra.Location = new System.Drawing.Point(510, 887);
            this.btnRegistrarCompra.Name = "btnRegistrarCompra";
            this.btnRegistrarCompra.Size = new System.Drawing.Size(411, 54);
            this.btnRegistrarCompra.TabIndex = 58;
            this.btnRegistrarCompra.Text = "REGISTRAR COMPRA";
            this.btnRegistrarCompra.UseVisualStyleBackColor = false;
            this.btnRegistrarCompra.Click += new System.EventHandler(this.btnRegistrarCompra_Click);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.BackColor = System.Drawing.Color.White;
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.ForeColor = System.Drawing.Color.DarkRed;
            this.btnLimpiarCampos.Location = new System.Drawing.Point(38, 887);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(411, 54);
            this.btnLimpiarCampos.TabIndex = 57;
            this.btnLimpiarCampos.Text = "CANCELAR";
            this.btnLimpiarCampos.UseVisualStyleBackColor = false;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(997, 896);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(211, 29);
            this.label11.TabIndex = 60;
            this.label11.Text = "TOTAL COMPRA:";
            // 
            // txtTotalCompra
            // 
            this.txtTotalCompra.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTotalCompra.Enabled = false;
            this.txtTotalCompra.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCompra.ForeColor = System.Drawing.Color.Black;
            this.txtTotalCompra.Location = new System.Drawing.Point(1225, 890);
            this.txtTotalCompra.Name = "txtTotalCompra";
            this.txtTotalCompra.ReadOnly = true;
            this.txtTotalCompra.Size = new System.Drawing.Size(241, 41);
            this.txtTotalCompra.TabIndex = 59;
            this.txtTotalCompra.TextChanged += new System.EventHandler(this.txtTotalCompra_TextChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.White;
            this.btnNuevo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.DarkRed;
            this.btnNuevo.Location = new System.Drawing.Point(1179, 198);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(209, 49);
            this.btnNuevo.TabIndex = 61;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // frmRegistroCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 983);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTotalCompra);
            this.Controls.Add(this.btnRegistrarCompra);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.dgvDetalleCompra);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAgregarInsumo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numUpDownCantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCostoUnitario);
            this.Controls.Add(this.cboInsumo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaCompra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumDoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboProveedores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Name = "frmRegistroCompra";
            this.Text = "frmRegistroCompra";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboProveedores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCostoUnitario;
        private System.Windows.Forms.ComboBox cboInsumo;
        private System.Windows.Forms.NumericUpDown numUpDownCantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAgregarInsumo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvDetalleCompra;
        private System.Windows.Forms.Button btnRegistrarCompra;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalCompra;
        private System.Windows.Forms.Button btnNuevo;
    }
}