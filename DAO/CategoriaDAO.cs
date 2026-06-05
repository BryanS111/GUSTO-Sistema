using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class CategoriaDAO : AbstractDAO<Categoria>
    {
        public override List<Categoria> ObtenerTodos(out string pError)
        {
            List<Categoria> lista = new List<Categoria>();
            pError = string.Empty;

            DataTable dt = ObtenerTabla("VENTA.SpSelectAllCategoria", null, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Categoria
                {
                    CategoriaId = Convert.ToInt32(row["CategoriaId"]),
                    Nombre = row["Categoria"].ToString(),
                    EstadoId = Convert.ToInt32(row["EstadoId"]),
                    EstadoNombre = row["EstadoNombre"].ToString()
                });
            }
            return lista;
        }

        public override Categoria ObtenerPorId(int id, out string pError)
        {
            pError = "No implementado. Use ObtenerTodos y filtre.";
            return null;
        }

        public override Categoria ObtenerPorId(string id, out string pError)
        {
            return ObtenerPorId(int.TryParse(id, out int i) ? i : 0, out pError);
        }

        public override void GuardarRegistro(Categoria reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@Categoria", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            EjecutarComando("VENTA.SpInsertCategoria", parametros, out pError);
        }

        public override void ActualizarRegistro(Categoria reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@CategoriaId", SqlDbType.Int) { Value = reg.CategoriaId },
                new SqlParameter("@Categoria", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            EjecutarComando("VENTA.SpUpdateCategoria", parametros, out pError);
        }

        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@CategoriaId", SqlDbType.Int) { Value = id }
            };
            EjecutarComando("VENTA.SpDeleteLogicoCategoria", parametros, out pError);
        }

        public DataTable ObtenerEstadosCategoria(out string pError)
        {
            // Reutiliza método de EmpleadoDAO? Podemos copiar la lógica.
            DataTable dt = ObtenerTabla("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return null;
            DataTable filtrado = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Entidad"].ToString() == "CATEGORIA")
                    filtrado.ImportRow(row);
            }
            return filtrado;
        }
    }
}