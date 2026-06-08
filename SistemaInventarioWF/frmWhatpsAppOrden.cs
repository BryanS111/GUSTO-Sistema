using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmWhatpsAppOrden : Form
    {
        private string _telefono;
        private string _mensaje;
        private string _nombreRepartidor;

        public frmWhatpsAppOrden(string nombreRepartidor, string telefono, string mensaje)
        {
            InitializeComponent();
            _nombreRepartidor = nombreRepartidor;
            _telefono = telefono;
            _mensaje = mensaje;

            txtMensaje.Text = $"Desea solicitar envio al whatsapp de {_nombreRepartidor}";
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            string url = $"https://wa.me/{_telefono}?text={Uri.EscapeDataString(_mensaje)}";
            Process.Start(url);
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Método temporal para evitar errores de diseñador
        private void txtColoniaBarrio_TextChanged(object sender, EventArgs e) { }

        private void txtMensaje_TextChanged(object sender, EventArgs e) { }
    }
}