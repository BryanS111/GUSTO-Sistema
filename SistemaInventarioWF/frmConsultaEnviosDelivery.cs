using DAO;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmConsultaEnviosDelivery : Form
    {
        private DeliveryDAO _deliveryDAO;

        public frmConsultaEnviosDelivery()
        {
            InitializeComponent();
            _deliveryDAO = new DeliveryDAO();
            this.Load += new EventHandler(frmConsultaEnviosDelivery_Load);
        }

        private void frmConsultaEnviosDelivery_Load(object sender, EventArgs e)
        {
            // El combo ya tiene items fijos: "Todos", "En Camino", "Entregado", "Cancelado"
            if (cboEstadoEnvio.Items.Count > 0)
                cboEstadoEnvio.SelectedIndex = 0;

            EjecutarBusqueda();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            EjecutarBusqueda();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            if (cboEstadoEnvio.Items.Count > 0)
                cboEstadoEnvio.SelectedIndex = 0;
            dgvEnviosDelivery.DataSource = null;
        }

        private void EjecutarBusqueda()
        {
            string repartidor = txtBuscar.Text.Trim();
            string estado = cboEstadoEnvio.SelectedItem?.ToString();

            string error;
            DataTable dt = _deliveryDAO.ObtenerEnvios(repartidor, estado, out error);

            if (dt == null)
            {
                MessageBox.Show("Error al consultar envíos: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvEnviosDelivery.DataSource = dt;

            // Ocultar columnas internas
            if (dgvEnviosDelivery.Columns["EnvioId"] != null)
                dgvEnviosDelivery.Columns["EnvioId"].Visible = false;
            if (dgvEnviosDelivery.Columns["DireccionId"] != null)
                dgvEnviosDelivery.Columns["DireccionId"].Visible = false;
        }

        // Eventos vacíos del diseñador (no eliminar)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void txtBuscar_TextChanged(object sender, EventArgs e) { }
    }
}