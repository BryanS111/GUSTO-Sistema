namespace SistemaInventarioWF
{
    partial class frmProcesos_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesos_Menu));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnMenuCombos = new System.Windows.Forms.Button();
            this.btnRepartidores = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(115, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(458, 290);
            this.label2.TabIndex = 26;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(325, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(839, 45);
            this.label1.TabIndex = 25;
            this.label1.Text = "DASHBOARD - PROCESOS TRANSACCIONALES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProveedores.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnProveedores.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.ForeColor = System.Drawing.Color.DarkRed;
            this.btnProveedores.Location = new System.Drawing.Point(716, 398);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(651, 102);
            this.btnProveedores.TabIndex = 23;
            this.btnProveedores.Text = "CONSULTA DE STOCK DE INVENTARIO";
            this.btnProveedores.UseVisualStyleBackColor = false;
            // 
            // btnMenuCombos
            // 
            this.btnMenuCombos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMenuCombos.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnMenuCombos.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuCombos.ForeColor = System.Drawing.Color.DarkRed;
            this.btnMenuCombos.Location = new System.Drawing.Point(716, 516);
            this.btnMenuCombos.Name = "btnMenuCombos";
            this.btnMenuCombos.Size = new System.Drawing.Size(651, 102);
            this.btnMenuCombos.TabIndex = 22;
            this.btnMenuCombos.Text = "CONSULTA DE HISTORIAL DE AUDITORIA";
            this.btnMenuCombos.UseVisualStyleBackColor = false;
            // 
            // btnRepartidores
            // 
            this.btnRepartidores.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRepartidores.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnRepartidores.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepartidores.ForeColor = System.Drawing.Color.DarkRed;
            this.btnRepartidores.Location = new System.Drawing.Point(716, 772);
            this.btnRepartidores.Name = "btnRepartidores";
            this.btnRepartidores.Size = new System.Drawing.Size(651, 102);
            this.btnRepartidores.TabIndex = 21;
            this.btnRepartidores.Text = "CONSULTA DE COMPRAS POR PROVEEDOR";
            this.btnRepartidores.UseVisualStyleBackColor = false;
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEmpleados.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnEmpleados.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleados.ForeColor = System.Drawing.Color.DarkRed;
            this.btnEmpleados.Location = new System.Drawing.Point(716, 638);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Size = new System.Drawing.Size(651, 102);
            this.btnEmpleados.TabIndex = 20;
            this.btnEmpleados.Text = "CONSULTA DE ORDENES ACTIVA";
            this.btnEmpleados.UseVisualStyleBackColor = false;
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnClientes.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.DarkRed;
            this.btnClientes.Location = new System.Drawing.Point(716, 280);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(651, 102);
            this.btnClientes.TabIndex = 19;
            this.btnClientes.Text = "CONSULTA DE VENTAS POR FECHA";
            this.btnClientes.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SistemaInventarioWF.Properties.Resources.logo_1000x1000px;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(222, 654);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 220);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // frmProcesos_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 983);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProveedores);
            this.Controls.Add(this.btnMenuCombos);
            this.Controls.Add(this.btnRepartidores);
            this.Controls.Add(this.btnEmpleados);
            this.Controls.Add(this.btnClientes);
            this.Name = "frmProcesos_Menu";
            this.Text = "frmProcesos_Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnMenuCombos;
        private System.Windows.Forms.Button btnRepartidores;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}