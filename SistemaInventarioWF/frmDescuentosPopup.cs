using DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmDescuentosPopup : Form
    {
        private DescuentoDAO _dao;
        private List<Descuento> _lista;
        private bool _modoEdicion;
        private int _idActual;

        public frmDescuentosPopup()
        {
            InitializeComponent();
            _dao = new DescuentoDAO();
            _modoEdicion = false;
            _idActual = 0;
            this.Load += frmDescuentosPopup_Load;
        }

        private void frmDescuentosPopup_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarGrilla();
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void CargarCombos()
        {
            string error;

            // Tipos de Descuento (nueva tabla exclusiva)
            DataTable dtTipo = _dao.ObtenerTiposDescuento(out error);
            if (dtTipo != null)
            {

                DataRow row = dtTipo.NewRow();
                row["TipoDescuentoId"] = DBNull.Value;
                row["Tipo"] = "(Ninguno)";
                dtTipo.Rows.InsertAt(row, 0);

                cboTipoDescuento.DataSource = dtTipo;
                cboTipoDescuento.DisplayMember = "Tipo";
                cboTipoDescuento.ValueMember = "TipoDescuentoId";
            }

            // Menús
            DataTable dtMenu = _dao.ObtenerMenus(out error);
            if (dtMenu != null)
            {
                DataRow row = dtMenu.NewRow();
                row["MenuId"] = DBNull.Value;
                row["Nombre"] = "(Ninguno)";
                dtMenu.Rows.InsertAt(row, 0);

                cboMenu.DataSource = dtMenu;
                cboMenu.DisplayMember = "Nombre";
                cboMenu.ValueMember = "MenuId";
            }

            // Combos
            DataTable dtCombo = _dao.ObtenerCombos(out error);
            if (dtCombo != null)
            {
                DataRow row = dtCombo.NewRow();
                row["ComboId"] = DBNull.Value;
                row["Nombre"] = "(Ninguno)";
                dtCombo.Rows.InsertAt(row, 0);

                cboCombo.DataSource = dtCombo;
                cboCombo.DisplayMember = "Nombre";
                cboCombo.ValueMember = "ComboId";
            }

            // Estados
            DataTable dtEst = _dao.ObtenerEstadosDescuento(out error);
            if (dtEst != null)
            {
                cboEstado.DataSource = dtEst;
                cboEstado.DisplayMember = "Estado";
                cboEstado.ValueMember = "Id";
            }
        }

        private void CargarGrilla(string buscar = "")
        {
            string error;
            if (string.IsNullOrWhiteSpace(buscar))
                _lista = _dao.ObtenerTodos(out error);
            else
                _lista = _dao.Buscar(buscar, out error);

            if (_lista == null)
            {
                MessageBox.Show(error, "Error");
                return;
            }

            dgvDescuentos.DataSource = null;
            dgvDescuentos.AutoGenerateColumns = true;
            dgvDescuentos.DataSource = _lista;

            // Ocultar columnas internas
            if (dgvDescuentos.Columns["DescuentoId"] != null) dgvDescuentos.Columns["DescuentoId"].Visible = false;
            if (dgvDescuentos.Columns["TipoDescuentoId"] != null) dgvDescuentos.Columns["TipoDescuentoId"].Visible = false;
            if (dgvDescuentos.Columns["MenuId"] != null) dgvDescuentos.Columns["MenuId"].Visible = false;
            if (dgvDescuentos.Columns["ComboId"] != null) dgvDescuentos.Columns["ComboId"].Visible = false;
            if (dgvDescuentos.Columns["EstadoId"] != null) dgvDescuentos.Columns["EstadoId"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPorcentaje.Clear();
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today.AddMonths(1);
            if (cboTipoDescuento.Items.Count > 0) cboTipoDescuento.SelectedIndex = 0;
            if (cboMenu.Items.Count > 0) cboMenu.SelectedIndex = 0;
            if (cboCombo.Items.Count > 0) cboCombo.SelectedIndex = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
        }

        private void ModoFormulario(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtPorcentaje.Enabled = habilitar;
            dtpDesde.Enabled = habilitar;
            dtpHasta.Enabled = habilitar;
            cboTipoDescuento.Enabled = habilitar;
            cboMenu.Enabled = habilitar;
            cboCombo.Enabled = habilitar;
            cboEstado.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _idActual = 0;
            LimpiarCampos();
            ModoFormulario(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDescuentos.SelectedRows.Count == 0) return;
            Descuento d = dgvDescuentos.SelectedRows[0].DataBoundItem as Descuento;
            if (d == null) return;

            _idActual = d.DescuentoId;
            txtNombre.Text = d.Nombre;
            txtPorcentaje.Text = d.Porcentaje.ToString();
            dtpDesde.Value = d.FechaDesde;
            dtpHasta.Value = d.FechaHasta;
            cboTipoDescuento.SelectedValue = d.TipoDescuentoId.HasValue ? (object)d.TipoDescuentoId.Value : DBNull.Value;
            cboMenu.SelectedValue = d.MenuId.HasValue ? (object)d.MenuId.Value : DBNull.Value;
            cboCombo.SelectedValue = d.ComboId.HasValue ? (object)d.ComboId.Value : DBNull.Value;
            cboEstado.SelectedValue = d.EstadoId;

            _modoEdicion = true;
            ModoFormulario(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Descuento d = new Descuento
            {
                Nombre = txtNombre.Text.Trim(),
                Porcentaje = decimal.Parse(txtPorcentaje.Text.Trim()),
                FechaDesde = dtpDesde.Value,
                FechaHasta = dtpHasta.Value,
                EstadoId = (int)cboEstado.SelectedValue
            };

            if (cboTipoDescuento.SelectedValue != null && cboTipoDescuento.SelectedValue != DBNull.Value)
                d.TipoDescuentoId = (int)cboTipoDescuento.SelectedValue;
            if (cboMenu.SelectedValue != null && cboMenu.SelectedValue != DBNull.Value)
                d.MenuId = (int)cboMenu.SelectedValue;
            if (cboCombo.SelectedValue != null && cboCombo.SelectedValue != DBNull.Value)
                d.ComboId = (int)cboCombo.SelectedValue;

            string error;
            if (!_modoEdicion)
                _dao.Guardar(d, out error);
            else
            {
                d.DescuentoId = _idActual;
                _dao.Actualizar(d, out error);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Error");
                return;
            }

            MessageBox.Show("Descuento guardado exitosamente.", "Éxito");
            CargarGrilla();
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDescuentos.SelectedRows.Count == 0) return;
            Descuento d = dgvDescuentos.SelectedRows[0].DataBoundItem as Descuento;
            if (MessageBox.Show($"¿Desactivar el descuento '{d.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            string error;
            _dao.EliminarLogico(d.DescuentoId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Error");
                return;
            }

            CargarGrilla();
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ModoFormulario(false);
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return false;
            }
            if (!decimal.TryParse(txtPorcentaje.Text, out decimal p) || p <= 0 || p > 100)
            {
                MessageBox.Show("Porcentaje inválido (debe ser entre 0.01 y 100).");
                return false;
            }
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta.");
                return false;
            }
            return true;
        }

        // Eventos vacíos (no eliminar)
        private void btnBuscar_Click(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();
            if (string.IsNullOrEmpty(texto))
            {
                CargarGrilla();
                return;
            }

            string error;
            List<Descuento> resultados = _dao.Buscar(texto, out error);
            if (resultados != null)
            {
                dgvDescuentos.DataSource = null;
                dgvDescuentos.AutoGenerateColumns = true;
                dgvDescuentos.DataSource = resultados;
                if (dgvDescuentos.Columns["DescuentoId"] != null) dgvDescuentos.Columns["DescuentoId"].Visible = false;
                if (dgvDescuentos.Columns["EstadoId"] != null) dgvDescuentos.Columns["EstadoId"].Visible = false;
            }
        }
    }
}