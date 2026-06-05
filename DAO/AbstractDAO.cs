using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public abstract class AbstractDAO<T>
    {
        protected Conexion _conexion;

        protected AbstractDAO()
        {
            _conexion = new Conexion();
        }

        public abstract List<T> ObtenerTodos(out string pError);
        public abstract T ObtenerPorId(int id, out string pError);
        public abstract T ObtenerPorId(string id, out string pError);
        public abstract void GuardarRegistro(T reg, out string pError);
        public abstract void ActualizarRegistro(T reg, out string pError);

        
        // Ejecuta un Stored Procedure que devuelve filas y las carga en un DataTable
        protected DataTable ObtenerTabla(string storedProcedure, SqlParameter[] parameters, out string pError)
        {
            DataTable dt = new DataTable();
            pError = string.Empty;

            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null)
                return null;

            try
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                pError = ex.Message;
                return null;
            }
            finally
            {
                _conexion.CerrarConexion(out string cerrarError);
            }

            return dt;
        }

        // Ejecuta un Stored Procedure que no devuelve filas (INSERT/UPDATE/DELETE).
        protected int EjecutarComando(string storedProcedure, SqlParameter[] parameters, out string pError)
        {
            pError = string.Empty;
            int filasAfectadas = 0;

            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null)
                return -1;

            try
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    filasAfectadas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                pError = ex.Message;
                return -1;
            }
            finally
            {
                _conexion.CerrarConexion(out string cerrarError);
            }

            return filasAfectadas;
        }

        // Ejecuta un Stored Procedure que devuelve un único valor escalar
        protected object ObtenerValorUnico(string storedProcedure, SqlParameter[] parameters, out string pError)
        {
            pError = string.Empty;
            object resultado = null;

            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null)
                return null;

            try
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    resultado = cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                pError = ex.Message;
                return null;
            }
            finally
            {
                _conexion.CerrarConexion(out string cerrarError);
            }

            return resultado;
        }

        /// Eliminación lógica genérica. Debe ser sobrescrito en cada DAO concreto.
        public virtual void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            throw new NotImplementedException("EliminarLogico no implementado en la clase base. Sobrescribir en DAO concreto.");
        }
    }
}