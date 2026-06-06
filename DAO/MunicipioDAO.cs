using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class MunicipioDAO : AbstractDAO<Municipio>
    {
        public override List<Municipio> ObtenerTodos(out string pError)
        {
            List<Municipio> lista = new List<Municipio>();
            pError = string.Empty;

            DataTable dt = ObtenerTabla("DELIVERY.SpSelectAllMunicipio", null, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
                lista.Add(new Municipio { MunicipioId = Convert.ToInt32(row["Codigo"]), Nombre = row["Municipio"].ToString() });

            return lista;
        }

        public override Municipio ObtenerPorId(int id, out string pError)
        {
            pError = "No implementado";
            return null;
        }

        public override Municipio ObtenerPorId(string id, out string pError)
        {
            pError = "No implementado";
            return null;
        }

        public override void GuardarRegistro(Municipio reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre }
            };
            EjecutarComando("DELIVERY.SpInsertMunicipio", parametros, out pError);
        }

        public override void ActualizarRegistro(Municipio reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@MunicipioId", SqlDbType.Int) { Value = reg.MunicipioId },
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre }
            };
            EjecutarComando("DELIVERY.SpUpdateMunicipio", parametros, out pError);
        }
    }
}