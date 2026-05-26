using DAO;
using Modelos;
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
            Usuario usuario = credencialesValidas();
            if (usuario != null)
            {
                this.Hide();
                AbrirMenuSegunRol(usuario);
            }
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
            switch (usuario.Rol.ToUpper())
            {
                case "ADMINISTRADOR":
                    // TODO: reemplazar por -> new MenuAdministrador(usuario)
                    MessageBox.Show("Bienvenido Administrador: " + usuario.User,
                                    "Acceso concedido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Show();
                    break;

                case "CAJERO":
                    // TODO: reemplazar por -> new MenuCajero(usuario)
                    MessageBox.Show("Bienvenido Cajero: " + usuario.User,
                                    "Acceso concedido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Show();
                    break;

                case "COCINERO":
                    // TODO: reemplazar por -> new MenuCocinero(usuario)
                    MessageBox.Show("Bienvenido Cocinero: " + usuario.User,
                                    "Acceso concedido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Show();
                    break;

                case "REPARTIDOR":
                    // TODO: reemplazar por -> new MenuRepartidor(usuario)
                    MessageBox.Show("Bienvenido Repartidor: " + usuario.User,
                                    "Acceso concedido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Show();
                    break;

                case "BODEGUERO":
                    // TODO: reemplazar por -> new MenuBodeguero(usuario)
                    MessageBox.Show("Bienvenido Bodeguero: " + usuario.User,
                                    "Acceso concedido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Show();
                    break;

                default:
                    MessageBox.Show("Rol no reconocido: " + usuario.Rol,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    this.Show();
                    break;
            }
        }
    }
}