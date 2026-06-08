using DAO;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmProcesoDelivery : Form
    {
        private DeliveryDAO _dao;
        private DataTable _dtOrdenes;
        private DataTable _dtRepartidores;

        public frmProcesoDelivery()
        {
            InitializeComponent();
            _dao = new DeliveryDAO();
        }

        private void frmProcesoDelivery_Load(object sender, EventArgs e)
        {
            CargarOrdenes();
            CargarRepartidores();
            Limpiar();
        }

        private void CargarOrdenes()
        {
            string error;
            _dtOrdenes = _dao.ObtenerOrdenesPendientes(out error);
            if (_dtOrdenes != null)
            {
                cboOrdenesPendientes.DataSource = _dtOrdenes;
                cboOrdenesPendientes.DisplayMember = "DescripcionOrden";  // Columna descriptiva
                cboOrdenesPendientes.ValueMember = "OrdenId";
            }
            else
                MessageBox.Show("Error al cargar órdenes: " + error);
        }

        private void CargarRepartidores()
        {
            string error;
            _dtRepartidores = _dao.ObtenerRepartidoresDisponibles(out error);
            if (_dtRepartidores != null)
            {
                cboRepartidorDisponible.DataSource = _dtRepartidores;
                cboRepartidorDisponible.DisplayMember = "NombreCompleto";
                cboRepartidorDisponible.ValueMember = "RepartidorId";
            }
            else
                MessageBox.Show("Error al cargar repartidores: " + error);
        }

        private void cboOrdenesPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrdenesPendientes.SelectedItem is DataRowView drv)
            {
                txtCliente.Text = drv["ClienteNombre"].ToString();
                txtDireccion.Text = drv["DireccionCompleta"].ToString();
                txtCoordenadas.Text = drv["Coordenadas"]?.ToString();

                int municipioId = Convert.ToInt32(drv["MunicipioId"]);
                string error;
                decimal tarifa = _dao.ObtenerTarifa(municipioId, out error);
                txtTarifa.Text = tarifa.ToString("F2");
            }
        }

        private void btnLimpiarPantalla_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAsignarEnvio_Click(object sender, EventArgs e)
        {
            if (cboOrdenesPendientes.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una orden pendiente.");
                return;
            }
            if (cboRepartidorDisponible.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un repartidor disponible.");
                return;
            }

            // Obtener datos de la orden seleccionada
            DataRowView drvOrden = cboOrdenesPendientes.SelectedItem as DataRowView;
            if (drvOrden == null) return;

            int ordenId = (int)cboOrdenesPendientes.SelectedValue;
            int repartidorId = (int)cboRepartidorDisponible.SelectedValue;
            int direccionId = Convert.ToInt32(drvOrden["DireccionId"]);
            decimal tarifa = decimal.Parse(txtTarifa.Text);

            string error;
            _dao.AsignarEnvio(ordenId, repartidorId, direccionId, tarifa, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Error al asignar envío: " + error);
                return;
            }

            MessageBox.Show("Envío asignado exitosamente.");

            // Abrir popup de WhatsApp
            string telefonoRepartidor = _dao.ObtenerTelefonoRepartidor(repartidorId, out error);
            if (!string.IsNullOrEmpty(telefonoRepartidor))
            {
                string cliente = drvOrden["ClienteNombre"].ToString();
                string direccion = drvOrden["DireccionCompleta"].ToString();
                string coordenadas = drvOrden["Coordenadas"]?.ToString();
                string telefonoCliente = drvOrden["ClienteTelefono"]?.ToString();
                string nombreRepartidor = cboRepartidorDisponible.Text;
                string mensaje = $"¡NUEVA ORDEN!\nCliente: {cliente}\nCódigo: {ordenId}\nDirección: {direccion}\nCoordenadas: {coordenadas}\nNúmero de teléfono: {telefonoCliente}";

                frmWhatpsAppOrden popup = new frmWhatpsAppOrden(nombreRepartidor, telefonoRepartidor, mensaje);
                popup.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No se pudo obtener el teléfono del repartidor.");
            }

            Limpiar();
            CargarOrdenes();
        }
        private void Limpiar()
        {
            txtCliente.Text = "";
            txtDireccion.Text = "";
            txtCoordenadas.Text = "";
            txtTarifa.Text = "0.00";
            if (cboOrdenesPendientes.Items.Count > 0)
                cboOrdenesPendientes.SelectedIndex = -1;
            if (cboRepartidorDisponible.Items.Count > 0)
                cboRepartidorDisponible.SelectedIndex = 0;
        }

        // Evento para abrir configuración de local y tarifas (agregar botón btnDefinirDireccionLocal en el diseñador)
        private void btnDefinirDireccionLocal_Click(object sender, EventArgs e)
        {
            frmDireccionLocalPopup popup = new frmDireccionLocalPopup();
            popup.ShowDialog(this);
        }

        // Eventos vacíos requeridos por el diseñador (no eliminar)
        private void txtCliente_TextChanged(object sender, EventArgs e) { }
        private void cboRepartidorDisponible_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtTarifa_TextChanged(object sender, EventArgs e) { }
        private void txtDireccion_TextChanged(object sender, EventArgs e) { }
        private void txtCoordenadas_TextChanged(object sender, EventArgs e) { }
    }
}