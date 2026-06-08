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

        // ==================== TARIFA HÍBRIDA (NUEVO) ====================
        public decimal ObtenerTarifa(int municipioDestinoId, out string pError)
        {
            pError = string.Empty;

            // 1. Intentar cálculo por coordenadas
            try
            {
                DataRow configLocal = ObtenerConfiguracionLocal(out pError);
                if (configLocal == null)
                    throw new Exception("Ubicación del local no configurada.");

                int municipioLocalId = Convert.ToInt32(configLocal["MunicipioId"]);

                var coordLocal = ObtenerCoordenadasMunicipio(municipioLocalId, out pError);
                if (coordLocal == null)
                    throw new Exception("Coordenadas del local no encontradas.");

                var coordDestino = ObtenerCoordenadasMunicipio(municipioDestinoId, out pError);
                if (coordDestino == null)
                    throw new Exception("Coordenadas del destino no encontradas.");

                double distancia = CalcularDistancia(coordLocal.Item1, coordLocal.Item2, coordDestino.Item1, coordDestino.Item2);

                // Rangos de tarifa según distancia (en km)
                if (distancia <= 3) return 2.00m;
                if (distancia <= 8) return 3.50m;
                if (distancia <= 15) return 5.00m;
                if (distancia <= 30) return 7.50m;
                return 10.00m;
            }
            catch (Exception ex)
            {
                pError = ex.Message;
            }

            // 2. Plan B: tabla TARIFA_DELIVERY
            DataTable dt = EjecutarReader(
                "SELECT Costo FROM DELIVERY.TARIFA_DELIVERY WHERE MunicipioId = @MunicipioId",
                new SqlParameter[] { new SqlParameter("@MunicipioId", municipioDestinoId) },
                out pError);
            if (dt != null && dt.Rows.Count > 0)
                return Convert.ToDecimal(dt.Rows[0]["Costo"]);

            // 3. Plan C: tarifa por defecto
            return 5.00m;
        }

        // Obtener ubicación del local
        public DataRow ObtenerConfiguracionLocal(out string pError)
        {
            DataTable dt = EjecutarReader("SELECT TOP 1 cl.MunicipioId, m.Nombre AS Municipio, cl.ColoniaBarrio FROM DELIVERY.CONFIGURACION_LOCAL cl INNER JOIN DELIVERY.MUNICIPIO m ON cl.MunicipioId = m.MunicipioId", null, out pError);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        // Asignar un envío
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

        // Teléfono del repartidor
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

        // Consulta de envíos
        public DataTable ObtenerEnvios(string filtroRepartidor, string estadoEnvio, out string pError)
        {
            string consulta = @"
        SELECT e.EnvioId,
               o.OrdenId,
               c.Nombre + ' ' + c.Apellido AS Cliente,
               emp.Nombre + ' ' + emp.Apellido AS Repartidor,
               e.Tarifa,
               es.Estado AS EstadoEnvio,
               e.DireccionId
        FROM DELIVERY.ENVIO e
        INNER JOIN VENTA.ORDEN o ON e.OrdenId = o.OrdenId
        INNER JOIN VENTA.CLIENTE c ON o.ClienteId = c.ClienteId
        INNER JOIN DELIVERY.REPARTIDOR r ON e.RepartidorId = r.RepartidorId
        INNER JOIN RRHH.EMPLEADO emp ON r.EmpleadoId = emp.EmpleadoId
        INNER JOIN GLOBAL.ESTADO es ON e.EstadoId = es.EstadoId
        WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(filtroRepartidor))
                consulta += " AND (emp.Nombre + ' ' + emp.Apellido LIKE '%' + @Repartidor + '%')";

            if (!string.IsNullOrWhiteSpace(estadoEnvio) && estadoEnvio != "Todos")
                consulta += " AND es.Estado = @EstadoEnvio";

            consulta += " ORDER BY e.EnvioId DESC";

            SqlParameter[] parametros = {
        new SqlParameter("@Repartidor", filtroRepartidor ?? (object)DBNull.Value),
        new SqlParameter("@EstadoEnvio", estadoEnvio ?? (object)DBNull.Value)
    };

            return EjecutarReader(consulta, parametros, out pError);
        }

        // ==================== MÉTODOS PRIVADOS ====================
        private Tuple<double, double> ObtenerCoordenadasMunicipio(int municipioId, out string pError)
        {
            pError = string.Empty;
            string consulta = "SELECT Latitud, Longitud FROM DELIVERY.COORDENADAS_MUNICIPIO WHERE MunicipioId = @MunicipioId";
            DataTable dt = EjecutarReader(consulta, new SqlParameter[] { new SqlParameter("@MunicipioId", municipioId) }, out pError);
            if (dt != null && dt.Rows.Count > 0)
            {
                double lat = Convert.ToDouble(dt.Rows[0]["Latitud"]);
                double lon = Convert.ToDouble(dt.Rows[0]["Longitud"]);
                return Tuple.Create(lat, lon);
            }
            return null;
        }

        private double CalcularDistancia(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371;
            double dLat = (lat2 - lat1) * Math.PI / 180;
            double dLon = (lon2 - lon1) * Math.PI / 180;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
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
            return 1;
        }
    }
}