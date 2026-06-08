using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class ProveedorDAO : AbstractDAO<Proveedor>
    {
        // ==================== AUDITORÍA ====================
        private void Auditar(string accion, string detalle, int usuarioId)
        {
            try
            {
                SqlParameter[] parametros = {
                    new SqlParameter("@AccionEvento", accion),
                    new SqlParameter("@Detalle", detalle),
                    new SqlParameter("@UsuarioRegistroId", usuarioId)
                };
                EjecutarComando("AUDITORIA.SpRegistrarAuditoria", parametros, out _);
            }
            catch { /* La auditoría no debe trancar el sistema */ }
        }

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

        // ==================== GUARDAR (CON AUDITORÍA) ====================
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

            if (string.IsNullOrEmpty(pError))
                Auditar("INSERCION", $"Nuevo proveedor: {reg.Nombre} (Registrado por ID: {SesionActual.UsuarioId})", SesionActual.UsuarioId);
        }

        // ==================== ACTUALIZAR (CON AUDITORÍA DETALLADA) ====================
        public override void ActualizarRegistro(Proveedor reg, out string pError)
        {
            pError = string.Empty;

            // Obtener el proveedor original para comparar cambios
            Proveedor original = ObtenerPorId(reg.ProveedorId, out _);
            string cambios = "";

            if (original != null)
            {
                if (original.Nombre != reg.Nombre) cambios += $"Nombre: {original.Nombre} a {reg.Nombre}; ";
                if (original.Direccion != reg.Direccion) cambios += $"Dirección: {original.Direccion ?? "N/A"} a {reg.Direccion ?? "N/A"}; ";
                if (original.Telefono != reg.Telefono) cambios += $"Teléfono: {original.Telefono} a {reg.Telefono}; ";
                if (original.NoRegistro != reg.NoRegistro) cambios += $"No.Registro: {original.NoRegistro ?? "N/A"} a {reg.NoRegistro ?? "N/A"}; ";
                if (original.NIT != reg.NIT) cambios += $"NIT: {original.NIT ?? "N/A"} a {reg.NIT ?? "N/A"}; ";
                if (original.EstadoId != reg.EstadoId)
                {
                    string estadoOriginal = original.EstadoId == 1 ? "Activo" : "Inactivo";
                    string estadoNuevo = reg.EstadoId == 1 ? "Activo" : "Inactivo";
                    cambios += $"Estado: {estadoOriginal} a {estadoNuevo}; ";
                }
            }

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
            else if (!string.IsNullOrEmpty(cambios))
                Auditar("ACTUALIZACION", $"Proveedor {reg.Nombre} modificado por ID {SesionActual.UsuarioId}: {cambios.TrimEnd(' ', ';')}", SesionActual.UsuarioId);
        }

        // ==================== ELIMINACIÓN LÓGICA (CON AUDITORÍA) ====================
        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            Proveedor prov = ObtenerPorId(id, out pError);
            if (prov == null) return;

            string nombreProveedor = prov.Nombre;

            int idInactivo = ObtenerIdEstadoInactivo(out pError);
            if (!string.IsNullOrEmpty(pError)) return;

            prov.EstadoId = idInactivo;

            // Ejecutamos el SP directamente para no llamar a ActualizarRegistro y evitar doble auditoría
            SqlParameter[] parametros = {
                new SqlParameter("@ProveedorId", SqlDbType.Int) { Value = prov.ProveedorId },
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = prov.Nombre },
                new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = prov.Direccion ?? (object)DBNull.Value },
                new SqlParameter("@Telefono", SqlDbType.VarChar) { Value = prov.Telefono },
                new SqlParameter("@NoRegistro", SqlDbType.VarChar) { Value = prov.NoRegistro ?? (object)DBNull.Value },
                new SqlParameter("@NIT", SqlDbType.VarChar) { Value = prov.NIT ?? (object)DBNull.Value },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = prov.EstadoId }
            };

            int filas = EjecutarComando("COMPRA.SpUpdateProveedor", parametros, out pError);
            if (string.IsNullOrEmpty(pError) && filas > 0)
                Auditar("ELIMINACION LOGICA", $"Proveedor desactivado: {nombreProveedor} (ID: {id}) por usuario ID {SesionActual.UsuarioId}", SesionActual.UsuarioId);
        }

        // ==================== BÚSQUEDA Y MÉTODOS AUXILIARES (SIN CAMBIOS) ====================
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
            DataTable dt = ObtenerEstadosProveedor(out pError);
            if (dt == null) return 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Estado"].ToString() == "INACTIVO")
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