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
            // Implementación simple: busca en todos los clientes
            pError = string.Empty;
            List<Cliente> todos = ObtenerTodos(out pError);
            if (todos == null) return null;
            return todos.Find(c => c.ClienteId == id);
        }

        public override Cliente ObtenerPorId(string id, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@Buscar", SqlDbType.VarChar) { Value = id } };
            DataTable dt = ObtenerTabla("VENTA.SpSelectCliente", parametros, out pError);
            if (dt == null || dt.Rows.Count == 0) return null;
            return MapearCliente(dt.Rows[0]);
        }

        // ==================== GUARDAR (CON AUDITORÍA) ====================
        public override void GuardarRegistro(Cliente reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = reg.Apellido },
                new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = reg.Telefono },
                new SqlParameter("@CorreoElectronico", SqlDbType.VarChar) { Value = string.IsNullOrWhiteSpace(reg.CorreoElectronico) ? (object)DBNull.Value : reg.CorreoElectronico },
                new SqlParameter("@DireccionId", SqlDbType.Int) { Value = reg.DireccionId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId },
                new SqlParameter("@UsuarioRegistroId", SqlDbType.Int) { Value = SesionActual.UsuarioId }
            };
            int filas = EjecutarComando("VENTA.SpInsertCliente", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se insertó el cliente. Verifique los datos.";
        }

        // ==================== ACTUALIZAR (CON AUDITORÍA DETALLADA) ====================
        public override void ActualizarRegistro(Cliente reg, out string pError)
        {
            pError = string.Empty;

            // Obtener el cliente original para comparar cambios
            Cliente original = ObtenerPorId(reg.ClienteId, out _);
            string cambios = "";

            if (original != null)
            {
                if (original.Nombre != reg.Nombre) cambios += $"Nombre: {original.Nombre} a {reg.Nombre}; ";
                if (original.Apellido != reg.Apellido) cambios += $"Apellido: {original.Apellido} a {reg.Apellido}; ";
                if (original.Telefono != reg.Telefono) cambios += $"Teléfono: {original.Telefono} a {reg.Telefono}; ";
                if (original.DireccionId != reg.DireccionId) cambios += $"DirecciónId: {original.DireccionId} a {reg.DireccionId}; ";
                if (original.EstadoId != reg.EstadoId)
                {
                    string estadoOriginal = original.EstadoId == 1 ? "Activo" : "Inactivo";
                    string estadoNuevo = reg.EstadoId == 1 ? "Activo" : "Inactivo";
                    cambios += $"Estado: {estadoOriginal} a {estadoNuevo}; ";
                }
            }

            SqlParameter[] parametros = {
                new SqlParameter("@ClienteId", SqlDbType.Int) { Value = reg.ClienteId },
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@Apellido", SqlDbType.VarChar) { Value = reg.Apellido },
                new SqlParameter("@NombreCompleto", SqlDbType.VarChar) { Value = reg.NombreCompleto },
                new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = reg.Telefono },
                new SqlParameter("@CorreoElectronico", SqlDbType.VarChar) { Value = string.IsNullOrWhiteSpace(reg.CorreoElectronico) ? (object)DBNull.Value : reg.CorreoElectronico },
                new SqlParameter("@DireccionId", SqlDbType.Int) { Value = reg.DireccionId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId },
                new SqlParameter("@UsuarioModificacionId", SqlDbType.Int) { Value = SesionActual.UsuarioId }
            };
            int filas = EjecutarComando("VENTA.SpUpdateCliente", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se actualizó ningún registro. Verifique el teléfono.";
        }

        // ==================== ELIMINACIÓN LÓGICA (CON AUDITORÍA) ====================
        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            Cliente cliente = ObtenerPorId(id, out pError);
            if (cliente == null) return;

            SqlParameter[] parametros = {
                new SqlParameter("@ClienteId", SqlDbType.Int) { Value = id },
                new SqlParameter("@UsuarioModificacionId", SqlDbType.Int) { Value = SesionActual.UsuarioId }
            };
            int filas = EjecutarComando("VENTA.SpDeleteLogicoCliente", parametros, out pError);
            if (filas == 0 && string.IsNullOrEmpty(pError))
                pError = "No se pudo desactivar el cliente. Verifique los datos.";
        }

        // ==================== BÚSQUEDA Y MÉTODOS AUXILIARES (SIN CAMBIOS) ====================
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
                CorreoElectronico = LeerString(row, "CorreoElectronico"),
                DireccionId = Convert.ToInt32(row["DireccionId"]),
                DireccionNombre = row["DireccionNombre"].ToString(),
                PuntoReferencia = row["PuntoReferencia"]?.ToString(),
                EstadoId = Convert.ToInt32(row["EstadoId"]),
                EstadoNombre = row["EstadoNombre"].ToString()
            };
        }

        private string LeerString(DataRow row, string columna)
        {
            return row.Table.Columns.Contains(columna) && row[columna] != DBNull.Value
                ? row[columna].ToString()
                : string.Empty;
        }
    }
}
