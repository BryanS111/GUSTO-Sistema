using DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class DireccionesMunicipiosView : Form
    {
        private InterfazPrincipal_Admin _abuelo;
        private DireccionDAO _direccionDAO;
        private List<Direccion> _listaDirecciones;
        private bool _modoEdicion;
        private int _direccionIdActual;

        public DireccionesMunicipiosView(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            _abuelo = abuelo;
            _direccionDAO = new DireccionDAO();
            _modoEdicion = false;
            _direccionIdActual = 0;
            this.Load += new EventHandler(DireccionesMunicipiosView_Load);
        }

        private void DireccionesMunicipiosView_Load(object sender, EventArgs e)
        {
            CargarComboMunicipio();
            CargarComboEstado(); // ← NUEVO
            CargarGrilla();
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new frmMantenimientos_Menu(_abuelo));
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _direccionIdActual = 0;
            LimpiarCampos();
            ModoFormulario(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDirecciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una dirección para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Direccion dir = (Direccion)dgvDirecciones.SelectedRows[0].DataBoundItem;
            _direccionIdActual = dir.DireccionId;

            cboMunicipio.SelectedValue = dir.MunicipioId;
            txtColoniaBarrio.Text = dir.ColoniaBarrio;
            numUpDownNoCasa.Value = string.IsNullOrEmpty(dir.NoCasa) ? 0 : int.Parse(dir.NoCasa);
            txtPuntoReferencia.Text = dir.PuntoReferencia;
            txtCoordenadas.Text = dir.CoordenadasMaps;

            // Cargar el estado actual en el combo
            if (dir.EstadoId > 0)
                cboEstado.SelectedValue = dir.EstadoId;
            else if (cboEstado.Items.Count > 0)
                cboEstado.SelectedIndex = 0;

            _modoEdicion = true;
            ModoFormulario(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            if (cboMunicipio.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un municipio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboEstado.SelectedValue == null) // ← validación del combo de estado
            {
                MessageBox.Show("Debe seleccionar un estado.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Direccion dir = new Direccion
            {
                MunicipioId = (int)cboMunicipio.SelectedValue,
                ColoniaBarrio = txtColoniaBarrio.Text.Trim(),
                NoCasa = numUpDownNoCasa.Value > 0 ? ((int)numUpDownNoCasa.Value).ToString() : null,
                PuntoReferencia = txtPuntoReferencia.Text.Trim(),
                CoordenadasMaps = txtCoordenadas.Text.Trim(),
                EstadoId = (int)cboEstado.SelectedValue // ← Se toma del combo
            };

            string error;
            if (!_modoEdicion)
            {
                _direccionDAO.GuardarRegistro(dir, out error);
            }
            else
            {
                dir.DireccionId = _direccionIdActual;
                _direccionDAO.ActualizarRegistro(dir, out error);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al guardar: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Dirección guardada exitosamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDirecciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una dirección para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Direccion dir = (Direccion)dgvDirecciones.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Desactivar la dirección en {dir.MunicipioNombre}, {dir.ColoniaBarrio}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string error;
            _direccionDAO.EliminarLogico(dir.DireccionId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al eliminar: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Dirección desactivada.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ModoFormulario(false);
        }

        // Métodos auxiliares
        private void CargarComboMunicipio()
        {
            string error;
            DataTable dt = _direccionDAO.ObtenerMunicipios(out error);
            if (dt != null)
            {
                cboMunicipio.DataSource = dt;
                cboMunicipio.DisplayMember = "Municipio";
                cboMunicipio.ValueMember = "Codigo";
            }
            else
            {
                MessageBox.Show($"Error al cargar municipios: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NUEVO: Cargar combo de estados para DIRECCION
        private void CargarComboEstado()
        {
            string error;
            DataTable dt = _direccionDAO.ObtenerEstadosDireccion(out error);
            if (dt != null)
            {
                cboEstado.DataSource = dt;
                cboEstado.DisplayMember = "Estado";
                cboEstado.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show($"Error al cargar estados: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla(string buscar = "")
        {
            string error;
            if (string.IsNullOrWhiteSpace(buscar))
                _listaDirecciones = _direccionDAO.ObtenerTodos(out error);
            else
                _listaDirecciones = _direccionDAO.Buscar(buscar, out error);

            if (_listaDirecciones == null)
            {
                MessageBox.Show($"Error al cargar direcciones: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvDirecciones.DataSource = null;
            dgvDirecciones.AutoGenerateColumns = true;
            dgvDirecciones.DataSource = _listaDirecciones;

            //if (dgvDirecciones.Columns["DireccionId"] != null)
            //    dgvDirecciones.Columns["DireccionId"].Visible = false;
            if (dgvDirecciones.Columns["MunicipioId"] != null)
                dgvDirecciones.Columns["MunicipioId"].Visible = false;
            if (dgvDirecciones.Columns["EstadoId"] != null)
                dgvDirecciones.Columns["EstadoId"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtColoniaBarrio.Clear();
            txtPuntoReferencia.Clear();
            txtCoordenadas.Clear();
            numUpDownNoCasa.Value = 0;
            if (cboMunicipio.Items.Count > 0) cboMunicipio.SelectedIndex = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0; // ← Limpiar estado
        }

        private void ModoFormulario(bool habilitar)
        {
            grpBoxData.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtColoniaBarrio.Text))
            {
                MessageBox.Show("La colonia/barrio es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtColoniaBarrio.Focus();
                return false;
            }
            return true;
        }

        // Eventos vacíos requeridos (no eliminar)
        private void txtBuscar_TextChanged(object sender, EventArgs e) { }
        private void cboMunicipio_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { } // ← Ya lo tenés
        private void numUpDownNoCasa_ValueChanged(object sender, EventArgs e) { }
        private void grpBoxData_Enter(object sender, EventArgs e) { }
        private void txtCoordenadas_TextChanged(object sender, EventArgs e) { }
        private void txtColoniaBarrio_TextChanged(object sender, EventArgs e) { }
        private void txtPuntoReferencia_TextChanged(object sender, EventArgs e) { }
        private void dgvDirecciones_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}