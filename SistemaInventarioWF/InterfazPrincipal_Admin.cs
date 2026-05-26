using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class InterfazPrincipal_Admin : Form
    {
        public InterfazPrincipal_Admin(Usuario usuario)
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void InterfazPrincipal_Admin_Load(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmInicio_Dashboard());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMantenimientos_Admin_Click(object sender, EventArgs e)
        {

            AbrirFormularioEnPanel(new frmMantenimientos_Menu());

        }

        // Método para abrir formularios dentro del panel contenedor
        private void AbrirFormularioEnPanel(Form formHijo)
        {
            // 1. Verificamos si ya hay un formulario abierto en el panel y lo quitamos
            if (this.pnlContenedor.Controls.Count > 0)
            {
                this.pnlContenedor.Controls.RemoveAt(0);
            }

            // 2. Configuramos el formulario hijo para que no sea una ventana flotante
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill; // Esto hace que se estire y llene el panel
            formHijo.FormBorderStyle = FormBorderStyle.None; // Le quitamos el borde de ventana de Windows

            // 3. Agregamos el formulario al panel contenedor y lo mostramos
            this.pnlContenedor.Controls.Add(formHijo);
            this.pnlContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void btnCerrarSesion_Admin_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnConsultas_Admin_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmConsultas_Menu());
        }

        private void btnProcesosT_Admin_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmProcesos_Menu());
        }
    }
}