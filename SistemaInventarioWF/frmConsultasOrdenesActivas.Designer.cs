namespace SistemaInventarioWF
{
    partial class frmConsultasOrdenesActivas
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dgvOrdenesActivas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesActivas)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(50, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(548, 37);
            this.label3.TabIndex = 21;
            this.label3.Text = "CONSULTA DE ÓRDENES ACTIVAS";
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.BackColor = System.Drawing.Color.White;
            this.btnVerDetalle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalle.ForeColor = System.Drawing.Color.DarkRed;
            this.btnVerDetalle.Location = new System.Drawing.Point(57, 115);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(223, 63);
            this.btnVerDetalle.TabIndex = 26;
            this.btnVerDetalle.Text = "VER DETALLE";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.White;
            this.btnRefrescar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnRefrescar.Location = new System.Drawing.Point(309, 115);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(223, 63);
            this.btnRefrescar.TabIndex = 27;
            this.btnRefrescar.Text = "REFRESCAR";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dgvOrdenesActivas
            // 
            this.dgvOrdenesActivas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesActivas.Location = new System.Drawing.Point(57, 224);
            this.dgvOrdenesActivas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvOrdenesActivas.Name = "dgvOrdenesActivas";
            this.dgvOrdenesActivas.RowHeadersWidth = 62;
            this.dgvOrdenesActivas.Size = new System.Drawing.Size(1326, 696);
            this.dgvOrdenesActivas.TabIndex = 28;
            this.dgvOrdenesActivas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenesActivas_CellContentClick);
            // 
            // frmConsultasOrdenesActivas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 782);
            this.Controls.Add(this.dgvOrdenesActivas);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConsultasOrdenesActivas";
            this.Text = "frmConsultasOrdenesActivas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesActivas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvOrdenesActivas;
    }
}