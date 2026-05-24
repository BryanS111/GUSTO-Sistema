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
            if (credencialesValidas()) 
            {
                MessageBox.Show("Acceso concedido",
                                "Mensaje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool credencialesValidas() 
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            if (string.IsNullOrEmpty(txt_user.Text)) 
            {
                MessageBox.Show("Debe ingresar el usuario",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txt_pass.Text))
            {
                MessageBox.Show("Debe ingresar la clave",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            Usuario usuario = usuarioDAO.ObtenerPorId(txt_user.Text, out string msjError);

            if (usuario == null && !string.IsNullOrEmpty(msjError)) 
            {
                MessageBox.Show(msjError, 
                                "Error",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
                return false;
            }
            
            string claveEnc = Utils.GenerateMD5Hash(txt_pass.Text);

            if (!usuario.Clave.ToLower().Equals(claveEnc.ToLower())) 
            {
                MessageBox.Show("Credenciales no validas",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            return true;

        }
    }
}
