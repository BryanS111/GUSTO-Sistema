using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class CompraDAO
    {
        private Conexion _conexion;

        public CompraDAO()
        {
            _conexion = new Conexion();
        }

        // Obtener todos los proveedores activos
        public DataTable ObtenerProveedoresActivos(out string pError)
        {
            DataTable dt = ObtenerTabla("COMPRA.SpSelectAllProveedores", null, out pError);
            if (dt != null)
            {
                // Ordenar por ID descendente (más reciente primero)
                DataView dv = dt.DefaultView;
                dv.Sort = "Codigo DESC";
                return dv.ToTable();
            }
            return null;
        }

        // Obtener todos los inventarios activos (DISPONIBLE)
        public DataTable ObtenerInventariosActivos(out string pError)
        {
            DataTable dt = ObtenerTabla("COMPRA.SpSelectAllInventario", null, out pError);
            if (dt != null)
            {
                // Filtrar solo disponibles
                DataView dv = dt.DefaultView;
                dv.RowFilter = "EstadoNombre = 'DISPONIBLE'";
                return dv.ToTable();
            }
            return null;
        }

        // Obtener el último número de documento
        public string ObtenerUltimoNoDocumento(out string pError)
        {
            pError = string.Empty;
            DataTable dt = ObtenerTabla("COMPRA.SpSelectAllCompras", null, out pError);
            if (dt == null) return "FAC-001";

            string ultimo = "";
            foreach (DataRow row in dt.Rows)
            {
                string numDoc = row["NoDocumento"].ToString();
                if (!string.IsNullOrEmpty(numDoc))
                {
                    // Extraer número después del guion
                    int pos = numDoc.LastIndexOf('-');
                    if (pos >= 0 && int.TryParse(numDoc.Substring(pos + 1), out int n))
                    {
                        if (n > (string.IsNullOrEmpty(ultimo) ? 0 : int.Parse(ultimo.Substring(ultimo.LastIndexOf('-') + 1))))
                            ultimo = numDoc;
                    }
                }
            }

            if (string.IsNullOrEmpty(ultimo))
                return "FAC-001";

            // Generar siguiente número
            int idx = ultimo.LastIndexOf('-');
            int numActual = int.Parse(ultimo.Substring(idx + 1));
            return ultimo.Substring(0, idx + 1) + (numActual + 1).ToString("D3");
        }

        // Registrar compra completa (transaccional)
        public void RegistrarCompra(DateTime fecha, string noDocumento, int proveedorId, int usuarioRegistroId,
                                    List<DetalleCompraItem> detalles, out string pError)
        {
            pError = string.Empty;
            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null) return;

            SqlTransaction transaction = null;
            try
            {
                transaction = conn.BeginTransaction();

                // Crear DataTable para el TVP
                DataTable dtDetalle = new DataTable();
                dtDetalle.Columns.Add("InventarioId", typeof(int));
                dtDetalle.Columns.Add("Cantidad", typeof(double));
                dtDetalle.Columns.Add("PrecioCompra", typeof(decimal));
                foreach (var det in detalles)
                {
                    dtDetalle.Rows.Add(det.InventarioId, det.Cantidad, det.PrecioCompra);
                }

                using (SqlCommand cmd = new SqlCommand("COMPRA.SpRegistrarCompraCompleta", conn, transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@NoDocumento", noDocumento);
                    cmd.Parameters.AddWithValue("@ProveedorId", proveedorId);
                    cmd.Parameters.AddWithValue("@UsuarioRegistroId", usuarioRegistroId);
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@Detalle", dtDetalle);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "COMPRA.DetalleCompraType";

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

        private DataTable ObtenerTabla(string storedProcedure, SqlParameter[] parameters, out string pError)
        {
            pError = string.Empty;
            DataTable dt = new DataTable();
            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null) return null;

            try
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
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