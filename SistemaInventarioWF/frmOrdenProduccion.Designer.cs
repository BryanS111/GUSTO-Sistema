namespace SistemaInventarioWF
{
    partial class frmOrdenProduccion
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumOrden = new System.Windows.Forms.TextBox();
            this.cboEmpleado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboInsumo = new System.Windows.Forms.ComboBox();
            this.numUpDownCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregarInsumo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductoFinal = new System.Windows.Forms.ComboBox();
            this.txtCostoUnitario = new System.Windows.Forms.TextBox();
            this.txtTotalCosto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numUpDownCantidadProducto = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 19);
            this.label8.TabIndex = 37;
            this.label8.Text = "ORDEN DE PRODUCCION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(597, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(302, 29);
            this.label4.TabIndex = 40;
            this.label4.Text = "DATOS DE PRODUCCION";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkRed;
            this.textBox1.Location = new System.Drawing.Point(-2, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1527, 26);
            this.textBox1.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(61, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 29);
            this.label2.TabIndex = 48;
            this.label2.Text = "NUMERO DE ORDEN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(61, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 29);
            this.label1.TabIndex = 47;
            this.label1.Text = "COCINERO/A:";
            // 
            // txtNumOrden
            // 
            this.txtNumOrden.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtNumOrden.Enabled = false;
            this.txtNumOrden.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumOrden.ForeColor = System.Drawing.Color.LightGray;
            this.txtNumOrden.Location = new System.Drawing.Point(341, 172);
            this.txtNumOrden.Name = "txtNumOrden";
            this.txtNumOrden.ReadOnly = true;
            this.txtNumOrden.Size = new System.Drawing.Size(178, 30);
            this.txtNumOrden.TabIndex = 46;
            this.txtNumOrden.TextChanged += new System.EventHandler(this.txtNumOrden_TextChanged);
            // 
            // cboEmpleado
            // 
            this.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpleado.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpleado.ForeColor = System.Drawing.Color.Black;
            this.cboEmpleado.FormattingEnabled = true;
            this.cboEmpleado.Location = new System.Drawing.Point(262, 108);
            this.cboEmpleado.Name = "cboEmpleado";
            this.cboEmpleado.Size = new System.Drawing.Size(496, 31);
            this.cboEmpleado.TabIndex = 45;
            this.cboEmpleado.Tag = "ORDENES ACTIVAS";
            this.cboEmpleado.SelectedIndexChanged += new System.EventHandler(this.cboEmpleado_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(846, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 29);
            this.label3.TabIndex = 49;
            this.label3.Text = "FECHA:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(981, 110);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(474, 30);
            this.dtpFecha.TabIndex = 50;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(553, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(391, 29);
            this.label5.TabIndex = 52;
            this.label5.Text = "SELECCION DE MATERIA PRIMA";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DarkRed;
            this.textBox2.Location = new System.Drawing.Point(-2, 240);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1527, 26);
            this.textBox2.TabIndex = 51;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(61, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 29);
            this.label6.TabIndex = 56;
            this.label6.Text = "CANTIDAD (LIBRAS):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(61, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 29);
            this.label7.TabIndex = 55;
            this.label7.Text = "INSUMO:";
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
            this.cboInsumo.Location = new System.Drawing.Point(228, 301);
            this.cboInsumo.Name = "cboInsumo";
            this.cboInsumo.Size = new System.Drawing.Size(441, 31);
            this.cboInsumo.TabIndex = 53;
            this.cboInsumo.Tag = "ORDENES ACTIVAS";
            this.cboInsumo.SelectedIndexChanged += new System.EventHandler(this.cboInsumo_SelectedIndexChanged);
            // 
            // numUpDownCantidad
            // 
            this.numUpDownCantidad.DecimalPlaces = 2;
            this.numUpDownCantidad.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDownCantidad.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numUpDownCantidad.Location = new System.Drawing.Point(323, 371);
            this.numUpDownCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDownCantidad.Name = "numUpDownCantidad";
            this.numUpDownCantidad.Size = new System.Drawing.Size(181, 30);
            this.numUpDownCantidad.TabIndex = 57;
            this.numUpDownCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDownCantidad.ValueChanged += new System.EventHandler(this.numUpDownCantidad_ValueChanged);
            // 
            // btnAgregarInsumo
            // 
            this.btnAgregarInsumo.BackColor = System.Drawing.Color.DarkRed;
            this.btnAgregarInsumo.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarInsumo.ForeColor = System.Drawing.Color.Transparent;
            this.btnAgregarInsumo.Location = new System.Drawing.Point(66, 440);
            this.btnAgregarInsumo.Name = "btnAgregarInsumo";
            this.btnAgregarInsumo.Size = new System.Drawing.Size(453, 54);
            this.btnAgregarInsumo.TabIndex = 58;
            this.btnAgregarInsumo.Text = "AGREGAR INSUMO";
            this.btnAgregarInsumo.UseVisualStyleBackColor = false;
            this.btnAgregarInsumo.Click += new System.EventHandler(this.btnAgregarInsumo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(460, 526);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(577, 29);
            this.label9.TabIndex = 60;
            this.label9.Text = "INGREDIENTES A DESCONTAR DEL INVENTARIO";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.DarkRed;
            this.textBox4.Location = new System.Drawing.Point(-2, 526);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(1527, 26);
            this.textBox4.TabIndex = 59;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(53, 600);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.Size = new System.Drawing.Size(1402, 243);
            this.dgvDetalle.TabIndex = 61;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellContentClick);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.DarkRed;
            this.btnConfirmar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.Location = new System.Drawing.Point(525, 899);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(419, 54);
            this.btnConfirmar.TabIndex = 63;
            this.btnConfirmar.Text = "REGISTRAR PRODUCCION";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.DarkRed;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.Location = new System.Drawing.Point(53, 899);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(419, 54);
            this.btnLimpiar.TabIndex = 62;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(762, 306);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(224, 29);
            this.label10.TabIndex = 64;
            this.label10.Text = "COSTO UNITARIO:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(553, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(233, 29);
            this.label11.TabIndex = 66;
            this.label11.Text = "PRODUCTO FINAL:";
            // 
            // txtProductoFinal
            // 
            this.txtProductoFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtProductoFinal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductoFinal.ForeColor = System.Drawing.Color.Black;
            this.txtProductoFinal.FormattingEnabled = true;
            this.txtProductoFinal.Items.AddRange(new object[] {
            "JUAN MARTINEZ",
            "MARIA GUZMAN",
            "ANTONIO RAMIREZ",
            "SANDRA ACEVEDO",
            "NICOL GUTIERREZ",
            "RODRIGO MENDOZA",
            "OSCAR PEREZ"});
            this.txtProductoFinal.Location = new System.Drawing.Point(792, 172);
            this.txtProductoFinal.Name = "txtProductoFinal";
            this.txtProductoFinal.Size = new System.Drawing.Size(302, 31);
            this.txtProductoFinal.TabIndex = 65;
            this.txtProductoFinal.Tag = "ORDENES ACTIVAS";
            this.txtProductoFinal.SelectedIndexChanged += new System.EventHandler(this.txtProductoFinal_SelectedIndexChanged);
            // 
            // txtCostoUnitario
            // 
            this.txtCostoUnitario.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCostoUnitario.Enabled = false;
            this.txtCostoUnitario.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoUnitario.ForeColor = System.Drawing.Color.LightGray;
            this.txtCostoUnitario.Location = new System.Drawing.Point(992, 306);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.ReadOnly = true;
            this.txtCostoUnitario.Size = new System.Drawing.Size(311, 30);
            this.txtCostoUnitario.TabIndex = 67;
            this.txtCostoUnitario.TextChanged += new System.EventHandler(this.txtCostoUnitario_TextChanged);
            // 
            // txtTotalCosto
            // 
            this.txtTotalCosto.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTotalCosto.Enabled = false;
            this.txtTotalCosto.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCosto.ForeColor = System.Drawing.Color.LightGray;
            this.txtTotalCosto.Location = new System.Drawing.Point(1244, 914);
            this.txtTotalCosto.Name = "txtTotalCosto";
            this.txtTotalCosto.ReadOnly = true;
            this.txtTotalCosto.Size = new System.Drawing.Size(211, 30);
            this.txtTotalCosto.TabIndex = 69;
            this.txtTotalCosto.TextChanged += new System.EventHandler(this.txtTotalCosto_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(1024, 913);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(189, 29);
            this.label12.TabIndex = 68;
            this.label12.Text = "COSTO TOTAL:";
            // 
            // numUpDownCantidadProducto
            // 
            this.numUpDownCantidadProducto.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDownCantidadProducto.Location = new System.Drawing.Point(1302, 170);
            this.numUpDownCantidadProducto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownCantidadProducto.Name = "numUpDownCantidadProducto";
            this.numUpDownCantidadProducto.Size = new System.Drawing.Size(153, 30);
            this.numUpDownCantidadProducto.TabIndex = 70;
            this.numUpDownCantidadProducto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownCantidadProducto.ValueChanged += new System.EventHandler(this.numUpDownCantidadProducto_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(1138, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 29);
            this.label13.TabIndex = 71;
            this.label13.Text = "CANTIDAD:";
            // 
            // frmOrdenProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 983);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numUpDownCantidadProducto);
            this.Controls.Add(this.txtTotalCosto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCostoUnitario);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtProductoFinal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btnAgregarInsumo);
            this.Controls.Add(this.numUpDownCantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboInsumo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumOrden);
            this.Controls.Add(this.cboEmpleado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Name = "frmOrdenProduccion";
            this.Text = "frmOrdenProduccion";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumOrden;
        private System.Windows.Forms.ComboBox cboEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboInsumo;
        private System.Windows.Forms.NumericUpDown numUpDownCantidad;
        private System.Windows.Forms.Button btnAgregarInsumo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox txtProductoFinal;
        private System.Windows.Forms.TextBox txtCostoUnitario;
        private System.Windows.Forms.TextBox txtTotalCosto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numUpDownCantidadProducto;
        private System.Windows.Forms.Label label13;
    }
}