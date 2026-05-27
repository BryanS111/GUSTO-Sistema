namespace SistemaInventarioWF
{
    partial class InterfazPrincipal_Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterfazPrincipal_Admin));
            this.btnCerrarSesion_Admin = new System.Windows.Forms.Button();
            this.btnMantenimientos_Admin = new System.Windows.Forms.Button();
            this.btnConsultas_Admin = new System.Windows.Forms.Button();
            this.btnProcesosT_Admin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrarSesion_Admin
            // 
            this.btnCerrarSesion_Admin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrarSesion_Admin.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion_Admin.ForeColor = System.Drawing.Color.DimGray;
            this.btnCerrarSesion_Admin.Location = new System.Drawing.Point(102, 935);
            this.btnCerrarSesion_Admin.Name = "btnCerrarSesion_Admin";
            this.btnCerrarSesion_Admin.Size = new System.Drawing.Size(226, 45);
            this.btnCerrarSesion_Admin.TabIndex = 1;
            this.btnCerrarSesion_Admin.Text = "CERRAR SESION";
            this.btnCerrarSesion_Admin.UseVisualStyleBackColor = false;
            this.btnCerrarSesion_Admin.Click += new System.EventHandler(this.btnCerrarSesion_Admin_Click);
            // 
            // btnMantenimientos_Admin
            // 
            this.btnMantenimientos_Admin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMantenimientos_Admin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMantenimientos_Admin.ForeColor = System.Drawing.Color.DarkRed;
            this.btnMantenimientos_Admin.Location = new System.Drawing.Point(38, 341);
            this.btnMantenimientos_Admin.Name = "btnMantenimientos_Admin";
            this.btnMantenimientos_Admin.Size = new System.Drawing.Size(305, 74);
            this.btnMantenimientos_Admin.TabIndex = 2;
            this.btnMantenimientos_Admin.Text = "MANTENIMIENTOS";
            this.btnMantenimientos_Admin.UseVisualStyleBackColor = false;
            this.btnMantenimientos_Admin.Click += new System.EventHandler(this.btnMantenimientos_Admin_Click);
            // 
            // btnConsultas_Admin
            // 
            this.btnConsultas_Admin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConsultas_Admin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultas_Admin.ForeColor = System.Drawing.Color.DarkRed;
            this.btnConsultas_Admin.Location = new System.Drawing.Point(38, 470);
            this.btnConsultas_Admin.Name = "btnConsultas_Admin";
            this.btnConsultas_Admin.Size = new System.Drawing.Size(305, 71);
            this.btnConsultas_Admin.TabIndex = 3;
            this.btnConsultas_Admin.Text = "CONSULTAS";
            this.btnConsultas_Admin.UseVisualStyleBackColor = false;
            this.btnConsultas_Admin.Click += new System.EventHandler(this.btnConsultas_Admin_Click);
            // 
            // btnProcesosT_Admin
            // 
            this.btnProcesosT_Admin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProcesosT_Admin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesosT_Admin.ForeColor = System.Drawing.Color.DarkRed;
            this.btnProcesosT_Admin.Location = new System.Drawing.Point(38, 587);
            this.btnProcesosT_Admin.Name = "btnProcesosT_Admin";
            this.btnProcesosT_Admin.Size = new System.Drawing.Size(305, 80);
            this.btnProcesosT_Admin.TabIndex = 4;
            this.btnProcesosT_Admin.Text = "PROCESOS TRANSACCIONALES";
            this.btnProcesosT_Admin.UseVisualStyleBackColor = false;
            this.btnProcesosT_Admin.Click += new System.EventHandler(this.btnProcesosT_Admin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(85, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "ADMINISTRADOR";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Location = new System.Drawing.Point(389, -3);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1537, 1039);
            this.pnlContenedor.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SistemaInventarioWF.Properties.Resources.dashboardsTempleate1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-9, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 1039);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // InterfazPrincipal_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1034);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcesosT_Admin);
            this.Controls.Add(this.btnConsultas_Admin);
            this.Controls.Add(this.btnMantenimientos_Admin);
            this.Controls.Add(this.btnCerrarSesion_Admin);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InterfazPrincipal_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G.U.S.T.O - ADMINISTRADOR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InterfazPrincipal_Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCerrarSesion_Admin;
        private System.Windows.Forms.Button btnMantenimientos_Admin;
        private System.Windows.Forms.Button btnConsultas_Admin;
        private System.Windows.Forms.Button btnProcesosT_Admin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContenedor;
    }
}