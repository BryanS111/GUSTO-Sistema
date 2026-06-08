using DAO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmProcesoVenta : Form
    {
        private VentaDAO _dao;

        public frmProcesoVenta()
        {
            InitializeComponent();
            _dao = new VentaDAO();
            this.Load += frmProcesoVenta_Load;
        }

        private void frmProcesoVenta_Load(object sender, EventArgs e)
        {
            CargarOrdenesPendientes();
            CargarMetodosPago();
            dtpFecha.Value = DateTime.Today;
            GenerarNumeroDocumento();
            Limpiar(false);
        }

        private void CargarOrdenesPendientes()
        {
            string error;
            DataTable dt = _dao.ObtenerOrdenesPendientes(out error);
            if (dt != null)
            {
                cboOrdenesPendientes.DataSource = dt;
                cboOrdenesPendientes.DisplayMember = "DisplayOrden";
                cboOrdenesPendientes.ValueMember = "OrdenId";
            }
            else
                MessageBox.Show("Error al cargar órdenes: " + error);
        }

        private void CargarMetodosPago()
        {
            string error;
            DataTable dt = _dao.ObtenerMetodosPago(out error);
            if (dt != null)
            {
                cboMetodoPago.DataSource = dt;
                cboMetodoPago.DisplayMember = "Metodo";
                cboMetodoPago.ValueMember = "MetodoPagoId";
            }
            else
                MessageBox.Show("Error al cargar métodos de pago: " + error);
        }

        private void GenerarNumeroDocumento()
        {
            string error;
            txtNoDocumento.Text = _dao.ObtenerSiguienteNoDocumento(out error);
        }

        private void cboOrdenesPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOrdenesPendientes.SelectedItem is DataRowView drv)
            {
                txtCliente.Text = drv["ClienteNombre"].ToString();
                txtTipoOrden.Text = drv["TipoOrden"].ToString();
                txtTotalOrden.Text = Convert.ToDecimal(drv["Total"]).ToString("F2");

                int ordenId = Convert.ToInt32(drv["OrdenId"]);
                CargarDetalleOrden(ordenId);
            }
        }

        private void CargarDetalleOrden(int ordenId)
        {
            string error;
            DataTable dt = _dao.ObtenerDetalleOrden(ordenId, out error);
            dgvDetalleOrden.DataSource = dt;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (cboOrdenesPendientes.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una orden pendiente.", "Validación");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMontoRecibido.Text) || !decimal.TryParse(txtMontoRecibido.Text, out decimal montoRecibido))
            {
                MessageBox.Show("Ingrese un monto recibido válido.", "Validación");
                return;
            }

            int ordenId = (int)cboOrdenesPendientes.SelectedValue;
            decimal total = decimal.Parse(txtTotalOrden.Text);
            string metodoPago = cboMetodoPago.Text;
            string noDocumento = txtNoDocumento.Text.Trim();

            string error;
            _dao.RegistrarVenta(ordenId, dtpFecha.Value, noDocumento, metodoPago, montoRecibido, total, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show("Error al registrar la venta: " + error, "Error");
                return;
            }

            // Generar factura en PDF
            GenerarFacturaPDF(ordenId, total, metodoPago, montoRecibido);

            MessageBox.Show("Venta registrada exitosamente. Factura generada.", "Éxito");
            Limpiar(true);
            GenerarNumeroDocumento();
            CargarOrdenesPendientes();
        }

        private void GenerarFacturaPDF(int ordenId, decimal total, string metodoPago, decimal montoRecibido)
        {
            string ruta = Path.Combine(Application.StartupPath, $"Factura_{ordenId}.pdf");

            using (FileStream fs = new FileStream(ruta, FileMode.Create))
            {
                Document doc = new Document(PageSize.A6, 10, 10, 10, 10);
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                BaseColor colorRojo = new BaseColor(139, 0, 0);
                iTextSharp.text.Font tituloFont = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = FontFactory.GetFont("Arial", 10);
                iTextSharp.text.Font negrita = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);

                string logoPath = Path.Combine(Application.StartupPath, "logo.png");
                if (File.Exists(logoPath))
                {
                    Image logo = Image.GetInstance(logoPath);
                    logo.ScaleToFit(80f, 80f);
                    logo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(logo);
                }

                Paragraph nombreSoft = new Paragraph("G.U.S.T.O", tituloFont);
                nombreSoft.Alignment = Element.ALIGN_CENTER;
                doc.Add(nombreSoft);

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph("FACTURA DE VENTA", negrita) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph($"No. Documento: {txtNoDocumento.Text}", normalFont));
                doc.Add(new Paragraph($"Fecha: {dtpFecha.Value:dd/MM/yyyy}", normalFont));
                doc.Add(new Paragraph($"Cliente: {txtCliente.Text}", normalFont));
                doc.Add(new Paragraph($"Tipo Orden: {txtTipoOrden.Text}", normalFont));
                doc.Add(new Paragraph(" "));

                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.AddCell(new PdfPCell(new Phrase("Producto", negrita)));
                table.AddCell(new PdfPCell(new Phrase("Cant.", negrita)));
                table.AddCell(new PdfPCell(new Phrase("P.Unit", negrita)));
                table.AddCell(new PdfPCell(new Phrase("Total", negrita)));

                DataTable detalle = (DataTable)dgvDetalleOrden.DataSource;
                if (detalle != null)
                {
                    foreach (DataRow row in detalle.Rows)
                    {
                        table.AddCell(new PdfPCell(new Phrase(row["Producto"].ToString(), normalFont)));
                        table.AddCell(new PdfPCell(new Phrase(row["Cantidad"].ToString(), normalFont)));
                        table.AddCell(new PdfPCell(new Phrase("$" + Convert.ToDecimal(row["PrecioUnitario"]).ToString("F2"), normalFont)));
                        table.AddCell(new PdfPCell(new Phrase("$" + Convert.ToDecimal(row["Total"]).ToString("F2"), normalFont)));
                    }
                }
                doc.Add(table);

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"Total a pagar: ${total:F2}", negrita));
                doc.Add(new Paragraph($"Método de pago: {metodoPago}", normalFont));
                doc.Add(new Paragraph($"Monto recibido: ${montoRecibido:F2}", normalFont));
                doc.Add(new Paragraph($"Cambio: ${(montoRecibido - total):F2}", negrita));

                doc.Close();
            }

            System.Diagnostics.Process.Start(ruta);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(true);
        }

        private void Limpiar(bool recargarOrdenes)
        {
            txtCliente.Text = "";
            txtTipoOrden.Text = "";
            txtTotalOrden.Text = "";
            txtMontoRecibido.Text = "";
            dgvDetalleOrden.DataSource = null;
            if (cboOrdenesPendientes.Items.Count > 0)
                cboOrdenesPendientes.SelectedIndex = -1;
            if (recargarOrdenes)
                CargarOrdenesPendientes();
        }

        // Eventos vacíos del diseñador
        private void label6_Click(object sender, EventArgs e) { }
        private void txtTotalOrden_TextChanged(object sender, EventArgs e) { }
        private void txtNoDocumento_TextChanged(object sender, EventArgs e) { }
        private void txtCliente_TextChanged(object sender, EventArgs e) { }
        private void dtpFecha_ValueChanged(object sender, EventArgs e) { }
        private void txtTipoOrden_TextChanged(object sender, EventArgs e) { }
        private void cboMetodoPago_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtMontoRecibido_TextChanged(object sender, EventArgs e) { }
    }
}