using DAO;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmConsultaVentasFecha : Form
    {
        private VentaDAO _ventaDAO;

        public frmConsultaVentasFecha()
        {
            InitializeComponent();
            _ventaDAO = new VentaDAO();
            this.Load += new EventHandler(frmConsultaVentasFecha_Load);
        }

        private void frmConsultaVentasFecha_Load(object sender, EventArgs e)
        {
            // Establecer rango por defecto: última semana
            dtpFechaFinal.Value = DateTime.Today;
            dtpFechaInicio.Value = DateTime.Today.AddDays(-7);

            // Cargar datos iniciales
            EjecutarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarBusqueda();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Botón Limpiar: restaurar fechas y limpiar grilla
            dtpFechaInicio.Value = DateTime.Today.AddDays(-7);
            dtpFechaFinal.Value = DateTime.Today;
            dgvVentasPorFecha.DataSource = null;
            txtTotalAcumulado.Text = "0.00";
        }

        private void EjecutarBusqueda()
        {
            // Validar que la fecha inicio no sea mayor que la fecha final
            if (dtpFechaInicio.Value.Date > dtpFechaFinal.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string error;
            DataTable dt = _ventaDAO.ObtenerVentasPorFecha(dtpFechaInicio.Value, dtpFechaFinal.Value, out error);

            if (dt == null)
            {
                MessageBox.Show("Error al consultar ventas: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvVentasPorFecha.DataSource = dt;

            // Calcular total acumulado
            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["Total"]);
            }
            txtTotalAcumulado.Text = total.ToString("F2");

            // Ocultar columna de ID de venta (opcional)
            if (dgvVentasPorFecha.Columns["VentaId"] != null)
                dgvVentasPorFecha.Columns["VentaId"].Visible = false;
        }

        // Eventos vacíos del diseñador (no eliminar)
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e) { }
        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e) { }
        private void dgvVentasPorFecha_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}