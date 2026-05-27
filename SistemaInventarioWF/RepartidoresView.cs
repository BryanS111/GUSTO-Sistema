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
    public partial class RepartidoresView : Form
    {

        private InterfazPrincipal_Admin _abuelo;
        public RepartidoresView(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            _abuelo = abuelo;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            grpBoxData.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new frmMantenimientos_Menu(_abuelo));
            this.Close();
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
    }
}
