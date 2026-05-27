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
    public partial class EmpleadoView : Form
    {
        public EmpleadoView()
        {
            InitializeComponent();
        }

        private void EmpleadoView_Load(object sender, EventArgs e)
        {

        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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
    }
}
