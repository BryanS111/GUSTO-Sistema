namespace SistemaInventarioWF
{
    partial class frmInicio_Dashboard
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnManualUso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SistemaInventarioWF.Properties.Resources.logo_1000x1000px;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(460, 194);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(523, 513);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnManualUso
            // 
            this.btnManualUso.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManualUso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManualUso.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualUso.ForeColor = System.Drawing.Color.DarkRed;
            this.btnManualUso.Location = new System.Drawing.Point(558, 735);
            this.btnManualUso.Name = "btnManualUso";
            this.btnManualUso.Size = new System.Drawing.Size(327, 52);
            this.btnManualUso.TabIndex = 1;
            this.btnManualUso.Text = "Leer manual de uso...";
            this.btnManualUso.UseVisualStyleBackColor = false;
            // 
            // frmInicio_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 983);
            this.Controls.Add(this.btnManualUso);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmInicio_Dashboard";
            this.Text = "frmInicio_Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnManualUso;
    }
}