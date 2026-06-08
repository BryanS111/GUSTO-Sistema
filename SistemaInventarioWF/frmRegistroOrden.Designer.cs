namespace SistemaInventarioWF
{
    partial class frmRegistroOrden
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
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaOrden = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboProductosMenu = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCombos = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numUpDownCantidadMenuOCombo = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrecioMenuOCombo = new System.Windows.Forms.TextBox();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.dgvDetalleOrden = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmarOrden = new System.Windows.Forms.Button();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCrudDescuentos = new System.Windows.Forms.Button();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.cboTipoOrden = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadMenuOCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).BeginInit();
            this.SuspendLayout();
            // 
            // cboClientes
            // 
            this.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClientes.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(230, 123);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(455, 31);
            this.cboClientes.TabIndex = 0;
            this.cboClientes.SelectedIndexChanged += new System.EventHandler(this.cboClientes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(86, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "CLIENTE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(743, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "TIPO ORDEN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(743, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "DESCUENTO:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkRed;
            this.textBox1.Location = new System.Drawing.Point(-2, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1527, 26);
            this.textBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(569, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "DATOS GENERALES";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(86, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "FECHA:";
            // 
            // dtpFechaOrden
            // 
            this.dtpFechaOrden.CalendarFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaOrden.Enabled = false;
            this.dtpFechaOrden.Location = new System.Drawing.Point(230, 194);
            this.dtpFechaOrden.Name = "dtpFechaOrden";
            this.dtpFechaOrden.Size = new System.Drawing.Size(455, 26);
            this.dtpFechaOrden.TabIndex = 9;
            this.dtpFechaOrden.ValueChanged += new System.EventHandler(this.dtpFechaOrden_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(520, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(349, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "SELECCION DEL PRODUCTO";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DarkRed;
            this.textBox2.Location = new System.Drawing.Point(-2, 280);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1527, 26);
            this.textBox2.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(86, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 29);
            this.label7.TabIndex = 13;
            this.label7.Text = "PRODUCTO:";
            // 
            // cboProductosMenu
            // 
            this.cboProductosMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductosMenu.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductosMenu.FormattingEnabled = true;
            this.cboProductosMenu.Location = new System.Drawing.Point(260, 354);
            this.cboProductosMenu.Name = "cboProductosMenu";
            this.cboProductosMenu.Size = new System.Drawing.Size(425, 31);
            this.cboProductosMenu.TabIndex = 12;
            this.cboProductosMenu.SelectedIndexChanged += new System.EventHandler(this.cboProductosMenu_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(86, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 29);
            this.label8.TabIndex = 15;
            this.label8.Text = "COMBO:";
            // 
            // cboCombos
            // 
            this.cboCombos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCombos.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCombos.FormattingEnabled = true;
            this.cboCombos.Location = new System.Drawing.Point(260, 436);
            this.cboCombos.Name = "cboCombos";
            this.cboCombos.Size = new System.Drawing.Size(425, 31);
            this.cboCombos.TabIndex = 14;
            this.cboCombos.SelectedIndexChanged += new System.EventHandler(this.cboCombos_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(743, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 29);
            this.label9.TabIndex = 17;
            this.label9.Text = "CANTIDAD:";
            // 
            // numUpDownCantidadMenuOCombo
            // 
            this.numUpDownCantidadMenuOCombo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDownCantidadMenuOCombo.Location = new System.Drawing.Point(907, 355);
            this.numUpDownCantidadMenuOCombo.Name = "numUpDownCantidadMenuOCombo";
            this.numUpDownCantidadMenuOCombo.Size = new System.Drawing.Size(129, 30);
            this.numUpDownCantidadMenuOCombo.TabIndex = 18;
            this.numUpDownCantidadMenuOCombo.ValueChanged += new System.EventHandler(this.numUpDownCantidadMenuOCombo_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(1077, 354);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 29);
            this.label10.TabIndex = 19;
            this.label10.Text = "PRECIO:";
            // 
            // txtPrecioMenuOCombo
            // 
            this.txtPrecioMenuOCombo.Enabled = false;
            this.txtPrecioMenuOCombo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioMenuOCombo.ForeColor = System.Drawing.Color.SeaGreen;
            this.txtPrecioMenuOCombo.Location = new System.Drawing.Point(1218, 357);
            this.txtPrecioMenuOCombo.Name = "txtPrecioMenuOCombo";
            this.txtPrecioMenuOCombo.ReadOnly = true;
            this.txtPrecioMenuOCombo.Size = new System.Drawing.Size(200, 30);
            this.txtPrecioMenuOCombo.TabIndex = 20;
            this.txtPrecioMenuOCombo.TextChanged += new System.EventHandler(this.txtPrecioMenuOCombo_TextChanged);
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.BackColor = System.Drawing.Color.DarkRed;
            this.btnAgregarItem.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarItem.ForeColor = System.Drawing.Color.Transparent;
            this.btnAgregarItem.Location = new System.Drawing.Point(748, 411);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(670, 54);
            this.btnAgregarItem.TabIndex = 21;
            this.btnAgregarItem.Text = "AGREGAR ITEM";
            this.btnAgregarItem.UseVisualStyleBackColor = false;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(569, 509);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(251, 29);
            this.label11.TabIndex = 23;
            this.label11.Text = "CARRITO / DETALLE";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.DarkRed;
            this.textBox4.Location = new System.Drawing.Point(-2, 509);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(1527, 26);
            this.textBox4.TabIndex = 22;
            // 
            // dgvDetalleOrden
            // 
            this.dgvDetalleOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleOrden.Location = new System.Drawing.Point(53, 586);
            this.dgvDetalleOrden.Name = "dgvDetalleOrden";
            this.dgvDetalleOrden.RowHeadersWidth = 62;
            this.dgvDetalleOrden.RowTemplate.Height = 28;
            this.dgvDetalleOrden.Size = new System.Drawing.Size(1407, 247);
            this.dgvDetalleOrden.TabIndex = 24;
            this.dgvDetalleOrden.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleOrden_CellContentClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancelar.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Location = new System.Drawing.Point(53, 896);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(411, 54);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmarOrden
            // 
            this.btnConfirmarOrden.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnConfirmarOrden.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarOrden.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnConfirmarOrden.Location = new System.Drawing.Point(525, 896);
            this.btnConfirmarOrden.Name = "btnConfirmarOrden";
            this.btnConfirmarOrden.Size = new System.Drawing.Size(411, 54);
            this.btnConfirmarOrden.TabIndex = 26;
            this.btnConfirmarOrden.Text = "CONFIRMAR ORDEN";
            this.btnConfirmarOrden.UseVisualStyleBackColor = false;
            this.btnConfirmarOrden.Click += new System.EventHandler(this.btnConfirmarOrden_Click);
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPagar.ForeColor = System.Drawing.Color.SeaGreen;
            this.txtTotalPagar.Location = new System.Drawing.Point(1234, 909);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(226, 35);
            this.txtTotalPagar.TabIndex = 28;
            this.txtTotalPagar.TextChanged += new System.EventHandler(this.txtTotalPagar_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(993, 905);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(235, 33);
            this.label12.TabIndex = 27;
            this.label12.Text = "TOTAL A PAGAR:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(13, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 19);
            this.label13.TabIndex = 36;
            this.label13.Text = "REGISTRO ORDEN";
            // 
            // btnCrudDescuentos
            // 
            this.btnCrudDescuentos.BackColor = System.Drawing.Color.DarkRed;
            this.btnCrudDescuentos.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrudDescuentos.ForeColor = System.Drawing.Color.Transparent;
            this.btnCrudDescuentos.Location = new System.Drawing.Point(1289, 187);
            this.btnCrudDescuentos.Name = "btnCrudDescuentos";
            this.btnCrudDescuentos.Size = new System.Drawing.Size(171, 42);
            this.btnCrudDescuentos.TabIndex = 37;
            this.btnCrudDescuentos.Text = "CRUD - Descuentos";
            this.btnCrudDescuentos.UseVisualStyleBackColor = false;
            this.btnCrudDescuentos.Click += new System.EventHandler(this.btnCrudDescuentos_Click);
            // 
            // txtDescuento
            // 
            this.txtDescuento.Enabled = false;
            this.txtDescuento.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.ForeColor = System.Drawing.Color.SeaGreen;
            this.txtDescuento.HideSelection = false;
            this.txtDescuento.Location = new System.Drawing.Point(918, 190);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(365, 30);
            this.txtDescuento.TabIndex = 38;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            // 
            // cboTipoOrden
            // 
            this.cboTipoOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoOrden.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoOrden.FormattingEnabled = true;
            this.cboTipoOrden.Location = new System.Drawing.Point(963, 122);
            this.cboTipoOrden.Name = "cboTipoOrden";
            this.cboTipoOrden.Size = new System.Drawing.Size(497, 31);
            this.cboTipoOrden.TabIndex = 3;
            this.cboTipoOrden.SelectedIndexChanged += new System.EventHandler(this.cboTipoOrden_SelectedIndexChanged);
            // 
            // frmRegistroOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 983);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.btnCrudDescuentos);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnConfirmarOrden);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvDetalleOrden);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btnAgregarItem);
            this.Controls.Add(this.txtPrecioMenuOCombo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numUpDownCantidadMenuOCombo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboCombos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboProductosMenu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dtpFechaOrden);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTipoOrden);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboClientes);
            this.Name = "frmRegistroOrden";
            this.Text = "frmRegistroOrden";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownCantidadMenuOCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaOrden;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboProductosMenu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCombos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numUpDownCantidadMenuOCombo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrecioMenuOCombo;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.DataGridView dgvDetalleOrden;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmarOrden;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCrudDescuentos;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.ComboBox cboTipoOrden;
    }
}