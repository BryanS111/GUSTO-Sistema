namespace SistemaInventarioWF
{
    partial class frmDireccionLocalPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDireccionLocalPopup));
            this.label4 = new System.Windows.Forms.Label();
            this.cboMunicipio = new System.Windows.Forms.ComboBox();
            this.txtColoniaBarrio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEstablecerDireccion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Colonia/Barrio";
            // 
            // cboMunicipio
            // 
            this.cboMunicipio.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMunicipio.FormattingEnabled = true;
            this.cboMunicipio.Location = new System.Drawing.Point(57, 122);
            this.cboMunicipio.Margin = new System.Windows.Forms.Padding(4);
            this.cboMunicipio.Name = "cboMunicipio";
            this.cboMunicipio.Size = new System.Drawing.Size(386, 33);
            this.cboMunicipio.TabIndex = 9;
            this.cboMunicipio.SelectedIndexChanged += new System.EventHandler(this.cboMunicipio_SelectedIndexChanged);
            // 
            // txtColoniaBarrio
            // 
            this.txtColoniaBarrio.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColoniaBarrio.Location = new System.Drawing.Point(57, 197);
            this.txtColoniaBarrio.Margin = new System.Windows.Forms.Padding(4);
            this.txtColoniaBarrio.Name = "txtColoniaBarrio";
            this.txtColoniaBarrio.Size = new System.Drawing.Size(386, 32);
            this.txtColoniaBarrio.TabIndex = 12;
            this.txtColoniaBarrio.TextChanged += new System.EventHandler(this.txtColoniaBarrio_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Municipio";
            // 
            // btnEstablecerDireccion
            // 
            this.btnEstablecerDireccion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEstablecerDireccion.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnEstablecerDireccion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstablecerDireccion.ForeColor = System.Drawing.Color.DarkRed;
            this.btnEstablecerDireccion.Location = new System.Drawing.Point(484, 122);
            this.btnEstablecerDireccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEstablecerDireccion.Name = "btnEstablecerDireccion";
            this.btnEstablecerDireccion.Size = new System.Drawing.Size(206, 107);
            this.btnEstablecerDireccion.TabIndex = 36;
            this.btnEstablecerDireccion.Text = "ESTABLECER DIRECCION";
            this.btnEstablecerDireccion.UseVisualStyleBackColor = false;
            this.btnEstablecerDireccion.Click += new System.EventHandler(this.btnEstablecerDireccion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 33);
            this.label1.TabIndex = 37;
            this.label1.Text = "ESTABLECE LA DIRECCIOND EL LOCAL:";
            // 
            // frmDireccionLocalPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 276);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEstablecerDireccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboMunicipio);
            this.Controls.Add(this.txtColoniaBarrio);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDireccionLocalPopup";
            this.Text = "DIRECCION - LOCAL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMunicipio;
        private System.Windows.Forms.TextBox txtColoniaBarrio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEstablecerDireccion;
        private System.Windows.Forms.Label label1;
    }
}