using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmInicio_Dashboard : Form
    {
        public frmInicio_Dashboard()
        {
            InitializeComponent();
            btnManualUso.Click += btnManualUso_Click;
        }

        private void btnManualUso_Click(object sender, EventArgs e)
        {
            string rutaManual = ObtenerRutaManualUso();

            if (string.IsNullOrWhiteSpace(rutaManual) || !File.Exists(rutaManual))
            {
                MessageBox.Show(
                    "No se encontro el archivo ManualDeUso-GUSTO.pdf.",
                    "Manual de uso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaManual,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo abrir el manual de uso: " + ex.Message,
                    "Manual de uso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string ObtenerRutaManualUso()
        {
            string[] candidatos =
            {
                Path.GetFullPath(Path.Combine(Application.StartupPath, "ManualDeUso-GUSTO.pdf")),
                Path.GetFullPath(Path.Combine(Application.StartupPath, "assets", "documentacion", "ManualDeUso-GUSTO.pdf")),
                Path.GetFullPath(Path.Combine(Application.StartupPath, "..", "..", "..", "assets", "documentacion", "ManualDeUso-GUSTO.pdf")),
                Path.GetFullPath(Path.Combine(Application.StartupPath, "..", "..", "assets", "documentacion", "ManualDeUso-GUSTO.pdf"))
            };

            foreach (string candidato in candidatos)
            {
                if (File.Exists(candidato))
                {
                    return candidato;
                }
            }

            return candidatos[2];
        }
    }
}
