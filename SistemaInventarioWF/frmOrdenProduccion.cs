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
    public partial class frmOrdenProduccion : Form
    {
        private ProduccionDAO _dao;
        private List<DetalleProduccionItem> _detalle;
        private DataTable _dtInventario;
        private DataTable _dtMenus;

        public frmOrdenProduccion()
        {
            InitializeComponent();
            _dao = new ProduccionDAO();
            _detalle = new List<DetalleProduccionItem>();

            // Configurar solo lectura
            txtNumOrden.ReadOnly = true;
            txtCostoUnitario.ReadOnly = true;
            txtTotalCosto.ReadOnly = true;

            this.Load += frmOrdenProduccion_Load;
        }

        private void frmOrdenProduccion_Load(object sender, EventArgs e)
        {
            CargarCocineros();
            CargarInventario();
            CargarMenus();
            GenerarNumeroOrden();
            LimpiarFormulario(false);
        }

        private void CargarCocineros()
        {
            string error;
            DataTable dt = _dao.ObtenerCocineros(out error);
            if (dt != null)
            {
                cboEmpleado.DataSource = dt;
                cboEmpleado.DisplayMember = "DisplayText";   // ← antes decía "NombreCompleto"
                cboEmpleado.ValueMember = "EmpleadoId";
            }
            else
                MessageBox.Show(error, "Error");
        }

        private void CargarInventario()
        {
            string error;
            _dtInventario = _dao.ObtenerInventario(out error);
            if (_dtInventario != null)
            {
                cboInsumo.DataSource = _dtInventario;
                cboInsumo.DisplayMember = "Producto";
                cboInsumo.ValueMember = "Codigo";
            }
            else
                MessageBox.Show(error, "Error");
        }

        private void CargarMenus()
        {
            string error;
            _dtMenus = _dao.ObtenerMenusActivos(out error);
            if (_dtMenus != null)
            {
                txtProductoFinal.DataSource = _dtMenus;
                txtProductoFinal.DisplayMember = "Nombre";
                txtProductoFinal.ValueMember = "MenuId";
            }
        }

        private void GenerarNumeroOrden()
        {
            string error;
            string num = _dao.ObtenerSiguienteNoOrden(out error);
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(error, "Error");
            txtNumOrden.Text = num;
        }

        private void cboInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtInventario == null || cboInsumo.SelectedItem == null) return;
            if (cboInsumo.SelectedItem is DataRowView drv)
            {
                decimal precio = Convert.ToDecimal(drv["Precio Costo"]);
                txtCostoUnitario.Text = precio.ToString("F2");
            }
        }

        private void btnAgregarInsumo_Click(object sender, EventArgs e)
        {
            if (cboInsumo.SelectedValue == null || string.IsNullOrWhiteSpace(txtCostoUnitario.Text))
            {
                MessageBox.Show("Seleccione un insumo y verifique el costo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double cantidad = (double)numUpDownCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int inventarioId = (int)cboInsumo.SelectedValue;
            string producto = cboInsumo.Text;
            decimal costo = decimal.Parse(txtCostoUnitario.Text);

            _detalle.Add(new DetalleProduccionItem
            {
                InventarioId = inventarioId,
                Producto = producto,
                Cantidad = cantidad,
                CostoUnitario = costo
            });

            ActualizarGrilla();
            CalcularTotal();
        }

        private void ActualizarGrilla()
        {
            dgvDetalle.DataSource = null;
            dgvDetalle.AutoGenerateColumns = true;
            dgvDetalle.DataSource = _detalle.Select(d => new
            {
                d.Producto,
                d.Cantidad,
                CostoUnitario = d.CostoUnitario.ToString("F2"),
                Total = d.Total.ToString("F2")
            }).ToList();
        }

        private void CalcularTotal()
        {
            decimal total = _detalle.Sum(d => d.Total);
            txtTotalCosto.Text = total.ToString("F2");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)  // button2
        {
            LimpiarFormulario(true);
        }

        private void btnConfirmar_Click(object sender, EventArgs e) // button3
        {
            if (!Validar()) return;

            // Obtener el valor del NumericUpDown de cantidad de producto final
            int? cantidadProducto = (int)numUpDownCantidadProducto.Value > 0 ? (int)numUpDownCantidadProducto.Value : (int?)null;

            string error;
            _dao.RegistrarProduccion(
                txtNumOrden.Text.Trim(),
                dtpFecha.Value,
                (int)cboEmpleado.SelectedValue,
                SesionActual.UsuarioId,
                txtProductoFinal.SelectedValue?.ToString(),
                cantidadProducto,        // ← ahora sí existe
                _detalle,
                out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al registrar producción: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Producción registrada exitosamente. Inventario descontado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario(true);
            GenerarNumeroOrden();
        }

        private bool Validar()
        {
            if (cboEmpleado.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cocinero/a.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_detalle.Count == 0)
            {
                MessageBox.Show("Agregue al menos un insumo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormulario(bool limpiarGrilla)
        {
            if (limpiarGrilla)
            {
                _detalle.Clear();
                dgvDetalle.DataSource = null;
            }
            txtTotalCosto.Text = "0.00";
            if (cboInsumo.Items.Count > 0) cboInsumo.SelectedIndex = 0;
            numUpDownCantidad.Value = 0.01m;   // valor mínimo
            numUpDownCantidadProducto.Value = 1; // nuevo control
            if (cboEmpleado.Items.Count > 0) cboEmpleado.SelectedIndex = 0;
            if (txtProductoFinal.Items.Count > 0) txtProductoFinal.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
        }
        private void cboEmpleado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtNumOrden_TextChanged(object sender, EventArgs e) { }
        private void dtpFecha_ValueChanged(object sender, EventArgs e) { }
        private void txtProductoFinal_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtCostoUnitario_TextChanged(object sender, EventArgs e) { }
        private void numUpDownCantidad_ValueChanged(object sender, EventArgs e) { }
        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtTotalCosto_TextChanged(object sender, EventArgs e) { }

        private void numUpDownCantidadProducto_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}