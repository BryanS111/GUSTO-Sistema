using DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class RepartidoresView : Form
    {
        private InterfazPrincipal_Admin _abuelo;
        private RepartidorDAO _repartidorDAO;
        private EmpleadoDAO _empleadoDAO;
        private List<Repartidor> _listaRepartidores;
        private bool _modoEdicion;
        private int _repartidorIdActual;
        private int _empleadoIdSeleccionado;

        public RepartidoresView(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            _abuelo = abuelo;
            _repartidorDAO = new RepartidorDAO();
            _empleadoDAO = new EmpleadoDAO();
            _modoEdicion = false;
            _repartidorIdActual = 0;
            _empleadoIdSeleccionado = 0;
            this.Load += new EventHandler(RepartidoresView_Load);

            // Reemplazar el evento de selección de empleado
            this.dgvEmpleados.CellContentClick -= dgvEmpleado_CellContentClick;
            this.dgvEmpleados.SelectionChanged += dgvEmpleados_SelectionChanged;
        }

        private void RepartidoresView_Load(object sender, EventArgs e)
        {
            CargarComboEstado();
            CargarGrilla();
            LimpiarCampos();
            ModoFormulario(false);
        }

        // Botón cerrar (X)
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new frmMantenimientos_Menu(_abuelo));
            this.Close();
        }

        // Buscador dinámico de empleados
        private void txtBuscarEmpleado_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarEmpleado.Text.Trim();
            if (string.IsNullOrEmpty(filtro))
            {
                dgvEmpleados.DataSource = null;
                return;
            }

            string error;
            List<Empleado> empleados = _empleadoDAO.Buscar(filtro, out error);
            if (empleados == null)
            {
                MessageBox.Show($"Error al buscar empleados: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvEmpleados.DataSource = null;
            dgvEmpleados.AutoGenerateColumns = true;
            dgvEmpleados.DataSource = empleados;
        }

        // Selección de empleado en la grilla
        private void dgvEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No se usa, se reemplazó por SelectionChanged
        }

        // Búsqueda general de repartidores
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text.Trim());
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0) return;
            Empleado emp = (Empleado)dgvEmpleados.SelectedRows[0].DataBoundItem;
            _empleadoIdSeleccionado = emp.EmpleadoId;
            MessageBox.Show($"Empleado seleccionado: {emp.NombreCompleto} (ID: {emp.EmpleadoId})",
                "Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _repartidorIdActual = 0;
            _empleadoIdSeleccionado = 0;
            LimpiarCampos();
            ModoFormulario(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRepartidores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un repartidor para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Repartidor rep = (Repartidor)dgvRepartidores.SelectedRows[0].DataBoundItem;
            _repartidorIdActual = rep.RepartidorId;
            _empleadoIdSeleccionado = rep.EmpleadoId;
            txtPlaca.Text = rep.NoPlacaMoto;
            cboEstado.SelectedValue = rep.EstadoId;
            txtBuscarEmpleado.Text = rep.EmpleadoNombre;

            string error;
            List<Empleado> emp = _empleadoDAO.Buscar(rep.EmpleadoId.ToString(), out error);
            dgvEmpleados.DataSource = null;
            dgvEmpleados.AutoGenerateColumns = true;
            dgvEmpleados.DataSource = emp;

            _modoEdicion = true;
            ModoFormulario(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            if (_empleadoIdSeleccionado == 0)
            {
                MessageBox.Show("Debe seleccionar un empleado del buscador.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboEstado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un estado.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Repartidor rep = new Repartidor
            {
                EmpleadoId = _empleadoIdSeleccionado,
                NoPlacaMoto = txtPlaca.Text.Trim(),
                EstadoId = (int)cboEstado.SelectedValue
            };

            string error;
            if (!_modoEdicion)
            {
                _repartidorDAO.GuardarRegistro(rep, out error);
            }
            else
            {
                rep.RepartidorId = _repartidorIdActual;
                _repartidorDAO.ActualizarRegistro(rep, out error);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al guardar: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Repartidor guardado exitosamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRepartidores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un repartidor para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Repartidor rep = (Repartidor)dgvRepartidores.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Desactivar al repartidor {rep.EmpleadoNombre}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string error;
            _repartidorDAO.EliminarLogico(rep.RepartidorId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al eliminar: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Repartidor desactivado.", "Éxito",
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
        private void CargarComboEstado()
        {
            string error;
            DataTable dt = _repartidorDAO.ObtenerEstadosRepartidor(out error);
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
                _listaRepartidores = _repartidorDAO.ObtenerTodos(out error);
            else
                _listaRepartidores = _repartidorDAO.Buscar(buscar, out error);

            if (_listaRepartidores == null)
            {
                MessageBox.Show($"Error al cargar repartidores: {error}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvRepartidores.DataSource = null;
            dgvRepartidores.AutoGenerateColumns = true;
            dgvRepartidores.DataSource = _listaRepartidores;

            if (dgvRepartidores.Columns["RepartidorId"] != null)
                dgvRepartidores.Columns["RepartidorId"].Visible = false;
            if (dgvRepartidores.Columns["EmpleadoId"] != null)
                dgvRepartidores.Columns["EmpleadoId"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtPlaca.Clear();
            txtBuscarEmpleado.Clear();
            dgvEmpleados.DataSource = null;
            _empleadoIdSeleccionado = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
        }

        private void ModoFormulario(bool habilitar)
        {
            grpBoxData.Enabled = habilitar;
            txtPlaca.Enabled = habilitar;
            txtBuscarEmpleado.Enabled = habilitar;
            cboEstado.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MessageBox.Show("La placa de moto es obligatoria.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlaca.Focus();
                return false;
            }
            return true;
        }

        // Eventos vacíos requeridos (no eliminar)
        private void txtBuscar_TextChanged(object sender, EventArgs e) { }
        private void txtNoPlaca_TextChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvRepartidor_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}