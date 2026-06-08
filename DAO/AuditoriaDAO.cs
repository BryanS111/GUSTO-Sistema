using System;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class AuditoriaDAO
    {
        private Conexion _conexion;

        public AuditoriaDAO()
        {
            _conexion = new Conexion();
        }

        public DataTable ObtenerHistorial(string usuario, int? accionEventoId, DateTime? fechaDesde, DateTime? fechaHasta, out string pError)
        {
            string consulta = "AUDITORIA.SpSelectHistorial";
            SqlParameter[] parametros = {
                new SqlParameter("@UsuarioBuscar", string.IsNullOrWhiteSpace(usuario) ? (object)DBNull.Value : usuario),
                new SqlParameter("@AccionEventoId", accionEventoId ?? (object)DBNull.Value),
                new SqlParameter("@FechaDesde", fechaDesde ?? (object)DBNull.Value),
                new SqlParameter("@FechaHasta", fechaHasta ?? (object)DBNull.Value)
            };
            return EjecutarReader(consulta, parametros, out pError);
        }

        public DataTable ObtenerAccionesEvento(out string pError)
        {
            return EjecutarReader("AUDITORIA.SpSelectAllAccionEvento", null, out pError);
        }

        private DataTable EjecutarReader(string consulta, SqlParameter[] parametros, out string pError)
        {
            pError = string.Empty;
            DataTable dt = new DataTable();
            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null) return null;

            try
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);
                }
            }
            catch (Exception ex) { pError = ex.Message; return null; }
            finally { _conexion.CerrarConexion(out _); }
            return dt;
        }
    }
}