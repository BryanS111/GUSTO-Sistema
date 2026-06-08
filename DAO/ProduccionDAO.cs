using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class ProduccionDAO
    {
        private Conexion _conexion;

        public ProduccionDAO()
        {
            _conexion = new Conexion();
        }

        // Cargar empleados (solo cocineros)
        public DataTable ObtenerCocineros(out string pError)
        {
            string consulta = @"
                SELECT e.EmpleadoId, 
                       e.Nombre + ' ' + e.Apellido AS NombreCompleto,
                       'Empleado: ' + CAST(e.EmpleadoId AS VARCHAR) + ' - ' + e.Nombre + ' ' + e.Apellido + ' - ' + c.Cargo AS DisplayText
                FROM RRHH.EMPLEADO e
                INNER JOIN RRHH.CARGO c ON e.CargoId = c.CargoId
                WHERE UPPER(c.Cargo) = 'COCINERO'
                ORDER BY e.Nombre, e.Apellido";
            return EjecutarReader(consulta, null, out pError);
        }

        // Cargar inventario disponible
        public DataTable ObtenerInventario(out string pError)
        {
            return EjecutarReader("COMPRA.SpSelectAllInventario", null, out pError);
        }

        // Cargar menús activos para producto final
        public DataTable ObtenerMenusActivos(out string pError)
        {
            DataTable dt = EjecutarReader("VENTA.SpSelectAllMenu", null, out pError);
            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "EstadoNombre = 'DISPONIBLE'";
                return dv.ToTable();
            }
            return null;
        }

        // Generar siguiente número de orden
        public string ObtenerSiguienteNoOrden(out string pError)
        {
            pError = string.Empty;
            DataTable dt = EjecutarReader("SELECT TOP 1 NoOrdenProduccion FROM BODEGA.ORDEN_PRODUCCION ORDER BY OrdenProduccionId DESC", null, out pError);
            if (dt == null || dt.Rows.Count == 0)
                return "OP-001";

            string ultimo = dt.Rows[0]["NoOrdenProduccion"].ToString();
            int idx = ultimo.LastIndexOf('-');
            if (idx >= 0 && int.TryParse(ultimo.Substring(idx + 1), out int n))
                return ultimo.Substring(0, idx + 1) + (n + 1).ToString("D3");
            return "OP-001";
        }

        // Registrar producción y descontar inventario
        public void RegistrarProduccion(string noOrden, DateTime fecha, int empleadoId, int usuarioRegistroId,
                                        string productoFinal, int? cantidadProducto, List<DetalleProduccionItem> detalle, out string pError)
        {
            pError = string.Empty;
            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null) return;

            SqlTransaction transaction = null;
            try
            {
                transaction = conn.BeginTransaction();

                DataTable dtDetalle = new DataTable();
                dtDetalle.Columns.Add("InventarioId", typeof(int));
                dtDetalle.Columns.Add("Cantidad", typeof(double));
                foreach (var d in detalle)
                    dtDetalle.Rows.Add(d.InventarioId, d.Cantidad);

                using (SqlCommand cmd = new SqlCommand("BODEGA.SpRegistrarProduccion", conn, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NoOrdenProduccion", noOrden);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@EmpleadoId", empleadoId);
                    cmd.Parameters.AddWithValue("@UsuarioRegistroId", usuarioRegistroId);
                    cmd.Parameters.AddWithValue("@ProductoFinal", (object)productoFinal ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CantidadProducto", (object)cantidadProducto ?? DBNull.Value);
                    SqlParameter tvp = cmd.Parameters.AddWithValue("@Detalle", dtDetalle);
                    tvp.SqlDbType = SqlDbType.Structured;
                    tvp.TypeName = "BODEGA.DetalleProduccionType";

                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                pError = ex.Message;
            }
            finally
            {
                _conexion.CerrarConexion(out _);
            }
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
                    cmd.CommandType = CommandType.Text;
                    if (consulta.StartsWith("RRHH.") || consulta.StartsWith("COMPRA.") || consulta.StartsWith("VENTA.") || consulta.StartsWith("BODEGA."))
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