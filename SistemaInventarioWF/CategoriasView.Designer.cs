namespace SistemaInventarioWF
{
    partial class CategoriasView
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.gbxDatos = new System.Windows.Forms.GroupBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.gbxDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.DarkRed;
            this.btnClose.Location = new System.Drawing.Point(1154, 36);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(39, 50);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnEditar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnEditar.Location = new System.Drawing.Point(894, 91);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(146, 50);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnEliminar.Location = new System.Drawing.Point(1047, 91);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(146, 50);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnNuevo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.DarkRed;
            this.btnNuevo.Location = new System.Drawing.Point(741, 91);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(146, 50);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Buscar";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnBuscar.Location = new System.Drawing.Point(573, 91);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(146, 50);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(28, 399);
            this.dgvCategorias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.RowHeadersWidth = 51;
            this.dgvCategorias.RowTemplate.Height = 24;
            this.dgvCategorias.Size = new System.Drawing.Size(1166, 241);
            this.dgvCategorias.TabIndex = 10;
            this.dgvCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorias_CellContentClick);
            // 
            // gbxDatos
            // 
            this.gbxDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxDatos.Controls.Add(this.cbxEstado);
            this.gbxDatos.Controls.Add(this.btnGuardar);
            this.gbxDatos.Controls.Add(this.btnCancelar);
            this.gbxDatos.Controls.Add(this.label8);
            this.gbxDatos.Controls.Add(this.label4);
            this.gbxDatos.Controls.Add(this.label2);
            this.gbxDatos.Controls.Add(this.txtNombreCategoria);
            this.gbxDatos.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDatos.Location = new System.Drawing.Point(28, 156);
            this.gbxDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbxDatos.Name = "gbxDatos";
            this.gbxDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbxDatos.Size = new System.Drawing.Size(1166, 216);
            this.gbxDatos.TabIndex = 13;
            this.gbxDatos.TabStop = false;
            this.gbxDatos.Text = "Datos";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(60, 100);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(476, 32);
            this.txtBuscar.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 38);
            this.label1.TabIndex = 11;
            this.label1.Text = "CATEGORIAS";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnGuardar.Location = new System.Drawing.Point(837, 157);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(138, 36);
            this.btnGuardar.TabIndex = 31;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCancelar.Location = new System.Drawing.Point(1004, 157);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 36);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(61, 106);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 24);
            this.label8.TabIndex = 28;
            this.label8.Text = "Estado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 24);
            this.label4.TabIndex = 26;
            this.label4.Text = "Categoria:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-15, -37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Nombre";
            // 
            // txtNombreCategoria
            // 
            this.txtNombreCategoria.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCategoria.Location = new System.Drawing.Point(166, 42);
            this.txtNombreCategoria.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(386, 32);
            this.txtNombreCategoria.TabIndex = 25;
            this.txtNombreCategoria.TextChanged += new System.EventHandler(this.txtNombreCategoria_TextChanged);
            // 
            // cbxEstado
            // 
            this.cbxEstado.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEstado.FormattingEnabled = true;
            this.cbxEstado.Location = new System.Drawing.Point(166, 102);
            this.cbxEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.Size = new System.Drawing.Size(201, 33);
            this.cbxEstado.TabIndex = 32;
            this.cbxEstado.SelectedIndexChanged += new System.EventHandler(this.cbxEstado_SelectedIndexChanged);
            // 
            // CategoriasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 660);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvCategorias);
            this.Controls.Add(this.gbxDatos);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CategoriasView";
            this.Text = "CategoriasView";
            this.Load += new System.EventHandler(this.CategoriasView_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.gbxDatos.ResumeLayout(false);
            this.gbxDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.GroupBox gbxDatos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.ComboBox cbxEstado;
    }
}