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
        private DataTable _dtDescuentos;
        private int? _descuentoIdSeleccionado;

        public frmRegistroOrden()
        {
            InitializeComponent();
            _ordenDAO = new OrdenDAO();
            _carrito = new List<DetalleOrdenItem>();
            _descuentoIdSeleccionado = null;

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
            CargarDescuentosActivos();
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
                // Agregar fila "Ninguno" al inicio
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
                // Agregar fila "Ninguno" al inicio
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
            _dtDescuentos = _ordenDAO.ObtenerDescuentosActivos(out error);
        }

        // ==================== EVENTOS DE SELECCIÓN ====================
        private void cboProductosMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductosMenu.SelectedItem is DataRowView drv && drv["MenuId"] != DBNull.Value)
            {
                txtPrecioMenuOCombo.Text = drv["Precio"].ToString();
                VerificarDescuentoAutomatico((int)drv["MenuId"], null);
            }
            else
            {
                txtPrecioMenuOCombo.Text = "";
                VerificarDescuentoAutomatico(null, null);
            }
        }

        private void cboCombos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCombos.SelectedItem is DataRowView drv && drv["ComboId"] != DBNull.Value)
            {
                txtPrecioMenuOCombo.Text = drv["Precio"].ToString();
                VerificarDescuentoAutomatico(null, (int)drv["ComboId"]);
            }
            else
            {
                txtPrecioMenuOCombo.Text = "";
                VerificarDescuentoAutomatico(null, null);
            }
        }

        private void VerificarDescuentoAutomatico(int? menuId, int? comboId)
        {
            if (_dtDescuentos == null) return;
            _descuentoIdSeleccionado = null;
            txtDescuento.Text = "";
            foreach (DataRow row in _dtDescuentos.Rows)
            {
                // Verificar si el descuento aplica al menú o combo seleccionado
                bool aplicaMenu = menuId.HasValue && row["MenuId"] != DBNull.Value && (int)row["MenuId"] == menuId.Value;
                bool aplicaCombo = comboId.HasValue && row["ComboId"] != DBNull.Value && (int)row["ComboId"] == comboId.Value;
                if (aplicaMenu || aplicaCombo)
                {
                    _descuentoIdSeleccionado = Convert.ToInt32(row["Id"]);
                    txtDescuento.Text = $"{row["Nombre"]} ({row["Porcentaje"]}%)";
                    break;
                }
            }
            CalcularTotal();
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

            DetalleOrdenItem item = new DetalleOrdenItem
            {
                Cantidad = (int)numUpDownCantidadMenuOCombo.Value,
                PrecioUnitario = precio
            };

            // Verificar si se seleccionó un menú o un combo (puede ser uno o el otro)
            if (cboProductosMenu.SelectedValue is int menuId)
            {
                item.MenuId = menuId;
                item.NombreProducto = cboProductosMenu.Text;
            }
            if (cboCombos.SelectedValue is int comboId)
            {
                item.ComboId = comboId;
                item.NombreProducto = cboCombos.Text;
            }

            if (!item.MenuId.HasValue && !item.ComboId.HasValue)
            {
                MessageBox.Show("Debe seleccionar al menos un producto o un combo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                Total = d.Total.ToString("F2")
            }).ToList();
        }

        private void CalcularTotal()
        {
            decimal subtotal = _carrito.Sum(i => i.Total);
            if (_descuentoIdSeleccionado.HasValue && _dtDescuentos != null)
            {
                DataRow[] rows = _dtDescuentos.Select($"Id = {_descuentoIdSeleccionado.Value}");
                if (rows.Length > 0)
                {
                    decimal porcentaje = Convert.ToDecimal(rows[0]["Porcentaje"]);
                    subtotal -= subtotal * porcentaje / 100;
                }
            }
            txtTotalPagar.Text = subtotal.ToString("F2");
        }

        // ==================== CONFIRMAR ORDEN ====================
        private void btnConfirmarOrden_Click(object sender, EventArgs e)
        {
            if (!ValidarOrden()) return;

            // Estado por defecto: PENDIENTE (debes obtener el ID real desde la BD, aquí usamos 1 como ejemplo)
            int estadoId = 1; // Ajustar con: SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'PENDIENTE' AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'ORDEN')
            string error;
            int ordenId = _ordenDAO.RegistrarOrden(
                (int)cboClientes.SelectedValue,
                (int)cboTipoOrden.SelectedValue,
                _descuentoIdSeleccionado,
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
            _descuentoIdSeleccionado = null;
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
            // Refrescar descuentos al cerrar
            CargarDescuentosActivos();
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