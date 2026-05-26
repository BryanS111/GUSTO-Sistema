using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            SqlConnection sqlConn = null;
            Usuario usuario = null;

            string cmdStr = @"SELECT u.UsuarioId, u.Usuario, u.Clave, u.RolId, r.Rol
                              FROM AUTENTICACION.USUARIO u
                              INNER JOIN AUTENTICACION.ROL r ON u.RolId = r.RolId
                              WHERE u.EstadoId = (
                                  SELECT EstadoId FROM GLOBAL.ESTADO
                                  WHERE Estado = 'ACTIVO'
                                  AND EntidadId = (
                                      SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'USUARIO'
                                  )
                              )
                              AND u.Usuario = @usuario";
            try
            {
                sqlConn = conn.AbrirConexion(out pError);
                if (sqlConn == null) throw new Exception(pError);

                using (SqlCommand cmd = new SqlCommand(cmdStr, sqlConn))
                {
                    cmd.Parameters.AddWithValue("@usuario", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario();
                            usuario.UsuarioId = dr.GetInt32(0);
                            usuario.User = dr.GetString(1);
                            usuario.Clave = dr.GetString(2);
                            usuario.IdRol = dr.GetInt32(3);
                            usuario.Rol = dr.GetString(4);
                        }
                    }
                }
                if (usuario == null) pError = "El usuario no existe";
            }
            catch (SqlException ex)
            {
                pError = ex.Message;
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(pError)) pError = ex.Message;
            }
            finally
            {
                conn.CerrarConexion(out string errorCerrar);
                if (string.IsNullOrEmpty(pError) && !string.IsNullOrEmpty(errorCerrar))
                    pError = errorCerrar;
            }
            return usuario;
        }

        public override List<Usuario> ObtenerTodos(out string pError)
        {
            throw new NotImplementedException();
        }
    }
}