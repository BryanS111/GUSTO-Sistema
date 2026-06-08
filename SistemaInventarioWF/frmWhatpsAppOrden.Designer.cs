namespace SistemaInventarioWF
{
    partial class frmWhatpsAppOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWhatpsAppOrden));
            this.btnSi = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnNo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSi
            // 
            this.btnSi.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSi.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnSi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSi.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSi.Location = new System.Drawing.Point(141, 282);
            this.btnSi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(180, 44);
            this.btnSi.TabIndex = 38;
            this.btnSi.Text = "SI";
            this.btnSi.UseVisualStyleBackColor = false;
            this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.Location = new System.Drawing.Point(45, 228);
            this.txtMensaje.Margin = new System.Windows.Forms.Padding(4);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(626, 32);
            this.txtMensaje.TabIndex = 37;
            this.txtMensaje.TextChanged += new System.EventHandler(this.txtMensaje_TextChanged);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.Color.DarkRed;
            this.btnNo.Location = new System.Drawing.Point(386, 282);
            this.btnNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(180, 44);
            this.btnNo.TabIndex = 39;
            this.btnNo.Text = "NO";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaInventarioWF.Properties.Resources.whatsapp_icono;
            this.pictureBox1.Location = new System.Drawing.Point(198, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 261);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // frmWhatpsAppOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 386);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnSi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWhatpsAppOrden";
            this.Text = "SOLICITAR ENVIO - DELIVERY";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}