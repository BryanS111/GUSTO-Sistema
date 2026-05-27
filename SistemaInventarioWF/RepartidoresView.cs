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
        public RepartidoresView()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            grpBoxData.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
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
