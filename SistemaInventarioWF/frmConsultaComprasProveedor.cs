using DAO;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmConsultaComprasProveedor : Form
    {
        private CompraDAO _compraDAO;

        public frmConsultaComprasProveedor()
        {
            InitializeComponent();
            _compraDAO = new CompraDAO();
            this.Load += new EventHandler(frmConsultaComprasProveedor_Load);
        }

        private void frmConsultaComprasProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            dtpFechaInicio.Value = DateTime.Today.AddMonths(-1);
            dtpFechaFinal.Value = DateTime.Today;
            EjecutarBusqueda();
        }

        private void CargarProveedores()
        {
            string error;
            DataTable dt = _compraDAO.ObtenerProveedoresActivos(out error);
            if (dt != null)
            {
                // Agregar opción "Todos"
                DataRow rowTodos = dt.NewRow();
                rowTodos["Codigo"] = DBNull.Value;
                rowTodos["Nombre"] = "Todos";
                dt.Rows.InsertAt(rowTodos, 0);

                cboProveedor.DataSource = dt;
                cboProveedor.DisplayMember = "Nombre";
                cboProveedor.ValueMember = "Codigo";
                cboProveedor.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Error al cargar proveedores: " + error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarBusqueda();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today.AddMonths(-1);
            dtpFechaFinal.Value = DateTime.Today;
            if (cboProveedor.Items.Count > 0) cboProveedor.SelectedIndex = 0;
            dgvComprasProveedor.DataSource = null;
        }

        private void EjecutarBusqueda()
        {
            if (dtpFechaInicio.Value.Date > dtpFechaFinal.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? proveedorId = null;
            if (cboProveedor.SelectedValue != null && cboProveedor.SelectedValue != DBNull.Value)
                proveedorId = (int)cboProveedor.SelectedValue;

            string error;
            DataTable dt = _compraDAO.ObtenerComprasPorProveedor(
                proveedorId,
                dtpFechaInicio.Value,
                dtpFechaFinal.Value,
                out error);

            if (dt == null)
            {
                MessageBox.Show("Error al consultar compras: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvComprasProveedor.DataSource = dt;

            // Ocultar columna de ID de compra (opcional)
            if (dgvComprasProveedor.Columns["CompraId"] != null)
                dgvComprasProveedor.Columns["CompraId"].Visible = false;
        }

        // Eventos vacíos del diseñador (no eliminar)
        private void cboProveedor_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e) { }
        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e) { }
    }
}