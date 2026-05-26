using DAO;
using Modelos;
using SistemaInventarioWF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUSTO_Sistema
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            Form formularioMenu = new InterfazPrincipal_Admin();
            formularioMenu.Show();
            this.Hide();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Usuario credencialesValidas()
        {
            if (string.IsNullOrEmpty(txt_user.Text))
            {
                MessageBox.Show("Debe ingresar el usuario",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return null;
            }

            if (string.IsNullOrEmpty(txt_pass.Text))
            {
                MessageBox.Show("Debe ingresar la clave",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return null;
            }

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario usuario = usuarioDAO.ObtenerPorId(txt_user.Text, out string msjError);

            if (usuario == null)
            {
                MessageBox.Show(string.IsNullOrEmpty(msjError) ? "No fue posible validar el usuario." : msjError,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return null;
            }

            // Comparacion en texto plano (sin MD5)
            if (!usuario.Clave.Equals(txt_pass.Text))
            {
                MessageBox.Show("Credenciales no validas",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return null;
            }

            return usuario;
        }

        private void AbrirMenuSegunRol(Usuario usuario)
        {
            Form formularioMenu = null;

            switch (usuario.Rol.ToUpper())
            {
                case "ADMINISTRADOR":
                    MessageBox.Show("Bienvenido Administrador: " + usuario.User,
                                    "Acceso concedido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    formularioMenu = new InterfazPrincipal_Admin();
                    break;

                case "CAJERO":
                    MessageBox.Show("Bienvenido Cajero: " + usuario.User,
                                    "Acceso concedido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    // Temporalmente redirige a Admin por pruebas
                    formularioMenu = new InterfazPrincipal_Admin();
                    break;

                case "COCINERO":
                    MessageBox.Show("Bienvenido Cocinero: " + usuario.User,
                                    "Acceso concedido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    // Temporalmente redirige a Admin por pruebas
                    formularioMenu = new InterfazPrincipal_Admin();
                    break;

                case "REPARTIDOR":
                    MessageBox.Show("Bienvenido Repartidor: " + usuario.User,
                                    "Acceso concedido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    // Temporalmente redirige a Admin por pruebas
                    formularioMenu = new InterfazPrincipal_Admin();
                    break;

                case "BODEGUERO":
                    MessageBox.Show("Bienvenido Bodeguero: " + usuario.User,
                                    "Acceso concedido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    // Temporalmente redirige a Admin por pruebas
                    formularioMenu = new InterfazPrincipal_Admin();
                    break;

                default:
                    MessageBox.Show("Rol no reconocido: " + usuario.Rol,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    this.Show();
                    return;
            }

            // Enlaza el cierre del menú para finalizar por completo el proceso de la aplicación
            if (formularioMenu != null)
            {
                formularioMenu.FormClosed += (sender, args) => Application.Exit();
                formularioMenu.Show();
            }
        }

        private void usuario_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}