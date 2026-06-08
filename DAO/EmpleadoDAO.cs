using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class EmpleadoDAO : AbstractDAO<Empleado>
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

        public override List<Empleado> ObtenerTodos(out string pError)
        {
            List<Empleado> lista = new List<Empleado>();
            pError = string.Empty;

            DataTable dt = ObtenerTabla("RRHH.SpSelectAllEmpleado", null, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(MapearEmpleado(row));
            }

            return lista;
        }

        public override Empleado ObtenerPorId(int id, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@Buscar", SqlDbType.NVarChar) { Value = id.ToString() }
            };

            DataTable dt = ObtenerTabla("RRHH.SpSelectEmpleado", parametros, out pError);
            if (dt == null || dt.Rows.Count == 0)
            {
                if (string.IsNullOrEmpty(pError))
                    pError = $"No se encontró empleado con ID {id}.";
                return null;
            }

            return MapearEmpleado(dt.Rows[0]);
        }

        public override Empleado ObtenerPorId(string id, out string pError)
        {
            if (int.TryParse(id, out int idEntero))
                return ObtenerPorId(idEntero, out pError);

            pError = "El ID proporcionado no es un número válido.";
            return null;
        }

        // ==================== GUARDAR (CON AUDITORÍA) ====================
        // ==================== GUARDAR (CON AUDITORÍA) ====================
        public override void GuardarRegistro(Empleado reg, out string pError)
        {
            pError = string.Empty;

            SqlParameter[] parametros = {
        new SqlParameter("@Nombre", SqlDbType.NVarChar) { Value = reg.Nombre },
        new SqlParameter("@Apellido", SqlDbType.NVarChar) { Value = reg.Apellido },
        new SqlParameter("@Telefono", SqlDbType.NVarChar) { Value = reg.Telefono ?? (object)DBNull.Value },
        new SqlParameter("@Email", SqlDbType.NVarChar) { Value = reg.Email ?? (object)DBNull.Value },
        new SqlParameter("@Direccion", SqlDbType.NVarChar) { Value = reg.Direccion ?? (object)DBNull.Value },
        new SqlParameter("@FechaNac", SqlDbType.Date) { Value = reg.FechaNac },
        new SqlParameter("@FechaContratacion", SqlDbType.Date) { Value = reg.FechaContratacion },
        new SqlParameter("@CargoId", SqlDbType.Int) { Value = reg.CargoId },
        new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId },
        new SqlParameter("@UsuarioRegistroId", SqlDbType.Int) { Value = reg.UsuarioRegistroId }
    };

            int filas = EjecutarComando("RRHH.SpIsertEmpleado", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se insertó el empleado. Verifique los datos (posible duplicidad de teléfono o email).";
            else
                Auditar("INSERCION", $"Nuevo empleado: {reg.Nombre} {reg.Apellido} (Registrado por ID: {SesionActual.UsuarioId})", SesionActual.UsuarioId);
        }

        // ==================== ACTUALIZAR (CON AUDITORÍA DETALLADA) ====================
        public override void ActualizarRegistro(Empleado reg, out string pError)
        {
            pError = string.Empty;

            // Obtener el empleado original para comparar cambios
            Empleado original = ObtenerPorId(reg.EmpleadoId, out _);
            string cambios = "";

            if (original != null)
            {
                if (original.Nombre != reg.Nombre) cambios += $"Nombre: {original.Nombre} a {reg.Nombre}; ";
                if (original.Apellido != reg.Apellido) cambios += $"Apellido: {original.Apellido} a {reg.Apellido}; ";
                if (original.Telefono != reg.Telefono) cambios += $"Teléfono: {original.Telefono ?? "N/A"} a {reg.Telefono ?? "N/A"}; ";
                if (original.Email != reg.Email) cambios += $"Email: {original.Email ?? "N/A"} a {reg.Email ?? "N/A"}; ";
                if (original.Direccion != reg.Direccion) cambios += $"Dirección: {original.Direccion ?? "N/A"} a {reg.Direccion ?? "N/A"}; ";
                if (original.FechaNac != reg.FechaNac) cambios += $"Fecha Nac: {original.FechaNac.ToShortDateString()} a {reg.FechaNac.ToShortDateString()}; ";
                if (original.FechaContratacion != reg.FechaContratacion) cambios += $"Fecha Contratación: {original.FechaContratacion.ToShortDateString()} a {reg.FechaContratacion.ToShortDateString()}; ";
                if (original.CargoId != reg.CargoId) cambios += $"CargoId: {original.CargoId} a {reg.CargoId}; ";
                if (original.EstadoId != reg.EstadoId)
                {
                    string estadoOriginal = original.EstadoId == 1 ? "Activo" : "Inactivo";
                    string estadoNuevo = reg.EstadoId == 1 ? "Activo" : "Inactivo";
                    cambios += $"Estado: {estadoOriginal} a {estadoNuevo}; ";
                }
            }

            SqlParameter[] parametros = {
        new SqlParameter("@EmpleadoId", SqlDbType.Int) { Value = reg.EmpleadoId },
        new SqlParameter("@Nombre", SqlDbType.NVarChar) { Value = reg.Nombre },
        new SqlParameter("@Apellido", SqlDbType.NVarChar) { Value = reg.Apellido },
        new SqlParameter("@Telefono", SqlDbType.NVarChar) { Value = reg.Telefono ?? (object)DBNull.Value },
        new SqlParameter("@Email", SqlDbType.NVarChar) { Value = reg.Email ?? (object)DBNull.Value },
        new SqlParameter("@Direccion", SqlDbType.NVarChar) { Value = reg.Direccion ?? (object)DBNull.Value },
        new SqlParameter("@FechaNac", SqlDbType.Date) { Value = reg.FechaNac },
        new SqlParameter("@FechaContratacion", SqlDbType.Date) { Value = reg.FechaContratacion },
        new SqlParameter("@CargoId", SqlDbType.Int) { Value = reg.CargoId },
        new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId },
        new SqlParameter("@UsuarioModificacionId", SqlDbType.Int) { Value = reg.UsuarioModificacionId }
    };

            int filas = EjecutarComando("RRHH.SpUpdateEmpleado", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se actualizó ningún registro. Verifique los datos (posible duplicidad de teléfono o email).";
            else if (!string.IsNullOrEmpty(cambios))
                Auditar("ACTUALIZACION", $"Empleado {reg.Nombre} {reg.Apellido} modificado por ID {SesionActual.UsuarioId}: {cambios.TrimEnd(' ', ';')}", SesionActual.UsuarioId);
        }

        // ==================== ELIMINACIÓN LÓGICA (CON AUDITORÍA) ====================
        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            Empleado empleado = ObtenerPorId(id, out pError);
            if (empleado == null) return;

            string nombreCompleto = $"{empleado.Nombre} {empleado.Apellido}";

            // Cambiamos a estado inactivo (2) y asignamos quién modifica
            empleado.EstadoId = 2;
            empleado.UsuarioModificacionId = SesionActual.UsuarioId;

            // Ejecutamos el SP directamente (sin llamar a ActualizarRegistro para evitar doble auditoría)
            SqlParameter[] parametros = {
        new SqlParameter("@EmpleadoId", SqlDbType.Int) { Value = empleado.EmpleadoId },
        new SqlParameter("@Nombre", SqlDbType.NVarChar) { Value = empleado.Nombre },
        new SqlParameter("@Apellido", SqlDbType.NVarChar) { Value = empleado.Apellido },
        new SqlParameter("@Telefono", SqlDbType.NVarChar) { Value = empleado.Telefono ?? (object)DBNull.Value },
        new SqlParameter("@Email", SqlDbType.NVarChar) { Value = empleado.Email ?? (object)DBNull.Value },
        new SqlParameter("@Direccion", SqlDbType.NVarChar) { Value = empleado.Direccion ?? (object)DBNull.Value },
        new SqlParameter("@FechaNac", SqlDbType.Date) { Value = empleado.FechaNac },
        new SqlParameter("@FechaContratacion", SqlDbType.Date) { Value = empleado.FechaContratacion },
        new SqlParameter("@CargoId", SqlDbType.Int) { Value = empleado.CargoId },
        new SqlParameter("@EstadoId", SqlDbType.Int) { Value = empleado.EstadoId },
        new SqlParameter("@UsuarioModificacionId", SqlDbType.Int) { Value = empleado.UsuarioModificacionId }
    };

            int filas = EjecutarComando("RRHH.SpUpdateEmpleado", parametros, out pError);
            if (string.IsNullOrEmpty(pError) && filas > 0)
                Auditar("ELIMINACION LOGICA", $"Empleado desactivado: {nombreCompleto} (ID: {id}) por usuario ID {SesionActual.UsuarioId}", SesionActual.UsuarioId);
            else if (filas == 0 && string.IsNullOrEmpty(pError))
                pError = "No se pudo desactivar el empleado. Verifique los datos.";
        }

        // ==================== BÚSQUEDA Y MÉTODOS AUXILIARES (SIN CAMBIOS) ====================
        public List<Empleado> Buscar(string buscar, out string pError)
        {
            List<Empleado> lista = new List<Empleado>();
            pError = string.Empty;

            SqlParameter[] parametros = {
                new SqlParameter("@Buscar", SqlDbType.NVarChar) { Value = buscar }
            };

            DataTable dt = ObtenerTabla("RRHH.SpSelectEmpleado", parametros, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(MapearEmpleado(row));
            }

            return lista;
        }

        private Empleado MapearEmpleado(DataRow row)
        {
            return new Empleado
            {
                EmpleadoId = Convert.ToInt32(row["EmpleadoId"]),
                Nombre = row["Nombre"].ToString(),
                Apellido = row["Apellido"].ToString(),
                Telefono = row["Telefono"]?.ToString(),
                Email = row["Email"]?.ToString(),
                Direccion = row["Direccion"]?.ToString(),
                FechaNac = Convert.ToDateTime(row["FechaNac"]),
                FechaContratacion = Convert.ToDateTime(row["FechaContratacion"]),
                CargoId = Convert.ToInt32(row["CargoId"]),
                CargoNombre = row["CargoNombre"]?.ToString(),
                EstadoId = Convert.ToInt32(row["EstadoId"]),
                EstadoNombre = row["EstadoNombre"]?.ToString(),
                UsuarioRegistroId = Convert.ToInt32(row["UsuarioRegistroId"]),
                UsuarioModificacionId = row["UsuarioModificacionId"] != DBNull.Value
                                        ? Convert.ToInt32(row["UsuarioModificacionId"])
                                        : 0
            };
        }

        public DataTable ObtenerCargos(out string pError)
        {
            return ObtenerTabla("RRHH.SpSelectAllCargo", null, out pError);
        }

        public DataTable ObtenerEstadosPorEntidad(string entidad, out string pError)
        {
            DataTable dt = ObtenerTabla("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return null;

            DataTable filtrado = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Entidad"].ToString() == entidad)
                    filtrado.ImportRow(row);
            }
            return filtrado;
        }
    }
}