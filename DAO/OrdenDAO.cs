using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class OrdenDAO
    {
        private Conexion _conexion;

        public OrdenDAO()
        {
            _conexion = new Conexion();
        }

        // Clientes activos
        public DataTable ObtenerClientesActivos(out string pError)
        {
            return EjecutarReader(@"
                SELECT ClienteId, (Nombre + ' ' + Apellido) AS NombreCompleto 
                FROM VENTA.CLIENTE 
                WHERE EstadoId = (SELECT EstadoId FROM GLOBAL.ESTADO WHERE Estado = 'ACTIVO' 
                  AND EntidadId = (SELECT EntidadId FROM GLOBAL.ENTIDAD WHERE Entidad = 'CLIENTE'))
                ORDER BY Nombre, Apellido", null, out pError);
        }

        // Tipos de orden
        public DataTable ObtenerTiposOrden(out string pError)
        {
            return EjecutarReader("SELECT TipoOrdenId AS Id, TipoOrden FROM VENTA.TIPO_ORDEN ORDER BY TipoOrden", null, out pError);
        }

        // Menús activos
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

        // Combos activos
        public DataTable ObtenerCombosActivos(out string pError)
        {
            DataTable dt = EjecutarReader("VENTA.SpSelectAllCombo", null, out pError);
            if (dt != null)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = "EstadoNombre = 'DISPONIBLE'";
                return dv.ToTable();
            }
            return null;
        }

        public DataTable ObtenerDescuentosActivos(out string pError)
        {
            DataTable dt = EjecutarReader("VENTA.SpSelectDescuento", new SqlParameter[] { new SqlParameter("@Buscar", "") }, out pError);
            if (dt != null)
            {
                DataTable resultado = dt.Clone();
                foreach (DataRow row in dt.Rows)
                {
                    // Solo descuentos activos y vigentes hoy
                    if (row["EstadoNombre"].ToString() == "ACTIVO" &&
                        Convert.ToDateTime(row["FechaDesde"]) <= DateTime.Today &&
                        Convert.ToDateTime(row["FechaHasta"]) >= DateTime.Today)
                    {
                        resultado.ImportRow(row);
                    }
                }
                return resultado;
            }
            return null;
        }

        // Registrar orden completa
        public int RegistrarOrden(int clienteId, int tipoOrdenId, int? descuentoId, int estadoId,
                                  List<DetalleOrdenItem> detalles, out string pError)
        {
            pError = string.Empty;
            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null) return 0;

            SqlTransaction transaction = null;
            try
            {
                transaction = conn.BeginTransaction();

                DataTable dtDetalle = new DataTable();
                dtDetalle.Columns.Add("MenuId", typeof(int));
                dtDetalle.Columns.Add("ComboId", typeof(int));
                dtDetalle.Columns.Add("PrecioUnitario", typeof(decimal));
                dtDetalle.Columns.Add("Cantidad", typeof(int));

                foreach (var det in detalles)
                {
                    dtDetalle.Rows.Add(
                        det.MenuId.HasValue ? (object)det.MenuId.Value : DBNull.Value,
                        det.ComboId.HasValue ? (object)det.ComboId.Value : DBNull.Value,
                        det.PrecioConDescuento,  // Precio con descuento aplicado
                        det.Cantidad
                    );
                }

                using (SqlCommand cmd = new SqlCommand("VENTA.SpRegistrarOrdenCompleta", conn, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                    cmd.Parameters.AddWithValue("@TipoOrdenId", tipoOrdenId);
                    cmd.Parameters.AddWithValue("@DescuentoId", (object)descuentoId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EstadoId", estadoId);
                    cmd.Parameters.AddWithValue("@UsuarioRegistroId", SesionActual.UsuarioId);
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalle", dtDetalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "VENTA.DetalleOrdenType";

                    int ordenId = Convert.ToInt32(cmd.ExecuteScalar());
                    transaction.Commit();
                    return ordenId;
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                pError = ex.Message;
                return 0;
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
                    if (consulta.StartsWith("VENTA.") || consulta.StartsWith("GLOBAL.") || consulta.StartsWith("COMPRA."))
                        cmd.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                pError = ex.Message;
                return null;
            }
            finally
            {
                _conexion.CerrarConexion(out _);
            }
            return dt;
        }
    }
}