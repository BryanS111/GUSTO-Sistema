using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class EmpleadoDAO : AbstractDAO<Empleado>
    {
        public override List<Empleado> ObtenerTodos(out string pError)
        {
            List<Empleado> lista = new List<Empleado>();
            pError = string.Empty;

            DataTable dt = ObtenerTabla("RRHH.SpSelectAllEmpleado", null, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
                lista.Add(MapearEmpleado(row));

            return lista;
        }

        public override Empleado ObtenerPorId(int id, out string pError)
        {
            pError = string.Empty;

            List<Empleado> todos = ObtenerTodos(out pError);
            if (todos == null) return null;

            foreach (Empleado empleado in todos)
            {
                if (empleado.EmpleadoId == id)
                    return empleado;
            }

            if (string.IsNullOrEmpty(pError))
                pError = $"No se encontro empleado con ID {id}.";
            return null;
        }

        public override Empleado ObtenerPorId(string id, out string pError)
        {
            if (int.TryParse(id, out int idEntero))
                return ObtenerPorId(idEntero, out pError);

            pError = "El ID proporcionado no es un numero valido.";
            return null;
        }

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
                pError = "No se inserto el empleado. Verifique los datos (posible duplicidad de telefono o email).";
        }

        public override void ActualizarRegistro(Empleado reg, out string pError)
        {
            pError = string.Empty;

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
                pError = "No se actualizo ningun registro. Verifique los datos (posible duplicidad de telefono o email).";
        }

        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            Empleado empleado = ObtenerPorId(id, out pError);
            if (empleado == null) return;

            int idInactivo = ObtenerIdEstado("EMPLEADO", "INACTIVO", out pError);
            if (!string.IsNullOrEmpty(pError)) return;

            empleado.EstadoId = idInactivo;
            empleado.UsuarioModificacionId = SesionActual.UsuarioId;

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
            if (filas == 0 && string.IsNullOrEmpty(pError))
                pError = "No se pudo desactivar el empleado. Verifique los datos.";
        }

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
                lista.Add(MapearEmpleado(row));

            return lista;
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

        private int ObtenerIdEstado(string entidad, string estadoNombre, out string pError)
        {
            pError = string.Empty;
            DataTable dt = ObtenerEstadosPorEntidad(entidad, out pError);
            if (dt == null) return 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Estado"].ToString() == estadoNombre)
                    return Convert.ToInt32(row["Id"]);
            }

            pError = $"No se encontro el estado '{estadoNombre}' para {entidad}.";
            return 0;
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
    }
}
