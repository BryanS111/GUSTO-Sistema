using DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmDireccionLocalPopup : Form
    {
        private DeliveryDAO _dao;
        private List<Municipio> _listaMunicipios;

        public frmDireccionLocalPopup()
        {
            InitializeComponent();
            _dao = new DeliveryDAO();
            this.Load += new EventHandler(frmDireccionLocalPopup_Load); // ← línea clave
        }

        private void frmDireccionLocalPopup_Load(object sender, EventArgs e)
        {
            CargarMunicipios();
            CargarConfiguracionLocal();
        }

        private void CargarMunicipios()
        {
            string error;
            MunicipioDAO munDAO = new MunicipioDAO();
            _listaMunicipios = munDAO.ObtenerTodos(out error);
            if (_listaMunicipios != null)
            {
                cboMunicipio.DataSource = _listaMunicipios;
                cboMunicipio.DisplayMember = "Nombre";
                cboMunicipio.ValueMember = "MunicipioId";
            }
            else
            {
                MessageBox.Show("Error al cargar municipios: " + error);
            }
        }

        private void CargarConfiguracionLocal()
        {
            string error;
            // Obtener la configuración actual (devuelve un DataRow con MunicipioId y ColoniaBarrio)
            var config = _dao.ObtenerConfiguracionLocal(out error);
            if (config != null)
            {
                // Buscar el municipio en la lista y seleccionarlo
                int municipioId = Convert.ToInt32(config["MunicipioId"]);
                foreach (var mun in _listaMunicipios)
                {
                    if (mun.MunicipioId == municipioId)
                    {
                        cboMunicipio.SelectedValue = mun.MunicipioId;
                        break;
                    }
                }
                txtColoniaBarrio.Text = config["ColoniaBarrio"]?.ToString();
            }
        }

        private void btnEstablecerDireccion_Click(object sender, EventArgs e)
        {
            if (cboMunicipio.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un municipio.");
                return;
            }
            int municipioId = (int)cboMunicipio.SelectedValue;
            string colonia = txtColoniaBarrio.Text.Trim();
            string error;
            _dao.GuardarConfiguracionLocal(municipioId, colonia, out error);
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show("Error: " + error);
            else
            {
                MessageBox.Show("Ubicación guardada.");
                this.Close();
            }
        }

        // Eventos vacíos requeridos
        private void cboMunicipio_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtColoniaBarrio_TextChanged(object sender, EventArgs e) { }
    }
}