    namespace SistemaInventarioWF
    {
        partial class frmConsultaEnviosDelivery
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
                this.dgvEnviosDelivery = new System.Windows.Forms.DataGridView();
                this.btnBuscar = new System.Windows.Forms.Button();
                this.cboEstadoEnvio = new System.Windows.Forms.ComboBox();
                this.label2 = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.label1 = new System.Windows.Forms.Label();
                this.txtBuscar = new System.Windows.Forms.TextBox();
                this.btnLimpiar = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.dgvEnviosDelivery)).BeginInit();
                this.SuspendLayout();
                // 
                // dgvEnviosDelivery
                // 
                this.dgvEnviosDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dgvEnviosDelivery.Location = new System.Drawing.Point(164, 531);
                this.dgvEnviosDelivery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
                this.dgvEnviosDelivery.Name = "dgvEnviosDelivery";
                this.dgvEnviosDelivery.RowHeadersWidth = 62;
                this.dgvEnviosDelivery.Size = new System.Drawing.Size(1158, 543);
                this.dgvEnviosDelivery.TabIndex = 46;
                this.dgvEnviosDelivery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
                // 
                // btnBuscar
                // 
                this.btnBuscar.BackColor = System.Drawing.Color.DarkRed;
                this.btnBuscar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnBuscar.ForeColor = System.Drawing.Color.WhiteSmoke;
                this.btnBuscar.Location = new System.Drawing.Point(984, 268);
                this.btnBuscar.Name = "btnBuscar";
                this.btnBuscar.Size = new System.Drawing.Size(172, 74);
                this.btnBuscar.TabIndex = 44;
                this.btnBuscar.Text = "BUSCAR";
                this.btnBuscar.UseVisualStyleBackColor = false;
                this.btnBuscar.Click += new System.EventHandler(this.btn_buscar_Click);
                // 
                // cboEstadoEnvio
                // 
                this.cboEstadoEnvio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.cboEstadoEnvio.FormattingEnabled = true;
                this.cboEstadoEnvio.Items.AddRange(new object[] {
                "Todos",
                "",
                "En Camino",
                "",
                "Entregado",
                "",
                "Cancelado"});
                this.cboEstadoEnvio.Location = new System.Drawing.Point(582, 388);
                this.cboEstadoEnvio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
                this.cboEstadoEnvio.Name = "cboEstadoEnvio";
                this.cboEstadoEnvio.Size = new System.Drawing.Size(262, 35);
                this.cboEstadoEnvio.TabIndex = 39;
                this.cboEstadoEnvio.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
                this.label2.Location = new System.Drawing.Point(324, 392);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(208, 29);
                this.label2.TabIndex = 38;
                this.label2.Text = "Estado de Envío:";
                this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.label2.Click += new System.EventHandler(this.label2_Click);
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label3.ForeColor = System.Drawing.Color.DarkRed;
                this.label3.Location = new System.Drawing.Point(444, 109);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(646, 45);
                this.label3.TabIndex = 35;
                this.label3.Text = "CONSULTA DE ENVÍOS Y DELIVERY";
                this.label3.Click += new System.EventHandler(this.label3_Click);
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
                this.label1.Location = new System.Drawing.Point(324, 312);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(141, 29);
                this.label1.TabIndex = 47;
                this.label1.Text = "Repartidor:";
                this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // txtBuscar
                // 
                this.txtBuscar.Location = new System.Drawing.Point(582, 311);
                this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
                this.txtBuscar.Name = "txtBuscar";
                this.txtBuscar.Size = new System.Drawing.Size(262, 26);
                this.txtBuscar.TabIndex = 48;
                this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
                // 
                // btnLimpiar
                // 
                this.btnLimpiar.BackColor = System.Drawing.Color.DarkRed;
                this.btnLimpiar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnLimpiar.ForeColor = System.Drawing.Color.WhiteSmoke;
                this.btnLimpiar.Location = new System.Drawing.Point(984, 388);
                this.btnLimpiar.Name = "btnLimpiar";
                this.btnLimpiar.Size = new System.Drawing.Size(172, 74);
                this.btnLimpiar.TabIndex = 49;
                this.btnLimpiar.Text = "LIMPIAR";
                this.btnLimpiar.UseVisualStyleBackColor = false;
                this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
                // 
                // frmConsultaEnviosDelivery
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(1293, 782);
                this.Controls.Add(this.btnLimpiar);
                this.Controls.Add(this.txtBuscar);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.dgvEnviosDelivery);
                this.Controls.Add(this.btnBuscar);
                this.Controls.Add(this.cboEstadoEnvio);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.label3);
                this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
                this.Name = "frmConsultaEnviosDelivery";
                this.Text = "frmConsultaEnviosDelivery";
                ((System.ComponentModel.ISupportInitialize)(this.dgvEnviosDelivery)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.DataGridView dgvEnviosDelivery;
            private System.Windows.Forms.Button btnBuscar;
            private System.Windows.Forms.ComboBox cboEstadoEnvio;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.TextBox txtBuscar;
            private System.Windows.Forms.Button btnLimpiar;
        }
    }