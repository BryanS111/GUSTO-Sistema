using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DAO;
using Modelos;

namespace SistemaInventarioWF
{
    public partial class ProveedoresView : Form
    {
        private InterfazPrincipal_Admin _abuelo;
        private ProveedorDAO _proveedorDAO;
        private List<Proveedor> _listaProveedores;
        private bool _modoEdicion;
        private int _proveedorIdActual;
        private DataTable _dtEstados; // Para buscar IDs por nombre

        public ProveedoresView(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            this.Load += new EventHandler(ProveedoresView_Load);
            _abuelo = abuelo;
            _proveedorDAO = new ProveedorDAO();
            _modoEdicion = false;
            _proveedorIdActual = 0;
        }

        private void ProveedoresView_Load(object sender, EventArgs e)
        {
            CargarComboEstado();
            CargarGrilla();
            LimpiarCampos();
            ModoFormulario(false);
        }

        // Botón cerrar (X)
        private void button4_Click(object sender, EventArgs e)
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
            _proveedorIdActual = 0;
            LimpiarCampos();
            ModoFormulario(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Proveedor provSeleccionado = (Proveedor)dgvProveedores.SelectedRows[0].DataBoundItem;

            _proveedorIdActual = provSeleccionado.ProveedorId;
            txtNombre.Text = provSeleccionado.Nombre;
            txtDireccion.Text = provSeleccionado.Direccion;
            txtTelefono.Text = provSeleccionado.Telefono;
            txtNCR.Text = provSeleccionado.NoRegistro;
            txtNIT.Text = provSeleccionado.NIT;

            // Seleccionar el estado en el combo usando el nombre
            if (!string.IsNullOrEmpty(provSeleccionado.EstadoNombre) && _dtEstados != null)
            {
                foreach (DataRow row in _dtEstados.Rows)
                {
                    if (row["Estado"].ToString() == provSeleccionado.EstadoNombre)
                    {
                        cboEstado.SelectedValue = row["Id"];
                        break;
                    }
                }
            }

            _modoEdicion = true;
            ModoFormulario(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            if (cboEstado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un estado.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Proveedor prov = new Proveedor
            {
                Nombre = txtNombre.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                NoRegistro = txtNCR.Text.Trim(),
                NIT = txtNIT.Text.Trim(),
                EstadoId = (int)cboEstado.SelectedValue
            };

            string error;
            if (!_modoEdicion)
            {
                _proveedorDAO.GuardarRegistro(prov, out error);
            }
            else
            {
                prov.ProveedorId = _proveedorIdActual;
                _proveedorDAO.ActualizarRegistro(prov, out error);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al guardar: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Proveedor guardado exitosamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Proveedor provSeleccionado = (Proveedor)dgvProveedores.SelectedRows[0].DataBoundItem;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de desactivar al proveedor '{provSeleccionado.Nombre}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            string error;
            _proveedorDAO.EliminarLogico(provSeleccionado.ProveedorId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al eliminar: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Proveedor desactivado.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ModoFormulario(false);
        }

        // Métodos auxiliares

        private void CargarComboEstado()
        {
            string error;
            _dtEstados = _proveedorDAO.ObtenerEstadosProveedor(out error);
            if (_dtEstados != null)
            {
                cboEstado.DataSource = _dtEstados;
                cboEstado.DisplayMember = "Estado";
                cboEstado.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show($"Error al cargar estados: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla(string buscar = "")
        {
            string error;
            if (string.IsNullOrWhiteSpace(buscar))
                _listaProveedores = _proveedorDAO.ObtenerTodos(out error);
            else
                _listaProveedores = _proveedorDAO.Buscar(buscar, out error);

            if (_listaProveedores == null)
            {
                MessageBox.Show($"Error al cargar proveedores: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvProveedores.DataSource = null;
            dgvProveedores.AutoGenerateColumns = true;
            dgvProveedores.DataSource = _listaProveedores;

            // Ocultar columnas internas si se desea
            if (dgvProveedores.Columns["ProveedorId"] != null)
                dgvProveedores.Columns["ProveedorId"].Visible = false;
            if (dgvProveedores.Columns["EstadoId"] != null)
                dgvProveedores.Columns["EstadoId"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtNCR.Clear();
            txtNIT.Clear();
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
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            return true;
        }

        // Eventos vacíos requeridos por el diseñador
        private void txtBuscar_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtDireccion_TextChanged(object sender, EventArgs e) { }
        private void txtTelefono_TextChanged(object sender, EventArgs e) { }
        private void txtNCR_TextChanged(object sender, EventArgs e) { }
        private void txtNIT_TextChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void grpBoxData_Enter(object sender, EventArgs e) { }
    }
}