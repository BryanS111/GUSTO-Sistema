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
            this.btn_detalle = new System.Windows.Forms.Button();
            this.btn_refrescar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(277, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(427, 31);
            this.label3.TabIndex = 21;
            this.label3.Text = "CONSULTA DE ÓRDENES ACTIVAS";
            // 
            // btn_detalle
            // 
            this.btn_detalle.BackColor = System.Drawing.Color.DarkRed;
            this.btn_detalle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_detalle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_detalle.Location = new System.Drawing.Point(273, 168);
            this.btn_detalle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_detalle.Name = "btn_detalle";
            this.btn_detalle.Size = new System.Drawing.Size(130, 58);
            this.btn_detalle.TabIndex = 26;
            this.btn_detalle.Text = "VER DETALLE";
            this.btn_detalle.UseVisualStyleBackColor = false;
            // 
            // btn_refrescar
            // 
            this.btn_refrescar.BackColor = System.Drawing.Color.DarkRed;
            this.btn_refrescar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refrescar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_refrescar.Location = new System.Drawing.Point(564, 168);
            this.btn_refrescar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_refrescar.Name = "btn_refrescar";
            this.btn_refrescar.Size = new System.Drawing.Size(130, 58);
            this.btn_refrescar.TabIndex = 27;
            this.btn_refrescar.Text = "REFRESCAR";
            this.btn_refrescar.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 276);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(856, 322);
            this.dataGridView1.TabIndex = 28;
            // 
            // frmConsultasOrdenesActivas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 508);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_refrescar);
            this.Controls.Add(this.btn_detalle);
            this.Controls.Add(this.label3);
            this.Name = "frmConsultasOrdenesActivas";
            this.Text = "frmConsultasOrdenesActivas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_detalle;
        private System.Windows.Forms.Button btn_refrescar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}