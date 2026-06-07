using DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmRegistroCompra : Form
    {
        private CompraDAO _compraDAO;
        private List<DetalleCompraItem> _detalle;
        private bool _modoEdicion;
        private int _idCompraActual;
        private DataTable _dtInventario; // Para obtener precio costo

        public frmRegistroCompra()
        {
            InitializeComponent();
            _compraDAO = new CompraDAO();
            _detalle = new List<DetalleCompraItem>();
            _modoEdicion = false;
            _idCompraActual = 0;

            // Configurar solo lectura de controles
            txtNumDoc.ReadOnly = true;
            txtNumDoc.ForeColor = Color.Black;
            txtCostoUnitario.ReadOnly = true;
            txtTotalCompra.ReadOnly = true;

            this.Load += frmRegistroCompra_Load;
        }

        private void frmRegistroCompra_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarInventarios();
            GenerarNuevoNumeroDocumento();
            ModoFormulario(false);
        }

        // ==================== CARGAS INICIALES ====================
        private void CargarProveedores()
        {
            string error;
            DataTable dt = _compraDAO.ObtenerProveedoresActivos(out error);
            if (dt != null)
            {
                cboProveedores.DataSource = dt;
                cboProveedores.DisplayMember = "Nombre";
                cboProveedores.ValueMember = "Codigo";
            }
        }

        private void CargarInventarios()
        {
            string error;
            _dtInventario = _compraDAO.ObtenerInventariosActivos(out error);
            if (_dtInventario != null)
            {
                cboInsumo.DataSource = _dtInventario;
                cboInsumo.DisplayMember = "Producto";
                cboInsumo.ValueMember = "Codigo";
            }
        }

        private void GenerarNuevoNumeroDocumento()
        {
            string error;
            string nuevoNum = _compraDAO.ObtenerUltimoNoDocumento(out error);
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(error, "Error");
            txtNumDoc.Text = nuevoNum;
        }

        // ==================== EVENTOS DE CONTROLES ====================
        private void cboInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtInventario == null || cboInsumo.SelectedItem == null) return;

            // Obtener el DataRowView del ítem seleccionado directamente del ComboBox
            if (cboInsumo.SelectedItem is DataRowView drv)
            {
                decimal precioCosto = Convert.ToDecimal(drv["Precio Costo"]);
                txtCostoUnitario.Text = precioCosto.ToString("F2");
            }
        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            if (cboInsumo.SelectedValue == null || string.IsNullOrWhiteSpace(txtCostoUnitario.Text))
            {
                MessageBox.Show("Seleccione un insumo y verifique el costo unitario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double cantidad = (double)numUpDownCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precio = decimal.Parse(txtCostoUnitario.Text);
            int inventarioId = (int)cboInsumo.SelectedValue;
            string producto = cboInsumo.Text;

            DetalleCompraItem nuevo = new DetalleCompraItem
            {
                InventarioId = inventarioId,
                Producto = producto,
                Cantidad = cantidad,
                PrecioCompra = precio,
                TotalDetalle = (decimal)cantidad * precio
            };

            _detalle.Add(nuevo);
            ActualizarDataGridView();
            CalcularTotal();
        }

        private void ActualizarDataGridView()
        {
            dgvDetalleCompra.DataSource = null;
            dgvDetalleCompra.AutoGenerateColumns = true;
            dgvDetalleCompra.DataSource = _detalle.Select(d => new
            {
                d.Producto,
                d.Cantidad,
                PrecioUnitario = d.PrecioCompra.ToString("F2"),
                Total = d.TotalDetalle.ToString("F2")
            }).ToList();
        }

        private void CalcularTotal()
        {
            decimal total = _detalle.Sum(d => d.TotalDetalle);
            txtTotalCompra.Text = total.ToString("F2");
        }

        // ==================== BOTONES PRINCIPALES ====================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _idCompraActual = 0;
            LimpiarDetalle();
            GenerarNuevoNumeroDocumento();
            ModoFormulario(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Edición no aplica en este proceso transaccional
            MessageBox.Show("Las compras registradas no se pueden modificar. Use Eliminar para anular.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminadoLogico_Click(object sender, EventArgs e)
        {
            // No implementado aún
            MessageBox.Show("Funcionalidad no disponible en esta versión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarDetalle();
            GenerarNuevoNumeroDocumento();
            ModoFormulario(false);
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
            if (!ValidarCompra()) return;

            string error;
            _compraDAO.RegistrarCompra(
                dtpFechaCompra.Value,
                txtNumDoc.Text.Trim(),
                (int)cboProveedores.SelectedValue,
                SesionActual.UsuarioId,
                _detalle,
                out error
            );

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al registrar la compra: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Compra registrada exitosamente. El inventario ha sido actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarDetalle();
            GenerarNuevoNumeroDocumento();
            ModoFormulario(false);
        }

        // ==================== MÉTODOS AUXILIARES ====================
        private void LimpiarDetalle()
        {
            _detalle.Clear();
            dgvDetalleCompra.DataSource = null;
            txtTotalCompra.Text = "0.00";
            if (cboInsumo.Items.Count > 0) cboInsumo.SelectedIndex = 0;
            numUpDownCantidad.Value = 0;
            if (cboProveedores.Items.Count > 0) cboProveedores.SelectedIndex = 0;
            dtpFechaCompra.Value = DateTime.Today;
        }

        private void ModoFormulario(bool habilitar)
        {
            cboProveedores.Enabled = habilitar;
            dtpFechaCompra.Enabled = habilitar;
            cboInsumo.Enabled = habilitar;
            numUpDownCantidad.Enabled = habilitar;
            btnAgregarInsumo.Enabled = habilitar;
            btnRegistrarCompra.Enabled = habilitar;
            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminadoLogico.Enabled = !habilitar;
            if (habilitar)
            {
                // Al habilitar, forzar a seleccionar un proveedor e insumo
                if (cboProveedores.Items.Count > 0) cboProveedores.SelectedIndex = 0;
                if (cboInsumo.Items.Count > 0) cboInsumo.SelectedIndex = 0;
                numUpDownCantidad.Value = 0;
            }
        }

        private bool ValidarCompra()
        {
            if (cboProveedores.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_detalle.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un insumo al detalle.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ==================== EVENTOS VACÍOS (NO ELIMINAR) ====================
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void cboProveedores_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpFechaCompra_ValueChanged(object sender, EventArgs e) { }
        private void txtCostoUnitario_TextChanged(object sender, EventArgs e) { }
        private void numUpDownCantidad_ValueChanged(object sender, EventArgs e) { }
        private void dgvDetalleCompra_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtTotalCompra_TextChanged(object sender, EventArgs e) { }
    }
}