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
    public partial class frmConsultas_Menu : Form
    {
        public frmConsultas_Menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                principal.AbrirFormularioEnPanel(new frmConsultaVentasFecha());
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {

            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                principal.AbrirFormularioEnPanel(new frmConsultaStockInventario());
            }
        }

        private void btn_ordenes_Click(object sender, EventArgs e)
        {
            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                principal.AbrirFormularioEnPanel(new frmConsultasOrdenesActivas());
            }
        }

        private void btn_comprasProveedor_Click(object sender, EventArgs e)
        {
            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                principal.AbrirFormularioEnPanel(new frmConsultaComprasProveedor());
            }
        }

        private void btnMenuCombos_Click(object sender, EventArgs e)
        {
            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                principal.AbrirFormularioEnPanel(new frmConsultaHistorialAuditoria());
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            InterfazPrincipal_Admin principal = Application.OpenForms["InterfazPrincipal_Admin"] as InterfazPrincipal_Admin;

            if (principal != null)
            {
                principal.AbrirFormularioEnPanel(new frmConsultaEnviosDelivery());
            }
        }
    }
    
}
