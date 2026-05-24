using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UsuarioDAO : AbstractDAO<Usuario>
    {
        public override void ActualizarRegistro(Usuario reg, out string pError)
        {
            throw new NotImplementedException();
        }

        public override void GuardarRegistro(Usuario reg, out string pError)
        {
            throw new NotImplementedException();
        }

        public override Usuario ObtenerPorId(int id, out string pError)
        {
            throw new NotImplementedException();
        }

        public override Usuario ObtenerPorId(string id, out string pError)
        {
            pError = string.Empty;
            Conexion conn = new Conexion();
            SqlCommand cmd;
            SqlDataReader dr;
            Usuario usuario = null;

            string cmdStr = "SELECT usuario, clave, idEmpleado, idRol " +
                            "FROM Usuario " +
                            "WHERE estado = 'A' " +
                            "AND usuario = '" + id + "'";
            try
            {
                conn.AbrirConexion(out pError);
                if (!string.IsNullOrEmpty(pError)) //problema al abrir conexion
                {
                    throw new Exception(pError);
                }

                cmd = new SqlCommand(cmdStr, conn.conn);
                dr = cmd.ExecuteReader();                
                while (dr.Read()) 
                {
                    usuario = new Usuario();
                    usuario.User = dr.GetString(0);
                    usuario.Clave = dr.GetString(1);
                    usuario.IdEmpleado = dr.GetInt32(2);
                    usuario.IdRol = dr.GetInt32(3);
                }
                if (usuario == null) 
                {
                    pError = "El usuario no existe";
                }

                dr.Close();
                conn.CerrarConexion(out pError);
                if (!string.IsNullOrEmpty(pError)) //problema al cerrar conexion
                {
                    throw new Exception(pError);
                }
            }
            catch (SqlException ex)
            {
                pError = ex.Message;
                Console.WriteLine(pError);
            }
            catch (Exception ex) 
            {
                if (string.IsNullOrEmpty(pError))
                {
                   pError = ex.Message;
                }
                Console.WriteLine(pError);
            }

            return usuario;

        }

        public override List<Usuario> ObtenerTodos(out string pError)
        {
            throw new NotImplementedException();
        }
    }
}
