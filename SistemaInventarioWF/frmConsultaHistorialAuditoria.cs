using DAO;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmConsultaHistorialAuditoria : Form
    {
        private AuditoriaDAO _auditoriaDAO;

        public frmConsultaHistorialAuditoria()
        {
            InitializeComponent();
            _auditoriaDAO = new AuditoriaDAO();
            this.Load += new EventHandler(frmConsultaHistorialAuditoria_Load);
        }

        private void frmConsultaHistorialAuditoria_Load(object sender, EventArgs e)
        {
            CargarAcciones();
            dgvFechaInicio.Value = DateTime.Today.AddMonths(-1);
            dgvFechaFinal.Value = DateTime.Today;
            EjecutarBusqueda();
        }

        private void CargarAcciones()
        {
            string error;
            DataTable dt = _auditoriaDAO.ObtenerAccionesEvento(out error);
            if (dt != null)
            {
                // Agregar opción "Todos"
                DataRow row = dt.NewRow();
                row["Codigo"] = DBNull.Value;
                row["Accion de Evento"] = "Todos";
                dt.Rows.InsertAt(row, 0);

                cboAccion.DataSource = dt;
                cboAccion.DisplayMember = "Accion de Evento";
                cboAccion.ValueMember = "Codigo";
                cboAccion.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Error al cargar acciones: " + error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarBusqueda();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            if (cboAccion.Items.Count > 0) cboAccion.SelectedIndex = 0;
            dgvFechaInicio.Value = DateTime.Today.AddMonths(-1);
            dgvFechaFinal.Value = DateTime.Today;
            dgvHistorialAuditoria.DataSource = null;
        }

        private void EjecutarBusqueda()
        {
            if (dgvFechaInicio.Value.Date > dgvFechaFinal.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usuario = txtBuscar.Text.Trim();
            int? accionId = null;
            if (cboAccion.SelectedValue != null && cboAccion.SelectedValue != DBNull.Value)
                accionId = (int)cboAccion.SelectedValue;

            string error;
            DataTable dt = _auditoriaDAO.ObtenerHistorial(
                usuario,
                accionId,
                dgvFechaInicio.Value.Date,
                dgvFechaFinal.Value.Date,
                out error);

            if (dt == null)
            {
                MessageBox.Show("Error al consultar historial: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvHistorialAuditoria.DataSource = dt;

            // Ajustar automáticamente el ancho de columnas y alto de filas al contenido
            dgvHistorialAuditoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHistorialAuditoria.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Ocultar ID del historial
            if (dgvHistorialAuditoria.Columns["HistorialId"] != null)
                dgvHistorialAuditoria.Columns["HistorialId"].Visible = false;

            if (dgvHistorialAuditoria.Columns["FechaHora"] != null)
                dgvHistorialAuditoria.Columns["FechaHora"].HeaderText = "Fecha y Hora";

            if (dgvHistorialAuditoria.Columns["UsuarioId"] != null)
                dgvHistorialAuditoria.Columns["UsuarioId"].HeaderText = "Usuario ID";

            if (dgvHistorialAuditoria.Columns["Usuario"] != null)
                dgvHistorialAuditoria.Columns["Usuario"].HeaderText = "Usuario";
        }

        // Eventos vacíos del diseñador (no eliminar)
        private void label2_Click(object sender, EventArgs e) { }
        private void txtBuscar_TextChanged(object sender, EventArgs e) { }
        private void dgvFechaInicio_ValueChanged(object sender, EventArgs e) { }
        private void cboAccion_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvFechaFinal_ValueChanged(object sender, EventArgs e) { }
        private void dgvHistorialAuditoria_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }
    }
}
