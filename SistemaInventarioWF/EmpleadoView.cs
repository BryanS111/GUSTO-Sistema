using DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaInventarioWF
{
    public partial class EmpleadoView : Form
    {
        private InterfazPrincipal_Admin _abuelo;
        private EmpleadoDAO _empleadoDAO;
        private List<Empleado> _listaEmpleados;
        private bool _modoEdicion; // true = editando empleado existente
        private int _empleadoIdActual; // ID del empleado en edición


        public EmpleadoView(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            _abuelo = abuelo;
            _empleadoDAO = new EmpleadoDAO();
            _modoEdicion = false;
            _empleadoIdActual = 0;
        }

        //CARGA INICIAL
        private void EmpleadoView_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarGrilla(string.Empty);
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void button4_Click_1(object sender, EventArgs e) // BOTON DE CIERRE PARA VOLVER AL PANEL DE MANTENIMIENTOS
        {
            _abuelo.AbrirFormularioEnPanel(new frmMantenimientos_Menu(_abuelo));
            this.Close();
        }

        // BOTONES CRUD 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _empleadoIdActual = 0;
            LimpiarCampos();
            ModoFormulario(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatosIngresados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para editar.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Empleado empSeleccionado = (Empleado)dgvDatosIngresados.SelectedRows[0].DataBoundItem;

            _empleadoIdActual = empSeleccionado.EmpleadoId;
            txtNombre.Text = empSeleccionado.Nombre;
            txtApellido.Text = empSeleccionado.Apellido;
            txtTelefono.Text = empSeleccionado.Telefono;
            txtEmail.Text = empSeleccionado.Email;
            txtDireccion.Text = empSeleccionado.Direccion;
            dtpFechaNac.Value = empSeleccionado.FechaNac;
            dtpFechaContratacion.Value = empSeleccionado.FechaContratacion;
            cbxCargo.SelectedValue = empSeleccionado.CargoId;
            cboEstado.SelectedValue = empSeleccionado.EstadoId;

            _modoEdicion = true;
            ModoFormulario(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbxCargo.SelectedValue == null || cboEstado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un Cargo y un Estado válidos.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Empleado emp = new Empleado
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                FechaNac = dtpFechaNac.Value,
                FechaContratacion = dtpFechaContratacion.Value,
                CargoId = (int)cbxCargo.SelectedValue,
                EstadoId = (int)cboEstado.SelectedValue
            };

            string error;
            if (!_modoEdicion)
            {
                emp.UsuarioRegistroId = ObtenerUsuarioActualId();
                _empleadoDAO.GuardarRegistro(emp, out error);
            }
            else
            {
                emp.EmpleadoId = _empleadoIdActual;
                emp.UsuarioModificacionId = ObtenerUsuarioActualId();
                _empleadoDAO.ActualizarRegistro(emp, out error);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al guardar: {error}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Empleado guardado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatosIngresados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para eliminar.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Empleado empSeleccionado = (Empleado)dgvDatosIngresados.SelectedRows[0].DataBoundItem;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de desactivar al empleado {empSeleccionado.NombreCompleto}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            // Cambiar estado a inactivo y asignar usuario que modifica
            empSeleccionado.EstadoId = 2; // Inactivo
            empSeleccionado.UsuarioModificacionId = SesionActual.UsuarioId;

            string error;
            _empleadoDAO.ActualizarRegistro(empSeleccionado, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al eliminar: {error}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Empleado desactivado.", "Éxito",
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

        // ──── MÉTODOS AUXILIARES ────
        private void CargarCombos()
        {
            string error;

            // Cargar combo de Cargos desde BD
            DataTable dtCargos = _empleadoDAO.ObtenerCargos(out error);
            if (dtCargos != null)
            {
                cbxCargo.DataSource = dtCargos;
                cbxCargo.DisplayMember = "Cargo";
                cbxCargo.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show($"Error al cargar cargos: {error}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Cargar combo de Estados desde BD (filtrando por entidad EMPLEADO)
            DataTable dtEstados = _empleadoDAO.ObtenerEstadosPorEntidad("EMPLEADO", out error);
            if (dtEstados != null)
            {
                cboEstado.DataSource = dtEstados;
                cboEstado.DisplayMember = "Estado";
                cboEstado.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show($"Error al cargar estados: {error}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla(string buscar)
        {
            string error;
            if (string.IsNullOrWhiteSpace(buscar))
                _listaEmpleados = _empleadoDAO.ObtenerTodos(out error);
            else
                _listaEmpleados = _empleadoDAO.Buscar(buscar, out error);

            if (_listaEmpleados == null)
            {
                MessageBox.Show($"Error al cargar empleados: {error}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvDatosIngresados.DataSource = null;
            dgvDatosIngresados.AutoGenerateColumns = true;
            dgvDatosIngresados.DataSource = _listaEmpleados;

            dgvDatosIngresados.Columns["CargoId"].Visible = false;
            dgvDatosIngresados.Columns["EstadoId"].Visible = false;
            dgvDatosIngresados.Columns["UsuarioRegistroId"].Visible = false;
            dgvDatosIngresados.Columns["UsuarioModificacionId"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            dtpFechaNac.Value = DateTime.Today;
            dtpFechaContratacion.Value = DateTime.Today;
            if (cbxCargo.Items.Count > 0) cbxCargo.SelectedIndex = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }
            return true;
        }

        private int ObtenerUsuarioActualId()
        {
            return Modelos.SesionActual.UsuarioId;
        }

        //EVENTOS SIN LÓGICA (los dejamos como están) 
        private void label8_Click(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtApellido_TextChanged(object sender, EventArgs e) { }
        private void txtTelefono_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtDireccion_TextChanged(object sender, EventArgs e) { }
        private void dtpFechaContratacion_ValueChanged(object sender, EventArgs e) { }
        private void cbxCargo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvDatosIngresados_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}