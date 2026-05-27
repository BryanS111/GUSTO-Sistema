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
    public partial class frmProcesos_Menu : Form
    {
        public frmProcesos_Menu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                // Reemplaza 'frmRegistro_Orden' por el nombre real de tu clase/formulario
                principal.AbrirFormularioEnPanel(new frmRegistroOrden());
            }
        }


        private void btnProveedores_Click(object sender, EventArgs e) //este clic es de el proceso de ventas
        {
            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                // Reemplaza 'frmRegistro_Orden' por el nombre real de tu clase/formulario
                principal.AbrirFormularioEnPanel(new frmProcesoVenta());
            }
        }

        private void btnMenuCombos_Click(object sender, EventArgs e) // boton de proceso de delivery (olvide cambiarle el nombre)
        {
            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                // Reemplaza 'frmRegistro_Orden' por el nombre real de tu clase/formulario
                principal.AbrirFormularioEnPanel(new frmProcesoDelivery());
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)//registro de compras boton clic
        {
            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                // Reemplaza 'frmRegistro_Orden' por el nombre real de tu clase/formulario
                principal.AbrirFormularioEnPanel(new frmRegistroCompra());
            }
        }

        private void btnRepartidores_Click(object sender, EventArgs e)
        {
            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                // Reemplaza 'frmRegistro_Orden' por el nombre real de tu clase/formulario
                principal.AbrirFormularioEnPanel(new frmOrdenProduccion());
            }
        }
    }
}
