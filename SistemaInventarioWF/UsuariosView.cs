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
    public partial class UsuariosView : Form
    {

        private InterfazPrincipal_Admin _abuelo;
        public UsuariosView(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            _abuelo = abuelo;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            grpBoxData.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            grpBoxData.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            grpBoxData.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            grpBoxData.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new frmMantenimientos_Menu(_abuelo));
            this.Close();
        }
    }
}
