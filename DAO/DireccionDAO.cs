using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class DireccionDAO : AbstractDAO<Direccion>
    {
        public override List<Direccion> ObtenerTodos(out string pError)
        {
            List<Direccion> lista = new List<Direccion>();
            pError = string.Empty;

            DataTable dt = ObtenerTabla("DELIVERY.SpSelectAllDireccion", null, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
                lista.Add(MapearDireccion(row));
            return lista;
        }

        public override Direccion ObtenerPorId(int id, out string pError)
        {
            pError = "No implementado.";
            return null;
        }

        public override Direccion ObtenerPorId(string id, out string pError)
        {
            pError = "No implementado.";
            return null;
        }

        public override void GuardarRegistro(Direccion reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@MunicipioId", SqlDbType.Int) { Value = reg.MunicipioId },
                new SqlParameter("@ColoniBarrio", SqlDbType.VarChar) { Value = reg.ColoniaBarrio },
                new SqlParameter("@NoCasa", SqlDbType.VarChar) { Value = reg.NoCasa ?? (object)DBNull.Value },
                new SqlParameter("@PuntoReferencia", SqlDbType.VarChar) { Value = reg.PuntoReferencia ?? (object)DBNull.Value },
                new SqlParameter("@CoordenadasMaps", SqlDbType.VarChar) { Value = reg.CoordenadasMaps ?? (object)DBNull.Value },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            EjecutarComando("DELIVERY.SpInsertDireccion", parametros, out pError);
        }

        public override void ActualizarRegistro(Direccion reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@DireccionId", SqlDbType.Int) { Value = reg.DireccionId },
                new SqlParameter("@MunicipioId", SqlDbType.Int) { Value = reg.MunicipioId },
                new SqlParameter("@ColoniBarrio", SqlDbType.VarChar) { Value = reg.ColoniaBarrio },
                new SqlParameter("@NoCasa", SqlDbType.VarChar) { Value = reg.NoCasa ?? (object)DBNull.Value },
                new SqlParameter("@PuntoReferencia", SqlDbType.VarChar) { Value = reg.PuntoReferencia ?? (object)DBNull.Value },
                new SqlParameter("@CoordenadasMaps", SqlDbType.VarChar) { Value = reg.CoordenadasMaps ?? (object)DBNull.Value },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            EjecutarComando("DELIVERY.SpUpdateDireccion", parametros, out pError);
        }

        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@DireccionId", SqlDbType.Int) { Value = id }
            };
            EjecutarComando("DELIVERY.SpDeleteLogicoDireccion", parametros, out pError);
        }

        public List<Direccion> Buscar(string buscar, out string pError)
        {
            List<Direccion> lista = new List<Direccion>();
            pError = string.Empty;

            SqlParameter[] parametros = {
                new SqlParameter("@Buscar", SqlDbType.VarChar) { Value = buscar }
            };
            DataTable dt = ObtenerTabla("DELIVERY.SpSelectDireccion", parametros, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
                lista.Add(MapearDireccion(row));
            return lista;
        }

        public DataTable ObtenerMunicipios(out string pError)
        {
            return ObtenerTabla("DELIVERY.SpSelectAllMunicipio", null, out pError);
        }

        private Direccion MapearDireccion(DataRow row)
        {
            return new Direccion
            {
                DireccionId = Convert.ToInt32(row["DireccionId"]),
                MunicipioId = Convert.ToInt32(row["MunicipioId"]),
                MunicipioNombre = row["Municipio"].ToString(),
                ColoniaBarrio = row["Colonia/Barrio"].ToString(),
                NoCasa = row["No. Casa"]?.ToString(),
                PuntoReferencia = row["Punto de Referencia"]?.ToString(),
                CoordenadasMaps = row["Coordenadas"]?.ToString(),
                EstadoId = Convert.ToInt32(row["EstadoId"]),
                EstadoNombre = row["EstadoNombre"].ToString()
            };
        }

        public DataTable ObtenerEstadosDireccion(out string pError)
        {
            DataTable dt = ObtenerTabla("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return null;

            DataTable filtrado = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Entidad"].ToString() == "DIRECCION")
                    filtrado.ImportRow(row);
            }
            return filtrado;
        }
    }
}