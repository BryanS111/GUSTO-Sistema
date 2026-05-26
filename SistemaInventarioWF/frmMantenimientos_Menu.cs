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
    public partial class frmMantenimientos_Menu : Form
    {

        private InterfazPrincipal_Admin _abuelo;
        public frmMantenimientos_Menu(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            _abuelo = abuelo;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new ClientesView());
        }

        private void frmMantenimientos_Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new EmpleadoView());
        }

        private void btnRepartidores_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new RepartidoresView());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new ProveedoresView());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new UsuariosView());
        }

        private void btnMenuCombos_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new MenuCombosView());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new InventarioView());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new CategoriasView());
        }

        private void btnMunicipiosDir_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new DireccionesMunicipiosView());
        }
    }
}
