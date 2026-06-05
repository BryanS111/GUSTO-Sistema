using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class ProveedorDAO : AbstractDAO<Proveedor>
    {
        public override List<Proveedor> ObtenerTodos(out string pError)
        {
            List<Proveedor> lista = new List<Proveedor>();
            pError = string.Empty;

            DataTable dt = ObtenerTabla("COMPRA.SpSelectAllProveedores", null, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(MapearProveedor(row));
            }
            return lista;
        }

        public override Proveedor ObtenerPorId(int id, out string pError)
        {
            pError = string.Empty;
            List<Proveedor> todos = ObtenerTodos(out pError);
            if (todos == null) return null;
            return todos.Find(p => p.ProveedorId == id);
        }

        public override Proveedor ObtenerPorId(string id, out string pError)
        {
            if (int.TryParse(id, out int idEntero))
                return ObtenerPorId(idEntero, out pError);
            pError = "ID no válido.";
            return null;
        }

        public override void GuardarRegistro(Proveedor reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@nombre", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@direccion", SqlDbType.VarChar) { Value = reg.Direccion ?? (object)DBNull.Value },
                new SqlParameter("@telefono", SqlDbType.VarChar) { Value = reg.Telefono },
                new SqlParameter("@noRegistro", SqlDbType.VarChar) { Value = reg.NoRegistro ?? (object)DBNull.Value },
                new SqlParameter("@NIT", SqlDbType.VarChar) { Value = reg.NIT ?? (object)DBNull.Value },
                new SqlParameter("@estado", SqlDbType.Int) { Value = reg.EstadoId }
            };
            EjecutarComando("COMPRA.SpInsertProveedor", parametros, out pError);
        }

        public override void ActualizarRegistro(Proveedor reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@ProveedorId", SqlDbType.Int) { Value = reg.ProveedorId },
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = reg.Direccion ?? (object)DBNull.Value },
                new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = reg.Telefono },
                new SqlParameter("@NoRegistro", SqlDbType.VarChar) { Value = reg.NoRegistro ?? (object)DBNull.Value },
                new SqlParameter("@NIT", SqlDbType.VarChar) { Value = reg.NIT ?? (object)DBNull.Value },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };

            int filas = EjecutarComando("COMPRA.SpUpdateProveedor", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se actualizó ningún registro. Verifique que los datos no estén duplicados (teléfono, NCR o NIT).";
        }

        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            Proveedor prov = ObtenerPorId(id, out pError);
            if (prov == null) return;

            int idInactivo = ObtenerIdEstadoInactivo(out pError);
            if (!string.IsNullOrEmpty(pError)) return;

            prov.EstadoId = idInactivo;
            ActualizarRegistro(prov, out pError);
        }

        public List<Proveedor> Buscar(string buscar, out string pError)
        {
            pError = string.Empty;
            List<Proveedor> todos = ObtenerTodos(out pError);
            if (todos == null) return null;

            if (string.IsNullOrWhiteSpace(buscar))
                return todos;

            string b = buscar.ToLower();
            return todos.FindAll(p =>
                p.Nombre.ToLower().Contains(b) ||
                p.Telefono.Contains(b) ||
                (p.NoRegistro != null && p.NoRegistro.ToLower().Contains(b)) ||
                (p.NIT != null && p.NIT.ToLower().Contains(b))
            );
        }

        public DataTable ObtenerEstadosProveedor(out string pError)
        {
            DataTable dt = ObtenerTabla("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return null;

            DataTable filtrado = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Entidad"].ToString() == "PROVEEDOR")
                    filtrado.ImportRow(row);
            }
            return filtrado;
        }

        private int ObtenerIdEstadoInactivo(out string pError)
        {
            pError = string.Empty;
            DataTable dt = ObtenerTabla("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Entidad"].ToString() == "PROVEEDOR" && row["Estado"].ToString() == "INACTIVO")
                    return Convert.ToInt32(row["Id"]);
            }
            pError = "No se encontró el estado INACTIVO para PROVEEDOR.";
            return 0;
        }

        private Proveedor MapearProveedor(DataRow row)
        {
            return new Proveedor
            {
                ProveedorId = Convert.ToInt32(row["Codigo"]),
                Nombre = row["Nombre"].ToString(),
                Direccion = row["Direccion"].ToString(),
                Telefono = row["Telefono"].ToString(),
                NoRegistro = row["No. Registro"]?.ToString(),
                NIT = row["NIT"]?.ToString(),
                EstadoNombre = row["Estado"].ToString(),
                EstadoId = 0
            };
        }
    }
}