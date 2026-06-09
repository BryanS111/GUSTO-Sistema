namespace SistemaInventarioWF
{
    partial class frmProcesoDelivery
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
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboOrdenesPendientes = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRepartidorDisponible = new System.Windows.Forms.ComboBox();
            this.btnAsignarEnvio = new System.Windows.Forms.Button();
            this.btnLimpiarPantalla = new System.Windows.Forms.Button();
            this.txtCoordenadas = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDireccionLocal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(29, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(389, 37);
            this.label8.TabIndex = 36;
            this.label8.Text = "PROCESO DE DELIVERY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(31, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(382, 29);
            this.label4.TabIndex = 38;
            this.label4.Text = "DATOS DEL PEDIDO Y DESTINO";
            // 
            // txtCliente
            // 
            this.txtCliente.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCliente.Enabled = false;
            this.txtCliente.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.Black;
            this.txtCliente.Location = new System.Drawing.Point(181, 208);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(474, 30);
            this.txtCliente.TabIndex = 42;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(50, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 27);
            this.label5.TabIndex = 41;
            this.label5.Text = "Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(50, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 27);
            this.label1.TabIndex = 40;
            this.label1.Text = "Orden pendiente:";
            // 
            // cboOrdenesPendientes
            // 
            this.cboOrdenesPendientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenesPendientes.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrdenesPendientes.ForeColor = System.Drawing.Color.Black;
            this.cboOrdenesPendientes.FormattingEnabled = true;
            this.cboOrdenesPendientes.Location = new System.Drawing.Point(283, 146);
            this.cboOrdenesPendientes.Name = "cboOrdenesPendientes";
            this.cboOrdenesPendientes.Size = new System.Drawing.Size(372, 31);
            this.cboOrdenesPendientes.TabIndex = 39;
            this.cboOrdenesPendientes.Tag = "ORDENES ACTIVAS";
            this.cboOrdenesPendientes.SelectedIndexChanged += new System.EventHandler(this.cboOrdenesPendientes_SelectedIndexChanged);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.Color.Black;
            this.txtDireccion.Location = new System.Drawing.Point(903, 149);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(530, 30);
            this.txtDireccion.TabIndex = 46;
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(750, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 27);
            this.label2.TabIndex = 45;
            this.label2.Text = "Coordenadas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(31, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 29);
            this.label3.TabIndex = 48;
            this.label3.Text = "ASIGNACION DE LOGISTICA";
            // 
            // txtTarifa
            // 
            this.txtTarifa.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTarifa.Enabled = false;
            this.txtTarifa.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarifa.ForeColor = System.Drawing.Color.Black;
            this.txtTarifa.Location = new System.Drawing.Point(164, 431);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.ReadOnly = true;
            this.txtTarifa.Size = new System.Drawing.Size(268, 30);
            this.txtTarifa.TabIndex = 52;
            this.txtTarifa.TextChanged += new System.EventHandler(this.txtTarifa_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(52, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 29);
            this.label6.TabIndex = 51;
            this.label6.Text = "Tafira:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(52, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(270, 29);
            this.label7.TabIndex = 50;
            this.label7.Text = "Repartidor disponible:";
            // 
            // cboRepartidorDisponible
            // 
            this.cboRepartidorDisponible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRepartidorDisponible.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRepartidorDisponible.ForeColor = System.Drawing.Color.Black;
            this.cboRepartidorDisponible.FormattingEnabled = true;
            this.cboRepartidorDisponible.Location = new System.Drawing.Point(340, 366);
            this.cboRepartidorDisponible.Name = "cboRepartidorDisponible";
            this.cboRepartidorDisponible.Size = new System.Drawing.Size(315, 31);
            this.cboRepartidorDisponible.TabIndex = 49;
            this.cboRepartidorDisponible.Tag = "Repartidores disponibles";
            this.cboRepartidorDisponible.SelectedIndexChanged += new System.EventHandler(this.cboRepartidorDisponible_SelectedIndexChanged);
            // 
            // btnAsignarEnvio
            // 
            this.btnAsignarEnvio.BackColor = System.Drawing.Color.White;
            this.btnAsignarEnvio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarEnvio.ForeColor = System.Drawing.Color.DarkRed;
            this.btnAsignarEnvio.Location = new System.Drawing.Point(451, 876);
            this.btnAsignarEnvio.Name = "btnAsignarEnvio";
            this.btnAsignarEnvio.Size = new System.Drawing.Size(350, 67);
            this.btnAsignarEnvio.TabIndex = 54;
            this.btnAsignarEnvio.Text = "ASIGNAR ENVIO";
            this.btnAsignarEnvio.UseVisualStyleBackColor = false;
            this.btnAsignarEnvio.Click += new System.EventHandler(this.btnAsignarEnvio_Click);
            // 
            // btnLimpiarPantalla
            // 
            this.btnLimpiarPantalla.BackColor = System.Drawing.Color.White;
            this.btnLimpiarPantalla.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarPantalla.ForeColor = System.Drawing.Color.DarkRed;
            this.btnLimpiarPantalla.Location = new System.Drawing.Point(52, 876);
            this.btnLimpiarPantalla.Name = "btnLimpiarPantalla";
            this.btnLimpiarPantalla.Size = new System.Drawing.Size(350, 67);
            this.btnLimpiarPantalla.TabIndex = 53;
            this.btnLimpiarPantalla.Text = "LIMPIAR PANTALLA";
            this.btnLimpiarPantalla.UseVisualStyleBackColor = false;
            this.btnLimpiarPantalla.Click += new System.EventHandler(this.btnLimpiarPantalla_Click);
            // 
            // txtCoordenadas
            // 
            this.txtCoordenadas.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCoordenadas.Enabled = false;
            this.txtCoordenadas.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCoordenadas.ForeColor = System.Drawing.Color.Black;
            this.txtCoordenadas.Location = new System.Drawing.Point(948, 210);
            this.txtCoordenadas.Name = "txtCoordenadas";
            this.txtCoordenadas.ReadOnly = true;
            this.txtCoordenadas.Size = new System.Drawing.Size(485, 30);
            this.txtCoordenadas.TabIndex = 56;
            this.txtCoordenadas.TextChanged += new System.EventHandler(this.txtCoordenadas_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(750, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 27);
            this.label9.TabIndex = 55;
            this.label9.Text = "Dirección:";
            // 
            // btnDireccionLocal
            // 
            this.btnDireccionLocal.BackColor = System.Drawing.Color.White;
            this.btnDireccionLocal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDireccionLocal.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDireccionLocal.Location = new System.Drawing.Point(57, 509);
            this.btnDireccionLocal.Name = "btnDireccionLocal";
            this.btnDireccionLocal.Size = new System.Drawing.Size(598, 61);
            this.btnDireccionLocal.TabIndex = 57;
            this.btnDireccionLocal.Text = "DEFINIR DIRECCION DEL LOCAL";
            this.btnDireccionLocal.UseVisualStyleBackColor = false;
            this.btnDireccionLocal.Click += new System.EventHandler(this.btnDefinirDireccionLocal_Click);
            // 
            // frmProcesoDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 983);
            this.Controls.Add(this.btnDireccionLocal);
            this.Controls.Add(this.txtCoordenadas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAsignarEnvio);
            this.Controls.Add(this.btnLimpiarPantalla);
            this.Controls.Add(this.txtTarifa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboRepartidorDisponible);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboOrdenesPendientes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Name = "frmProcesoDelivery";
            this.Text = "frmProcesoDelivery";
            this.Load += new System.EventHandler(this.frmProcesoDelivery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboOrdenesPendientes;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTarifa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboRepartidorDisponible;
        private System.Windows.Forms.Button btnAsignarEnvio;
        private System.Windows.Forms.Button btnLimpiarPantalla;
        private System.Windows.Forms.TextBox txtCoordenadas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDireccionLocal;
    }
}