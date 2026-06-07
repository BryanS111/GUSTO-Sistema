using DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class ClientesView : Form
    {
        private InterfazPrincipal_Admin _abuelo;
        private ClienteDAO _clienteDAO;
        private List<Cliente> _listaClientes;
        private bool _modoEdicion;
        private int _clienteIdActual;

        public ClientesView(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            _abuelo = abuelo;
            _clienteDAO = new ClienteDAO();
            _modoEdicion = false;
            _clienteIdActual = 0;

            // Mantener el tamaño fijo como lo diseñaste (esto ya funcionaba)
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            this.Load += new EventHandler(ClientesView_Load);
        }
        

        private void ClientesView_Load(object sender, EventArgs e)
        {
            CargarComboDirecciones();
            CargarComboEstado();
            CargarGrilla();
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new frmMantenimientos_Menu(_abuelo));
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _clienteIdActual = 0;
            LimpiarCampos();
            ModoFormulario(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente cli = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;
            _clienteIdActual = cli.ClienteId;

            txtNombre.Text = cli.Nombre;
            txtApellido.Text = cli.Apellido;
            txtTelefono.Text = cli.Telefono;
            cboDireccion.SelectedValue = cli.DireccionId;

            if (cli.EstadoId > 0)
                cboEstado.SelectedValue = cli.EstadoId;
            else if (cboEstado.Items.Count > 0)
                cboEstado.SelectedIndex = 0;

            _modoEdicion = true;
            ModoFormulario(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            if (cboDireccion.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una dirección.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboEstado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente cli = new Cliente
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                NombreCompleto = txtNombre.Text.Trim() + " " + txtApellido.Text.Trim(),  // ← agregar
                Telefono = txtTelefono.Text.Trim(),
                DireccionId = (int)cboDireccion.SelectedValue,
                EstadoId = (int)cboEstado.SelectedValue
            };

            string error;
            if (!_modoEdicion)
            {
                _clienteDAO.GuardarRegistro(cli, out error);
            }
            else
            {
                cli.ClienteId = _clienteIdActual;
                _clienteDAO.ActualizarRegistro(cli, out error);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al guardar: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Cliente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente cli = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Desactivar al cliente {cli.Nombre} {cli.Apellido}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string error;
            _clienteDAO.EliminarLogico(cli.ClienteId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al eliminar: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Cliente desactivado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new DireccionesMunicipiosView(_abuelo));
            this.Close();
        }

        // Métodos auxiliares
        private void CargarComboDirecciones()
        {
            string error;
            DataTable dt = _clienteDAO.ObtenerDireccionesActivas(out error);
            if (dt != null)
            {
                cboDireccion.DataSource = dt;
                cboDireccion.DisplayMember = "DireccionCompleta";
                cboDireccion.ValueMember = "DireccionId";
            }
            else
            {
                MessageBox.Show($"Error al cargar direcciones: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboEstado()
        {
            string error;
            DataTable dt = _clienteDAO.ObtenerEstadosCliente(out error);
            if (dt != null)
            {
                cboEstado.DataSource = dt;
                cboEstado.DisplayMember = "Estado";
                cboEstado.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show($"Error al cargar estados: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla(string buscar = "")
        {
            string error;
            if (string.IsNullOrWhiteSpace(buscar))
                _listaClientes = _clienteDAO.ObtenerTodos(out error);
            else
                _listaClientes = _clienteDAO.Buscar(buscar, out error);

            if (_listaClientes == null)
            {
                MessageBox.Show($"Error al cargar clientes: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvClientes.DataSource = null;
            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.DataSource = _listaClientes;

            //if (dgvClientes.Columns["ClienteId"] != null)
            //    dgvClientes.Columns["ClienteId"].Visible = false;
            //if (dgvClientes.Columns["DireccionId"] != null)
            //    dgvClientes.Columns["DireccionId"].Visible = false;
            if (dgvClientes.Columns["EstadoId"] != null)
                dgvClientes.Columns["EstadoId"].Visible = false;
            if (dgvClientes.Columns["Nombre"] != null)
                dgvClientes.Columns["Nombre"].Visible = false;
            if (dgvClientes.Columns["Apellido"] != null)
                dgvClientes.Columns["Apellido"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            if (cboDireccion.Items.Count > 0) cboDireccion.SelectedIndex = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
        }

        private void ModoFormulario(bool habilitar)
        {
            grpBoxData.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            return true;
        }

        // Eventos vacíos requeridos
        private void txtBuscar_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtApellido_TextChanged(object sender, EventArgs e) { }
        private void txtTelefono_TextChanged(object sender, EventArgs e) { }
        private void cboDireccion_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}