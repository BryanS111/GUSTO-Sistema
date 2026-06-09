namespace SistemaInventarioWF
{
    partial class frmProcesoVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboOrdenesPendientes = new System.Windows.Forms.ComboBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetalleOrden = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNoDocumento = new System.Windows.Forms.TextBox();
            this.txtTotalOrden = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTipoOrden = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMetodoPago = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMontoRecibido = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(716, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 27);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cliente encontrado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(35, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(372, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "BUSQUEDA DE ORDEN ACTIVA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(36, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ordenes pendientes:";
            // 
            // cboOrdenesPendientes
            // 
            this.cboOrdenesPendientes.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboOrdenesPendientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenesPendientes.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrdenesPendientes.ForeColor = System.Drawing.Color.Black;
            this.cboOrdenesPendientes.FormattingEnabled = true;
            this.cboOrdenesPendientes.Location = new System.Drawing.Point(280, 120);
            this.cboOrdenesPendientes.Name = "cboOrdenesPendientes";
            this.cboOrdenesPendientes.Size = new System.Drawing.Size(367, 31);
            this.cboOrdenesPendientes.TabIndex = 10;
            this.cboOrdenesPendientes.Tag = "ORDENES ACTIVAS";
            this.cboOrdenesPendientes.SelectedIndexChanged += new System.EventHandler(this.cboOrdenesPendientes_SelectedIndexChanged);
            // 
            // txtCliente
            // 
            this.txtCliente.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCliente.Location = new System.Drawing.Point(970, 114);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(425, 30);
            this.txtCliente.TabIndex = 21;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(36, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 29);
            this.label2.TabIndex = 24;
            this.label2.Text = "DETALLE ORDEN";
            // 
            // dgvDetalleOrden
            // 
            this.dgvDetalleOrden.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDetalleOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleOrden.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvDetalleOrden.Location = new System.Drawing.Point(17, 277);
            this.dgvDetalleOrden.Name = "dgvDetalleOrden";
            this.dgvDetalleOrden.RowHeadersWidth = 62;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dgvDetalleOrden.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalleOrden.RowTemplate.Height = 28;
            this.dgvDetalleOrden.Size = new System.Drawing.Size(1469, 365);
            this.dgvDetalleOrden.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(35, 678);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 29);
            this.label3.TabIndex = 27;
            this.label3.Text = "PROCESO DE PAGO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(60, 735);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(347, 27);
            this.label7.TabIndex = 28;
            this.label7.Text = "Num. de documento generado:";
            // 
            // txtNoDocumento
            // 
            this.txtNoDocumento.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtNoDocumento.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoDocumento.ForeColor = System.Drawing.Color.LightGray;
            this.txtNoDocumento.Location = new System.Drawing.Point(436, 732);
            this.txtNoDocumento.Name = "txtNoDocumento";
            this.txtNoDocumento.ReadOnly = true;
            this.txtNoDocumento.Size = new System.Drawing.Size(500, 30);
            this.txtNoDocumento.TabIndex = 29;
            this.txtNoDocumento.TextChanged += new System.EventHandler(this.txtNoDocumento_TextChanged);
            // 
            // txtTotalOrden
            // 
            this.txtTotalOrden.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTotalOrden.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalOrden.ForeColor = System.Drawing.Color.Black;
            this.txtTotalOrden.Location = new System.Drawing.Point(1141, 868);
            this.txtTotalOrden.Name = "txtTotalOrden";
            this.txtTotalOrden.ReadOnly = true;
            this.txtTotalOrden.Size = new System.Drawing.Size(206, 30);
            this.txtTotalOrden.TabIndex = 31;
            this.txtTotalOrden.TextChanged += new System.EventHandler(this.txtTotalOrden_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(1136, 804);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(211, 29);
            this.label6.TabIndex = 30;
            this.label6.Text = "TOTAL A PAGAR:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox1.Location = new System.Drawing.Point(1042, 775);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(401, 163);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.White;
            this.btnCobrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCobrar.Location = new System.Drawing.Point(536, 906);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(411, 54);
            this.btnCobrar.TabIndex = 34;
            this.btnCobrar.Text = "COBRAR";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnLimpiar.Location = new System.Drawing.Point(64, 906);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(411, 54);
            this.btnLimpiar.TabIndex = 33;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(33, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(339, 37);
            this.label8.TabIndex = 35;
            this.label8.Text = "PROCESO DE VENTA";
            // 
            // txtTipoOrden
            // 
            this.txtTipoOrden.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTipoOrden.Enabled = false;
            this.txtTipoOrden.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoOrden.ForeColor = System.Drawing.Color.Black;
            this.txtTipoOrden.Location = new System.Drawing.Point(197, 168);
            this.txtTipoOrden.Name = "txtTipoOrden";
            this.txtTipoOrden.ReadOnly = true;
            this.txtTipoOrden.Size = new System.Drawing.Size(450, 30);
            this.txtTipoOrden.TabIndex = 37;
            this.txtTipoOrden.TextChanged += new System.EventHandler(this.txtTipoOrden_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(36, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 27);
            this.label9.TabIndex = 36;
            this.label9.Text = "Tipo orden:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(716, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 27);
            this.label11.TabIndex = 40;
            this.label11.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(827, 165);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(568, 30);
            this.dtpFecha.TabIndex = 41;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(61, 791);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 27);
            this.label10.TabIndex = 43;
            this.label10.Text = "Metodo de pago:";
            // 
            // cboMetodoPago
            // 
            this.cboMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoPago.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMetodoPago.ForeColor = System.Drawing.Color.Black;
            this.cboMetodoPago.FormattingEnabled = true;
            this.cboMetodoPago.Location = new System.Drawing.Point(278, 790);
            this.cboMetodoPago.Name = "cboMetodoPago";
            this.cboMetodoPago.Size = new System.Drawing.Size(658, 31);
            this.cboMetodoPago.TabIndex = 42;
            this.cboMetodoPago.Tag = "ORDENES ACTIVAS";
            this.cboMetodoPago.SelectedIndexChanged += new System.EventHandler(this.cboMetodoPago_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(63, 848);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 27);
            this.label12.TabIndex = 44;
            this.label12.Text = "Monto recibido:";
            // 
            // txtMontoRecibido
            // 
            this.txtMontoRecibido.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtMontoRecibido.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoRecibido.ForeColor = System.Drawing.Color.Black;
            this.txtMontoRecibido.Location = new System.Drawing.Point(280, 845);
            this.txtMontoRecibido.Name = "txtMontoRecibido";
            this.txtMontoRecibido.Size = new System.Drawing.Size(271, 30);
            this.txtMontoRecibido.TabIndex = 45;
            this.txtMontoRecibido.TextChanged += new System.EventHandler(this.txtMontoRecibido_TextChanged);
            // 
            // frmProcesoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 983);
            this.Controls.Add(this.txtMontoRecibido);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboMetodoPago);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTipoOrden);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtTotalOrden);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNoDocumento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDetalleOrden);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboOrdenesPendientes);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Name = "frmProcesoVenta";
            this.Text = "frmProcesoVenta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboOrdenesPendientes;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetalleOrden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalOrden;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTipoOrden;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNoDocumento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMetodoPago;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMontoRecibido;
    }
}