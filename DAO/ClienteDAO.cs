using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class ClienteDAO : AbstractDAO<Cliente>
    {
        public override List<Cliente> ObtenerTodos(out string pError)
        {
            List<Cliente> lista = new List<Cliente>();
            pError = string.Empty;

            DataTable dt = ObtenerTabla("VENTA.SpSelectAllCliente", null, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
                lista.Add(MapearCliente(row));
            return lista;
        }

        public override Cliente ObtenerPorId(int id, out string pError)
        {
            pError = "No implementado.";
            return null;
        }

        public override Cliente ObtenerPorId(string id, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@Buscar", SqlDbType.VarChar) { Value = id } };
            DataTable dt = ObtenerTabla("VENTA.SpSelectCliente", parametros, out pError);
            if (dt == null || dt.Rows.Count == 0) return null;
            return MapearCliente(dt.Rows[0]);
        }

        public override void GuardarRegistro(Cliente reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = reg.Apellido },
                new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = reg.Telefono },
                new SqlParameter("@DireccionId", SqlDbType.Int) { Value = reg.DireccionId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            int filas = EjecutarComando("VENTA.SpInsertCliente", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se insertó el cliente. Verifique los datos.";
        }

        public override void ActualizarRegistro(Cliente reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@ClienteId", SqlDbType.Int) { Value = reg.ClienteId },
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = reg.Apellido },
                new SqlParameter("@NombreCompleto", SqlDbType.VarChar) { Value = reg.NombreCompleto },
                new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = reg.Telefono },
                new SqlParameter("@DireccionId", SqlDbType.Int) { Value = reg.DireccionId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            int filas = EjecutarComando("VENTA.SpUpdateCliente", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se actualizó ningún registro. Verifique el teléfono.";
        }

        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@ClienteId", SqlDbType.Int) { Value = id } };
            EjecutarComando("VENTA.SpDeleteLogicoCliente", parametros, out pError);
        }

        public List<Cliente> Buscar(string buscar, out string pError)
        {
            List<Cliente> lista = new List<Cliente>();
            pError = string.Empty;

            SqlParameter[] parametros = { new SqlParameter("@Buscar", SqlDbType.VarChar) { Value = buscar } };
            DataTable dt = ObtenerTabla("VENTA.SpSelectCliente", parametros, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
                lista.Add(MapearCliente(row));
            return lista;
        }

        public DataTable ObtenerDireccionesActivas(out string pError)
        {
            return ObtenerTabla("DELIVERY.SpSelectDireccionesActivas", null, out pError);
        }

        public DataTable ObtenerEstadosCliente(out string pError)
        {
            DataTable dt = ObtenerTabla("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return null;

            DataTable filtrado = dt.Clone();
            foreach (DataRow row in dt.Rows)
                if (row["Entidad"].ToString() == "CLIENTE")
                    filtrado.ImportRow(row);
            return filtrado;
        }

        private Cliente MapearCliente(DataRow row)
        {
            return new Cliente
            {
                ClienteId = Convert.ToInt32(row["ClienteId"]),
                Nombre = row["Nombre"].ToString(),
                Apellido = row["Apellido"].ToString(),
                NombreCompleto = row["NombreCompleto"].ToString(),
                Telefono = row["Telefono"].ToString(),
                DireccionId = Convert.ToInt32(row["DireccionId"]),
                DireccionNombre = row["DireccionNombre"].ToString(),
                PuntoReferencia = row["PuntoReferencia"]?.ToString(),
                EstadoId = Convert.ToInt32(row["EstadoId"]),
                EstadoNombre = row["EstadoNombre"].ToString()
            };
        }
    }
}