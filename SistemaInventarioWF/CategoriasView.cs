using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DAO;
using Modelos;

namespace SistemaInventarioWF
{
    public partial class CategoriasView : Form
    {
        private CategoriaDAO _categoriaDAO;
        private List<Categoria> _listaCategorias;
        private bool _modoEdicion;
        private int _categoriaIdActual;

        public CategoriasView()
        {
            InitializeComponent();
            _categoriaDAO = new CategoriaDAO();
            _modoEdicion = false;
            _categoriaIdActual = 0;
            this.Load += new EventHandler(CategoriasView_Load);
        }

        private void CategoriasView_Load(object sender, EventArgs e)
        {
            CargarComboEstado();
            CargarGrilla();
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _categoriaIdActual = 0;
            LimpiarCampos();
            ModoFormulario(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Categoria catSeleccionada = (Categoria)dgvCategorias.SelectedRows[0].DataBoundItem;

            _categoriaIdActual = catSeleccionada.CategoriaId;
            txtNombreCategoria.Text = catSeleccionada.Nombre;
            cbxEstado.SelectedValue = catSeleccionada.EstadoId;

            _modoEdicion = true;
            ModoFormulario(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            if (cbxEstado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un estado válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Categoria cat = new Categoria
            {
                Nombre = txtNombreCategoria.Text.Trim(),
                EstadoId = (int)cbxEstado.SelectedValue
            };

            string error;
            if (!_modoEdicion)
            {
                _categoriaDAO.GuardarRegistro(cat, out error);
            }
            else
            {
                cat.CategoriaId = _categoriaIdActual;
                _categoriaDAO.ActualizarRegistro(cat, out error);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al guardar: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Categoría guardada exitosamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Categoria catSeleccionada = (Categoria)dgvCategorias.SelectedRows[0].DataBoundItem;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de desactivar la categoría '{catSeleccionada.Nombre}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            string error;
            _categoriaDAO.EliminarLogico(catSeleccionada.CategoriaId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al eliminar: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Categoría desactivada.", "Éxito",
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

        // Eventos que no usan lógica pero deben existir
        private void txtNombreCategoria_TextChanged(object sender, EventArgs e) { }
        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e) { }

        // Métodos privados
        private void CargarComboEstado()
        {
            string error;
            DataTable dtEstados = _categoriaDAO.ObtenerEstadosCategoria(out error);
            if (dtEstados != null)
            {
                cbxEstado.DataSource = dtEstados;
                cbxEstado.DisplayMember = "Estado";
                cbxEstado.ValueMember = "Id";
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
            _listaCategorias = _categoriaDAO.ObtenerTodos(out error);
            if (_listaCategorias == null)
            {
                MessageBox.Show($"Error al cargar categorías: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                _listaCategorias = _listaCategorias.FindAll(c =>
                    c.Nombre.IndexOf(buscar, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            dgvCategorias.DataSource = null;
            dgvCategorias.AutoGenerateColumns = true;
            dgvCategorias.DataSource = _listaCategorias;

            if (dgvCategorias.Columns["CategoriaId"] != null)
                dgvCategorias.Columns["CategoriaId"].Visible = false;
            if (dgvCategorias.Columns["EstadoId"] != null)
                dgvCategorias.Columns["EstadoId"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtNombreCategoria.Clear();
            if (cbxEstado.Items.Count > 0) cbxEstado.SelectedIndex = 0;
        }

        private void ModoFormulario(bool habilitar)
        {
            gbxDatos.Enabled = habilitar;
            txtNombreCategoria.Enabled = habilitar;
            cbxEstado.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCategoria.Focus();
                return false;
            }
            return true;
        }
        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No se requiere lógica por ahora
        }

        private void CategoriasView_Load_1(object sender, EventArgs e)
        {

        }
    }
}