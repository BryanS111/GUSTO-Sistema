using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class RepartidorDAO : AbstractDAO<Repartidor>
    {
        public override List<Repartidor> ObtenerTodos(out string pError)
        {
            List<Repartidor> lista = new List<Repartidor>();
            pError = string.Empty;

            DataTable dt = ObtenerTabla("DELIVERY.SpSelectAllRepartidor", null, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(MapearRepartidor(row));
            }
            return lista;
        }

        public override Repartidor ObtenerPorId(int id, out string pError)
        {
            pError = "No implementado. Use Buscar.";
            return null;
        }

        public override Repartidor ObtenerPorId(string id, out string pError)
        {
            pError = string.Empty;
            List<Repartidor> resultados = Buscar(id, out pError);
            if (resultados != null && resultados.Count > 0)
                return resultados.Find(r => r.RepartidorId.ToString() == id);
            return null;
        }

        public override void GuardarRegistro(Repartidor reg, out string pError)
        {
            pError = string.Empty;
                SqlParameter[] parametros = {
                new SqlParameter("@EmpleadoId", SqlDbType.Int) { Value = reg.EmpleadoId },
                new SqlParameter("@NoPlacaMoto", SqlDbType.VarChar) { Value = reg.NoPlacaMoto },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            int filas = EjecutarComando("DELIVERY.SpInsertRepartidor", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se insertó el registro. Verifique los datos.";
        }

        public override void ActualizarRegistro(Repartidor reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@RepartidorId", SqlDbType.Int) { Value = reg.RepartidorId },
                new SqlParameter("@EmpleadoId", SqlDbType.Int) { Value = reg.EmpleadoId },
                new SqlParameter("@NoPlacaMoto", SqlDbType.VarChar) { Value = reg.NoPlacaMoto },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            int filas = EjecutarComando("DELIVERY.SpUpdateRepartidor", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se actualizó ningún registro. Verifique la placa de moto.";
        }

        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            int idNoDisponible = ObtenerIdEstado("NO DISPONIBLE", out pError);
            if (!string.IsNullOrEmpty(pError)) return;

            SqlParameter[] parametros = {
                new SqlParameter("@RepartidorId", SqlDbType.Int) { Value = id },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = idNoDisponible }
            };
            EjecutarComando("DELIVERY.SpDeleteLogicoRepartidor", parametros, out pError);
        }

        public List<Repartidor> Buscar(string buscar, out string pError)
        {
            List<Repartidor> lista = new List<Repartidor>();
            pError = string.Empty;

            SqlParameter[] parametros = {
                new SqlParameter("@Buscar", SqlDbType.VarChar) { Value = buscar }
            };
            DataTable dt = ObtenerTabla("DELIVERY.SpSelectRepartidor", parametros, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(MapearRepartidor(row));
            }
            return lista;
        }

        public DataTable ObtenerEstadosRepartidor(out string pError)
        {
            DataTable dt = ObtenerTabla("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return null;

            DataTable filtrado = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Entidad"].ToString() == "REPARTIDOR")
                    filtrado.ImportRow(row);
            }
            return filtrado;
        }

        private int ObtenerIdEstado(string estadoNombre, out string pError)
        {
            pError = string.Empty;
            DataTable dt = ObtenerEstadosRepartidor(out pError);
            if (dt == null) return 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Estado"].ToString() == estadoNombre)
                    return Convert.ToInt32(row["Id"]);
            }
            pError = $"No se encontró el estado '{estadoNombre}' para REPARTIDOR.";
            return 0;
        }

        private Repartidor MapearRepartidor(DataRow row)
        {
            return new Repartidor
            {
                RepartidorId = Convert.ToInt32(row["RepartidorId"]),
                EmpleadoId = Convert.ToInt32(row["EmpleadoId"]),
                EmpleadoNombre = row["EmpleadoNombre"].ToString(),
                Telefono = row["Telefono"]?.ToString(),
                NoPlacaMoto = row["NoPlacaMoto"].ToString(),
                EstadoId = Convert.ToInt32(row["EstadoId"]),
                EstadoNombre = row["EstadoNombre"].ToString()
            };
        }
    }
}