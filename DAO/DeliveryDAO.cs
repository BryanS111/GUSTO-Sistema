using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class DeliveryDAO
    {
        private Conexion _conexion;

        public DeliveryDAO()
        {
            _conexion = new Conexion();
        }

        // Órdenes pendientes de Delivery
        public DataTable ObtenerOrdenesPendientes(out string pError)
        {
            return EjecutarReader("VENTA.SpSelectOrdenesPendientesDelivery", null, out pError);
        }

        // Repartidores disponibles
        public DataTable ObtenerRepartidoresDisponibles(out string pError)
        {
            return EjecutarReader("DELIVERY.SpSelectRepartidoresDisponibles", null, out pError);
        }

        // Obtener tarifa para un municipio destino
        public decimal ObtenerTarifa(int municipioId, out string pError)
        {
            pError = string.Empty;
            DataTable dt = EjecutarReader("SELECT Costo FROM DELIVERY.TARIFA_DELIVERY WHERE MunicipioId = @MunicipioId",
                new SqlParameter[] { new SqlParameter("@MunicipioId", municipioId) }, out pError);
            if (dt != null && dt.Rows.Count > 0)
                return Convert.ToDecimal(dt.Rows[0]["Costo"]);
            return 5.00m; // Tarifa por defecto
        }

        // Obtener ubicación del local
        public DataRow ObtenerConfiguracionLocal(out string pError)
        {
            DataTable dt = EjecutarReader("SELECT TOP 1 cl.MunicipioId, m.Nombre AS Municipio, cl.ColoniaBarrio FROM DELIVERY.CONFIGURACION_LOCAL cl INNER JOIN DELIVERY.MUNICIPIO m ON cl.MunicipioId = m.MunicipioId", null, out pError);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        // Asignar un envío (usa el SP SpInsertEnvio existente)
        public void AsignarEnvio(int ordenId, int repartidorId, int direccionId, decimal tarifa, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@OrdenId", ordenId),
                new SqlParameter("@RepartidorId", repartidorId),
                new SqlParameter("@DireccionId", direccionId),
                new SqlParameter("@Tarifa", tarifa),
                new SqlParameter("@EstadoId", ObtenerEstadoId("ENVIO", "ASIGNADO"))
            };
            EjecutarNonQuery("DELIVERY.SpInsertEnvio", parametros, out pError);
        }

        // Obtener teléfono del repartidor a partir de su ID
        public string ObtenerTelefonoRepartidor(int repartidorId, out string pError)
        {
            pError = string.Empty;
            DataTable dt = EjecutarReader("SELECT e.Telefono FROM DELIVERY.REPARTIDOR r INNER JOIN RRHH.EMPLEADO e ON r.EmpleadoId = e.EmpleadoId WHERE r.RepartidorId = @RepartidorId",
                new SqlParameter[] { new SqlParameter("@RepartidorId", repartidorId) }, out pError);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0]["Telefono"].ToString();
            return null;
        }

        // Configurar ubicación del local
        public void GuardarConfiguracionLocal(int municipioId, string coloniaBarrio, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@MunicipioId", municipioId),
                new SqlParameter("@ColoniaBarrio", coloniaBarrio ?? (object)DBNull.Value)
            };
            EjecutarNonQuery(@"
                IF EXISTS (SELECT * FROM DELIVERY.CONFIGURACION_LOCAL)
                    UPDATE DELIVERY.CONFIGURACION_LOCAL SET MunicipioId = @MunicipioId, ColoniaBarrio = @ColoniaBarrio;
                ELSE
                    INSERT INTO DELIVERY.CONFIGURACION_LOCAL(MunicipioId, ColoniaBarrio) VALUES (@MunicipioId, @ColoniaBarrio);
            ", parametros, out pError);
        }

        // Guardar o actualizar tarifa
        public void GuardarTarifa(int municipioId, decimal costo, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@MunicipioId", municipioId),
                new SqlParameter("@Costo", costo)
            };
            EjecutarNonQuery(@"
                IF EXISTS (SELECT * FROM DELIVERY.TARIFA_DELIVERY WHERE MunicipioId = @MunicipioId)
                    UPDATE DELIVERY.TARIFA_DELIVERY SET Costo = @Costo WHERE MunicipioId = @MunicipioId;
                ELSE
                    INSERT INTO DELIVERY.TARIFA_DELIVERY(MunicipioId, Costo) VALUES (@MunicipioId, @Costo);
            ", parametros, out pError);
        }

        // Obtener todas las tarifas para mostrarlas en un DataGridView (en el popup de configuración)
        public DataTable ObtenerTarifas(out string pError)
        {
            return EjecutarReader(@"
                SELECT t.TarifaId, m.Nombre AS Municipio, t.Costo
                FROM DELIVERY.TARIFA_DELIVERY t
                INNER JOIN DELIVERY.MUNICIPIO m ON t.MunicipioId = m.MunicipioId
                ORDER BY m.Nombre
            ", null, out pError);
        }

        // Métodos privados
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
                    if (consulta.StartsWith("VENTA.") || consulta.StartsWith("DELIVERY."))
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

        private int EjecutarNonQuery(string consulta, SqlParameter[] parametros, out string pError)
        {
            pError = string.Empty;
            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null) return -1;

            try
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    if (consulta.StartsWith("VENTA.") || consulta.StartsWith("DELIVERY."))
                        cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { pError = ex.Message; return -1; }
            finally { _conexion.CerrarConexion(out _); }
        }

        private int ObtenerEstadoId(string entidad, string estado)
        {
            string error;
            DataTable dt = EjecutarReader("GLOBAL.SpSelectAllEstado", null, out error);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Entidad"].ToString() == entidad && row["Estado"].ToString() == estado)
                        return Convert.ToInt32(row["Id"]);
                }
            }
            return 1; // fallback
        }
    }
}