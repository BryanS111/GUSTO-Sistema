using DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class InventarioView : Form
    {
        private InterfazPrincipal_Admin _abuelo;
        private InventarioDAO _inventarioDAO;
        private List<Inventario> _listaInventario;
        private bool _modoEdicion;
        private int _inventarioIdActual;

        public InventarioView(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            _abuelo = abuelo;
            _inventarioDAO = new InventarioDAO();
            _modoEdicion = false;
            _inventarioIdActual = 0;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Load += new EventHandler(InventarioView_Load);
        }

        private void InventarioView_Load(object sender, EventArgs e)
        {
            CargarComboTipoInventario();
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
            _inventarioIdActual = 0;
            LimpiarCampos();
            ModoFormulario(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Inventario inv = (Inventario)dgvInventario.SelectedRows[0].DataBoundItem;
            _inventarioIdActual = inv.InventarioId;

            txtNombreProd.Text = inv.NombreProducto;
            txtUnidadMed.Text = inv.UnidadDeMedida;
            txtCantidad.Text = inv.Cantidad.ToString();
            txtPrecioCost.Text = inv.PrecioCosto.ToString("F2");
            cboTipoInventario.SelectedValue = inv.TipoInventarioId;

            if (inv.EstadoId > 0)
                cboEstado.SelectedValue = inv.EstadoId;
            else if (cboEstado.Items.Count > 0)
                cboEstado.SelectedIndex = 0;

            txtCantidad.Enabled = false;

            _modoEdicion = true;
            ModoFormulario(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            if (cboTipoInventario.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de inventario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboEstado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Inventario inv = new Inventario
            {
                NombreProducto = txtNombreProd.Text.Trim(),
                UnidadDeMedida = txtUnidadMed.Text.Trim(),
                Cantidad = double.Parse(txtCantidad.Text.Trim()),
                PrecioCosto = decimal.Parse(txtPrecioCost.Text.Trim()),
                TipoInventarioId = (int)cboTipoInventario.SelectedValue,
                EstadoId = (int)cboEstado.SelectedValue
            };

            int idUsuario = Modelos.SesionActual.UsuarioId;
            if (idUsuario == 0)
            {
                MessageBox.Show("No hay sesión de usuario activa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string error;
            if (!_modoEdicion)
            {
                _inventarioDAO.GuardarRegistro(inv, idUsuario, out error);
            }
            else
            {
                inv.InventarioId = _inventarioIdActual;
                inv.Cantidad = ObtenerCantidadActual();
                _inventarioDAO.ActualizarRegistro(inv, idUsuario, out error);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al guardar: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Producto guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Inventario inv = (Inventario)dgvInventario.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Desactivar el producto '{inv.NombreProducto}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string error;
            _inventarioDAO.EliminarLogico(inv.InventarioId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al eliminar: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Producto desactivado (AGOTADO).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void CargarComboTipoInventario()
        {
            string error;
            DataTable dt = _inventarioDAO.ObtenerTiposInventario(out error);
            if (dt != null)
            {
                cboTipoInventario.DataSource = dt;
                cboTipoInventario.DisplayMember = "Tipo";
                cboTipoInventario.ValueMember = "Codigo";
            }
            else
            {
                MessageBox.Show($"Error al cargar tipos de inventario: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboEstado()
        {
            string error;
            DataTable dt = _inventarioDAO.ObtenerEstadosInventario(out error);
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
                _listaInventario = _inventarioDAO.ObtenerTodos(out error);
            else
                _listaInventario = _inventarioDAO.Buscar(buscar, out error);

            if (_listaInventario == null)
            {
                MessageBox.Show($"Error al cargar inventario: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvInventario.DataSource = null;
            dgvInventario.AutoGenerateColumns = true;
            dgvInventario.DataSource = _listaInventario;

            if (dgvInventario.Columns["InventarioId"] != null)
                dgvInventario.Columns["InventarioId"].Visible = false;
            if (dgvInventario.Columns["EstadoId"] != null)
                dgvInventario.Columns["EstadoId"].Visible = false;

            if (dgvInventario.Columns["UsuarioRegistroId"] != null)
                dgvInventario.Columns["UsuarioRegistroId"].Visible = false;
            if (dgvInventario.Columns["UsuarioModificacionId"] != null)
                dgvInventario.Columns["UsuarioModificacionId"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtNombreProd.Clear();
            txtUnidadMed.Clear();
            txtCantidad.Clear();
            txtPrecioCost.Clear();
            if (cboTipoInventario.Items.Count > 0) cboTipoInventario.SelectedIndex = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            txtCantidad.Enabled = true;
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
            if (string.IsNullOrWhiteSpace(txtNombreProd.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProd.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUnidadMed.Text))
            {
                MessageBox.Show("La unidad de medida es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnidadMed.Focus();
                return false;
            }
            if (!double.TryParse(txtCantidad.Text, out double cant) || cant < 0)
            {
                MessageBox.Show("La cantidad debe ser un número válido (mayor o igual a 0).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }
            if (!decimal.TryParse(txtPrecioCost.Text, out decimal prec) || prec <= 0)
            {
                MessageBox.Show("El precio de costo debe ser mayor a $0.00.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioCost.Focus();
                return false;
            }
            return true;
        }

        private double ObtenerCantidadActual()
        {
            if (_modoEdicion && dgvInventario.SelectedRows.Count > 0)
                return ((Inventario)dgvInventario.SelectedRows[0].DataBoundItem).Cantidad;
            return 0;
        }

        // Eventos vacíos (no borrar)
        private void txtBuscar_TextChanged(object sender, EventArgs e) { }
        private void txtNombreProd_TextChanged(object sender, EventArgs e) { }
        private void txtUnidadMed_TextChanged(object sender, EventArgs e) { }
        private void txtCantidad_TextChanged(object sender, EventArgs e) { }
        private void txtPrecioCost_TextChanged(object sender, EventArgs e) { }
        private void cboTipoInventario_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void grpBoxData_Enter(object sender, EventArgs e) { }
    }
}