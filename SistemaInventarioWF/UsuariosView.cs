using DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class UsuariosView : Form
    {
        private InterfazPrincipal_Admin _abuelo;
        private UsuarioDAO _usuarioDAO;
        private EmpleadoDAO _empleadoDAO;
        private List<Usuario> _listaUsuarios;
        private bool _modoEdicion;
        private int _usuarioIdActual;
        private int _empleadoIdSeleccionado;

        public UsuariosView(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            _abuelo = abuelo;
            _usuarioDAO = new UsuarioDAO();
            _empleadoDAO = new EmpleadoDAO();
            _modoEdicion = false;
            _usuarioIdActual = 0;
            _empleadoIdSeleccionado = 0;
            this.Load += new EventHandler(UsuariosView_Load);
        }

        private void UsuariosView_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarGrilla();
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new frmMantenimientos_Menu(_abuelo));
            this.Close();
        }

        // Búsqueda dinámica de empleados (ya implementada)
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
                MessageBox.Show($"Error al buscar empleados: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvEmpleados.DataSource = null;
            dgvEmpleados.AutoGenerateColumns = true;
            dgvEmpleados.DataSource = empleados;
        }
        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método vacío para permitir que el diseñador cargue.
        }

        // NUEVO: evento que se dispara al seleccionar una fila (por clic o teclado)
        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0)
                return;

            Empleado empSeleccionado = (Empleado)dgvEmpleados.SelectedRows[0].DataBoundItem;
            _empleadoIdSeleccionado = empSeleccionado.EmpleadoId;

            // Opcional: confirmación visual
            MessageBox.Show($"Empleado seleccionado: {empSeleccionado.NombreCompleto} (ID: {empSeleccionado.EmpleadoId})",
                            "Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Búsqueda de usuarios (grilla principal)
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _usuarioIdActual = 0;
            _empleadoIdSeleccionado = 0;
            LimpiarCampos();
            ModoFormulario(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usrSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;

            _usuarioIdActual = usrSeleccionado.UsuarioId;
            _empleadoIdSeleccionado = usrSeleccionado.EmpleadoId;
            txtUsuario.Text = usrSeleccionado.User;
            txtClave.Text = usrSeleccionado.Clave;
            cboRol.SelectedValue = usrSeleccionado.IdRol;
            cboEstado.SelectedValue = usrSeleccionado.EstadoId;

            // Mostrar el nombre del empleado en el buscador
            txtBuscarEmpleado.Text = usrSeleccionado.EmpleadoNombre;
            // Cargar la grilla de empleados con ese único empleado
            string error;
            List<Empleado> emp = _empleadoDAO.Buscar(usrSeleccionado.EmpleadoId.ToString(), out error);
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
                MessageBox.Show("Debe seleccionar un empleado del buscador.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboEstado.SelectedValue == null || cboRol.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un estado y un rol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usr = new Usuario
            {
                User = txtUsuario.Text.Trim(),
                Clave = txtClave.Text.Trim(),
                EmpleadoId = _empleadoIdSeleccionado,
                IdRol = (int)cboRol.SelectedValue,
                EstadoId = (int)cboEstado.SelectedValue
            };

            string error;
            if (!_modoEdicion)
            {
                _usuarioDAO.GuardarRegistro(usr, out error);
            }
            else
            {
                usr.UsuarioId = _usuarioIdActual;
                _usuarioDAO.ActualizarRegistro(usr, out error);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al guardar: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Usuario guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla(txtBuscar.Text.Trim());
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario usrSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de desactivar al usuario '{usrSeleccionado.User}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            string error;
            _usuarioDAO.EliminarLogico(usrSeleccionado.UsuarioId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show($"Error al eliminar: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Usuario desactivado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void CargarCombos()
        {
            string error;
            DataTable dtRoles = _usuarioDAO.ObtenerRoles(out error);
            if (dtRoles != null)
            {
                cboRol.DataSource = dtRoles;
                cboRol.DisplayMember = "Rol";
                cboRol.ValueMember = "Id";
            }
            else
                MessageBox.Show($"Error al cargar roles: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DataTable dtEstados = _usuarioDAO.ObtenerEstadosUsuario(out error);
            if (dtEstados != null)
            {
                cboEstado.DataSource = dtEstados;
                cboEstado.DisplayMember = "Estado";
                cboEstado.ValueMember = "Id";
            }
            else
                MessageBox.Show($"Error al cargar estados: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CargarGrilla(string buscar = "")
        {
            string error;
            if (string.IsNullOrWhiteSpace(buscar))
                _listaUsuarios = _usuarioDAO.ObtenerTodos(out error);
            else
                _listaUsuarios = _usuarioDAO.Buscar(buscar, out error);

            if (_listaUsuarios == null)
            {
                MessageBox.Show($"Error al cargar usuarios: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvUsuarios.DataSource = null;
            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.DataSource = _listaUsuarios;

            if (dgvUsuarios.Columns["UsuarioId"] != null)
                dgvUsuarios.Columns["UsuarioId"].Visible = true;
            if (dgvUsuarios.Columns["Clave"] != null)
                dgvUsuarios.Columns["Clave"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtClave.Clear();
            txtBuscarEmpleado.Clear();
            dgvEmpleados.DataSource = null;
            _empleadoIdSeleccionado = 0;
            if (cboRol.Items.Count > 0) cboRol.SelectedIndex = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
        }

        private void ModoFormulario(bool habilitar)
        {
            grpBoxData.Enabled = habilitar;
            txtUsuario.Enabled = habilitar;
            txtClave.Enabled = habilitar;
            txtBuscarEmpleado.Enabled = habilitar;
            cboRol.Enabled = habilitar;
            cboEstado.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("La clave es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return false;
            }
            return true;
        }

        // Eventos vacíos requeridos (no eliminar)
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void txtBuscar_TextChanged(object sender, EventArgs e) { }
        private void txtUsuario_TextChanged(object sender, EventArgs e) { }
        private void txtClave_TextChanged(object sender, EventArgs e) { }
        private void cboRol_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}