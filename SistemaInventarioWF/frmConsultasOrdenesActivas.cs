using DAO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmConsultasOrdenesActivas : Form
    {
        private OrdenDAO _ordenDAO;
        private VentaDAO _ventaDAO;

        public frmConsultasOrdenesActivas()
        {
            InitializeComponent();
            _ordenDAO = new OrdenDAO();
            _ventaDAO = new VentaDAO();
            this.Load += new EventHandler(frmConsultasOrdenesActivas_Load);
        }

        private void frmConsultasOrdenesActivas_Load(object sender, EventArgs e)
        {
            CargarOrdenesActivas();
        }

        private void CargarOrdenesActivas()
        {
            string error;
            DataTable dt = _ordenDAO.ObtenerOrdenesActivas(out error);
            if (dt == null)
            {
                MessageBox.Show("Error al cargar órdenes: " + error, "Error");
                return;
            }

            dgvOrdenesActivas.DataSource = dt;

            // Ocultar columna de ID de orden (opcional)
            //if (dgvOrdenesActivas.Columns["OrdenId"] != null)
            //    dgvOrdenesActivas.Columns["OrdenId"].Visible = false;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarOrdenesActivas();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesActivas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una orden para ver su detalle.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRowView drv = dgvOrdenesActivas.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv == null) return;

            int ordenId = Convert.ToInt32(drv["OrdenId"]);
            string cliente = drv["Cliente"].ToString();
            string total = Convert.ToDecimal(drv["Total"]).ToString("F2");

            string error;
            DataTable dtDetalle = _ventaDAO.ObtenerDetalleOrden(ordenId, out error);
            if (dtDetalle == null)
            {
                MessageBox.Show("Error al obtener detalle: " + error, "Error");
                return;
            }

            // Crear popup dinámico para mostrar el detalle
            Form popup = new Form();
            popup.Text = $"Detalle Orden #{ordenId} - {cliente} (Total: ${total})";
            popup.Size = new Size(600, 400);
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.MaximizeBox = false;
            popup.MinimizeBox = false;

            // Asignar ícono personalizado desde un archivo .ico
            string rutaIcono = System.IO.Path.Combine(Application.StartupPath, "icono.ico");
            if (System.IO.File.Exists(rutaIcono))
                popup.Icon = new Icon(rutaIcono);

            DataGridView dgvDetalle = new DataGridView();
            dgvDetalle.Dock = DockStyle.Fill;
            dgvDetalle.DataSource = dtDetalle;
            dgvDetalle.AutoGenerateColumns = true;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;

            Button btnCerrar = new Button();
            btnCerrar.Text = "Cerrar";
            btnCerrar.Dock = DockStyle.Bottom;
            btnCerrar.Click += (s, args) => popup.Close();

            popup.Controls.Add(dgvDetalle);
            popup.Controls.Add(btnCerrar);
            popup.ShowDialog(this);
        }

        private void dgvOrdenesActivas_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}