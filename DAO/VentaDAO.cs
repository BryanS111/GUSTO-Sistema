using System;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class VentaDAO
    {
        private Conexion _conexion;

        public VentaDAO()
        {
            _conexion = new Conexion();
        }

        // Obtener órdenes pendientes con formato para el combo
        public DataTable ObtenerOrdenesPendientes(out string pError)
        {
            string consulta = @"
                SELECT o.OrdenId,
                       'Id: ' + CAST(o.OrdenId AS VARCHAR) + ' - ' + c.Nombre + ' ' + c.Apellido AS DisplayOrden,
                       o.Total,
                       c.Nombre + ' ' + c.Apellido AS ClienteNombre,
                       t.TipoOrden,
                       o.EstadoId
                FROM VENTA.ORDEN o
                INNER JOIN VENTA.CLIENTE c ON o.ClienteId = c.ClienteId
                INNER JOIN VENTA.TIPO_ORDEN t ON o.TipoOrdenId = t.TipoOrdenId
                INNER JOIN GLOBAL.ESTADO e ON o.EstadoId = e.EstadoId
                WHERE UPPER(e.Estado) = 'PENDIENTE'
                ORDER BY o.FechaHora ASC";
            return EjecutarReader(consulta, null, out pError);
        }

        // Obtener detalle de una orden
        public DataTable ObtenerDetalleOrden(int ordenId, out string pError)
        {
            string consulta = @"
                SELECT ISNULL(m.Nombre, co.Nombre) AS Producto,
                       d.Cantidad,
                       d.PrecioUnitario,
                       d.Total
                FROM VENTA.DET_ORDEN d
                LEFT JOIN VENTA.MENU m ON d.MenuId = m.MenuId
                LEFT JOIN VENTA.COMBO co ON d.ComboId = co.ComboId
                WHERE d.OrdenId = @OrdenId";
            return EjecutarReader(consulta, new SqlParameter[] { new SqlParameter("@OrdenId", ordenId) }, out pError);
        }

        // Obtener métodos de pago desde la BD
        public DataTable ObtenerMetodosPago(out string pError)
        {
            return EjecutarReader("SELECT MetodoPagoId, Metodo FROM VENTA.METODO_PAGO ORDER BY Metodo", null, out pError);
        }

        // Generar siguiente número de documento
        public string ObtenerSiguienteNoDocumento(out string pError)
        {
            pError = string.Empty;
            DataTable dt = EjecutarReader("SELECT TOP 1 NoDocumento FROM VENTA.VENTA ORDER BY VentaId DESC", null, out pError);
            if (dt == null || dt.Rows.Count == 0)
                return "FAC-001";

            string ultimo = dt.Rows[0]["NoDocumento"].ToString();
            int idx = ultimo.LastIndexOf('-');
            if (idx >= 0 && int.TryParse(ultimo.Substring(idx + 1), out int n))
                return ultimo.Substring(0, idx + 1) + (n + 1).ToString("D3");
            return "FAC-001";
        }

        // Registrar venta y cerrar orden
        public void RegistrarVenta(int ordenId, DateTime fecha, string noDocumento, string metodoPago,
                                   decimal montoRecibido, decimal total, out string pError)
        {
            pError = string.Empty;
            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null) return;

            try
            {
                using (SqlCommand cmd = new SqlCommand("VENTA.SpRegistrarVenta", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrdenId", ordenId);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@NoDocumento", noDocumento);
                    cmd.Parameters.AddWithValue("@MetodoPago", metodoPago);
                    cmd.Parameters.AddWithValue("@MontoRecibido", montoRecibido);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
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

        public DataTable ObtenerVentasPorFecha(DateTime fechaInicio, DateTime fechaFin, out string pError)
        {
            string consulta = @"
        SELECT v.VentaId,
               v.Fecha,
               v.NoDocumento,
               c.Nombre + ' ' + c.Apellido AS Cliente,
               o.Total,
               v.MetodoPago,
               eo.Estado AS Estado            -- ← Estado de la ORDEN, no de la venta
        FROM VENTA.VENTA v
        INNER JOIN VENTA.ORDEN o ON v.OrdenId = o.OrdenId
        INNER JOIN VENTA.CLIENTE c ON o.ClienteId = c.ClienteId
        INNER JOIN GLOBAL.ESTADO eo ON o.EstadoId = eo.EstadoId
        WHERE v.Fecha >= @FechaInicio AND v.Fecha < DATEADD(DAY, 1, @FechaFin)
        ORDER BY v.Fecha DESC";

            SqlParameter[] parametros = {
        new SqlParameter("@FechaInicio", fechaInicio.Date),
        new SqlParameter("@FechaFin", fechaFin.Date)
    };

            return EjecutarReader(consulta, parametros, out pError);
        }

    }
}