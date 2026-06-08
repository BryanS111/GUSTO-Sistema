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
    public partial class frmRegistroOrden : Form
    {
        private OrdenDAO _ordenDAO;
        private List<DetalleOrdenItem> _carrito;
        private DataTable _dtMenus;
        private DataTable _dtCombos;
        private List<Descuento> _descuentosActivos;

        public frmRegistroOrden()
        {
            InitializeComponent();
            _ordenDAO = new OrdenDAO();
            _carrito = new List<DetalleOrdenItem>();
            _descuentosActivos = new List<Descuento>();

            // Configurar solo lectura
            txtPrecioMenuOCombo.ReadOnly = true;
            txtTotalPagar.ReadOnly = true;
            txtDescuento.ReadOnly = true;

            this.Load += frmRegistroOrden_Load;
        }

        private void frmRegistroOrden_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarTiposOrden();
            CargarMenus();
            CargarCombos();
            CargarDescuentosActivos(); // ¡esto faltaba!
            dtpFechaOrden.Value = DateTime.Today;
        }

        // ==================== CARGA DE COMBOS ====================
        private void CargarClientes()
        {
            string error;
            DataTable dt = _ordenDAO.ObtenerClientesActivos(out error);
            if (dt != null)
            {
                cboClientes.DataSource = dt;
                cboClientes.DisplayMember = "NombreCompleto";
                cboClientes.ValueMember = "ClienteId";
            }
        }

        private void CargarTiposOrden()
        {
            string error;
            DataTable dt = _ordenDAO.ObtenerTiposOrden(out error);
            if (dt != null)
            {
                cboTipoOrden.DataSource = dt;
                cboTipoOrden.DisplayMember = "TipoOrden";
                cboTipoOrden.ValueMember = "Id";
            }
        }

        private void CargarMenus()
        {
            string error;
            _dtMenus = _ordenDAO.ObtenerMenusActivos(out error);
            if (_dtMenus != null)
            {
                DataRow rowNone = _dtMenus.NewRow();
                rowNone["MenuId"] = DBNull.Value;
                rowNone["Nombre"] = "(Ninguno)";
                rowNone["Precio"] = 0;
                _dtMenus.Rows.InsertAt(rowNone, 0);

                cboProductosMenu.DataSource = _dtMenus;
                cboProductosMenu.DisplayMember = "Nombre";
                cboProductosMenu.ValueMember = "MenuId";
            }
        }

        private void CargarCombos()
        {
            string error;
            _dtCombos = _ordenDAO.ObtenerCombosActivos(out error);
            if (_dtCombos != null)
            {
                DataRow rowNone = _dtCombos.NewRow();
                rowNone["ComboId"] = DBNull.Value;
                rowNone["Nombre"] = "(Ninguno)";
                rowNone["Precio"] = 0;
                _dtCombos.Rows.InsertAt(rowNone, 0);

                cboCombos.DataSource = _dtCombos;
                cboCombos.DisplayMember = "Nombre";
                cboCombos.ValueMember = "ComboId";
            }
        }

        private void CargarDescuentosActivos()
        {
            string error;
            DescuentoDAO descDAO = new DescuentoDAO();
            List<Descuento> todos = descDAO.ObtenerTodos(out error);
            if (todos != null)
            {
                _descuentosActivos = todos.FindAll(d =>
                    d.EstadoNombre == "ACTIVO" &&
                    d.FechaDesde <= DateTime.Today &&
                    d.FechaHasta >= DateTime.Today);
            }
            else
            {
                _descuentosActivos = new List<Descuento>();
            }
        }

        private Descuento ObtenerDescuento(int? menuId, int? comboId)
        {
            if (_descuentosActivos == null) return null;
            foreach (var d in _descuentosActivos)
            {
                if ((menuId.HasValue && d.MenuId == menuId) ||
                    (comboId.HasValue && d.ComboId == comboId))
                    return d;
            }
            return null;
        }

        // ==================== EVENTOS DE SELECCIÓN ====================
        private void cboProductosMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductosMenu.SelectedItem is DataRowView drv && drv["MenuId"] != DBNull.Value)
            {
                int menuId = (int)drv["MenuId"];
                decimal precio = Convert.ToDecimal(drv["Precio"]);
                txtPrecioMenuOCombo.Text = precio.ToString("F2");
                MostrarDescuentoEnTextBox(menuId, null);
            }
            else
            {
                txtPrecioMenuOCombo.Text = "";
                txtDescuento.Text = "";
            }
        }

        private void cboCombos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCombos.SelectedItem is DataRowView drv && drv["ComboId"] != DBNull.Value)
            {
                int comboId = (int)drv["ComboId"];
                decimal precio = Convert.ToDecimal(drv["Precio"]);
                txtPrecioMenuOCombo.Text = precio.ToString("F2");
                MostrarDescuentoEnTextBox(null, comboId);
            }
            else
            {
                txtPrecioMenuOCombo.Text = "";
                txtDescuento.Text = "";
            }
        }

        private void MostrarDescuentoEnTextBox(int? menuId, int? comboId)
        {
            var desc = ObtenerDescuento(menuId, comboId);
            if (desc != null)
                txtDescuento.Text = $"{desc.Nombre} - {desc.Porcentaje}%";
            else
                txtDescuento.Text = "";
        }

        // ==================== AGREGAR ITEM ====================
        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (numUpDownCantidadMenuOCombo.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrecioMenuOCombo.Text) || !decimal.TryParse(txtPrecioMenuOCombo.Text, out decimal precio))
            {
                MessageBox.Show("Seleccione un producto o combo primero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? menuId = (cboProductosMenu.SelectedValue is int mid && mid > 0) ? mid : (int?)null;
            int? comboId = (cboCombos.SelectedValue is int cid && cid > 0) ? cid : (int?)null;

            if (!menuId.HasValue && !comboId.HasValue)
            {
                MessageBox.Show("Debe seleccionar un producto o un combo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Descuento descuento = ObtenerDescuento(menuId, comboId);

            DetalleOrdenItem item = new DetalleOrdenItem
            {
                MenuId = menuId,
                ComboId = comboId,
                NombreProducto = menuId.HasValue ? cboProductosMenu.Text : cboCombos.Text,
                Cantidad = (int)numUpDownCantidadMenuOCombo.Value,
                PrecioUnitario = precio,
                PorcentajeDescuento = descuento?.Porcentaje,
                NombreDescuento = descuento?.Nombre
            };

            _carrito.Add(item);
            ActualizarGrilla();
            CalcularTotal();
        }

        private void ActualizarGrilla()
        {
            dgvDetalleOrden.DataSource = null;
            dgvDetalleOrden.AutoGenerateColumns = true;
            dgvDetalleOrden.DataSource = _carrito.Select(d => new
            {
                Producto = d.NombreProducto,
                d.Cantidad,
                PrecioUnitario = d.PrecioUnitario.ToString("F2"),
                Descuento = d.PorcentajeDescuento.HasValue ? $"{d.NombreDescuento} ({d.PorcentajeDescuento}%)" : "",
                PrecioConDescuento = d.PrecioConDescuento.ToString("F2"),
                Total = d.Total.ToString("F2")
            }).ToList();
        }

        private void CalcularTotal()
        {
            // El descuento ya está aplicado por ítem, simplemente sumamos los totales de cada línea
            decimal total = _carrito.Sum(i => i.Total);
            txtTotalPagar.Text = total.ToString("F2");
        }

        // ==================== CONFIRMAR ORDEN ====================
        private void btnConfirmarOrden_Click(object sender, EventArgs e)
        {
            if (!ValidarOrden()) return;

            int estadoId = 15; // ID del estado "PENDIENTE"
            string error;

            // Ya no enviamos _descuentoIdSeleccionado porque los descuentos son por ítem
            int ordenId = _ordenDAO.RegistrarOrden(
                (int)cboClientes.SelectedValue,
                (int)cboTipoOrden.SelectedValue,
                null, // Sin descuento global
                estadoId,
                _carrito,
                out error);

            if (ordenId == 0 || !string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al registrar la orden: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Orden registrada exitosamente (ID: {ordenId}).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private bool ValidarOrden()
        {
            if (cboClientes.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboTipoOrden.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un tipo de orden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_carrito.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto o combo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _carrito.Clear();
            dgvDetalleOrden.DataSource = null;
            txtTotalPagar.Text = "0.00";
            txtDescuento.Text = "";
            numUpDownCantidadMenuOCombo.Value = 0;
            txtPrecioMenuOCombo.Text = "";
            if (cboClientes.Items.Count > 0) cboClientes.SelectedIndex = 0;
            if (cboTipoOrden.Items.Count > 0) cboTipoOrden.SelectedIndex = 0;
            if (cboProductosMenu.Items.Count > 0) cboProductosMenu.SelectedIndex = 0;
            if (cboCombos.Items.Count > 0) cboCombos.SelectedIndex = 0;
        }

        // ==================== CRUD DESCUENTOS ====================
        private void btnCrudDescuentos_Click(object sender, EventArgs e)
        {
            using (frmDescuentosPopup popup = new frmDescuentosPopup())
            {
                popup.ShowDialog(this);
            }
            CargarDescuentosActivos(); // refrescar al cerrar
        }

        // ==================== EVENTOS VACÍOS ====================
        private void cbxDescuento_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboTipoOrden_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpFechaOrden_ValueChanged(object sender, EventArgs e) { }
        private void numUpDownCantidadMenuOCombo_ValueChanged(object sender, EventArgs e) { }
        private void txtPrecioMenuOCombo_TextChanged(object sender, EventArgs e) { }
        private void dgvDetalleOrden_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtTotalPagar_TextChanged(object sender, EventArgs e) { }
        private void txtDescuento_TextChanged(object sender, EventArgs e) { }
    }
}