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
            _abuelo.AbrirFormularioEnPanel(new ClientesView(_abuelo));
        }

        private void frmMantenimientos_Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new EmpleadoView(_abuelo));
        }

        private void btnRepartidores_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new RepartidoresView(_abuelo));
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new ProveedoresView(_abuelo));
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new UsuariosView(_abuelo));
        }

        private void btnMenuCombos_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new MenuCombosView(_abuelo));
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new InventarioView(_abuelo));
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new CategoriasView());
        }

        private void btnMunicipiosDir_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new DireccionesMunicipiosView(_abuelo));
        }
    }
}
