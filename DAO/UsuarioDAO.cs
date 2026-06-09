using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class UsuarioDAO : AbstractDAO<Usuario>
    {
        // ==================== LOGIN (SIN CAMBIOS) ====================
        public override Usuario ObtenerPorId(string nombreUsuario, out string pError)
        {
            pError = string.Empty;

            SqlParameter[] parametros = {
                new SqlParameter("@buscar", SqlDbType.VarChar) { Value = nombreUsuario }
            };

            DataTable dt = ObtenerTabla("AUTENTICACION.SpSelectUsuario", parametros, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Usuario"].ToString().Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase))
                {
                    Usuario usuario = new Usuario
                    {
                        UsuarioId = Convert.ToInt32(row["UsuarioId"]),
                        User = row["Usuario"].ToString(),
                        Clave = row["Clave"].ToString(),
                        EmpleadoId = row["EmpleadoId"] != DBNull.Value ? Convert.ToInt32(row["EmpleadoId"]) : 0,
                        IdRol = Convert.ToInt32(row["RolId"]),
                        Rol = row["Rol"].ToString(),
                        EstadoId = Convert.ToInt32(row["EstadoId"]),
                        EstadoNombre = row["EstadoNombre"].ToString()
                    };

                    if (usuario.EstadoNombre != "ACTIVO")
                    {
                        pError = "El usuario está inactivo. Contacte al administrador.";
                        return null;
                    }

                    return usuario;
                }
            }

            pError = "El usuario no existe.";
            return null;
        }

        public override Usuario ObtenerPorId(int id, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@buscar", SqlDbType.VarChar) { Value = id.ToString() }
            };

            DataTable dt = ObtenerTabla("AUTENTICACION.SpSelectUsuario", parametros, out pError);
            if (dt == null || dt.Rows.Count == 0)
            {
                if (string.IsNullOrEmpty(pError)) pError = "No se encontró el usuario.";
                return null;
            }
            return MapearUsuario(dt.Rows[0]);
        }

        public override List<Usuario> ObtenerTodos(out string pError)
        {
            List<Usuario> lista = new List<Usuario>();
            pError = string.Empty;

            DataTable dt = ObtenerTabla("AUTENTICACION.SpSelectAllUsuario", null, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
                lista.Add(MapearUsuario(row));

            return lista;
        }

        // ==================== GUARDAR ====================
        public override void GuardarRegistro(Usuario reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@Usuario", SqlDbType.VarChar) { Value = reg.User },
                new SqlParameter("@Clave", SqlDbType.VarChar) { Value = reg.Clave },
                new SqlParameter("@EmpleadoId", SqlDbType.Int) { Value = reg.EmpleadoId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId },
                new SqlParameter("@RolId", SqlDbType.Int) { Value = reg.IdRol },
                new SqlParameter("@UsuarioRegistroId", SqlDbType.Int) { Value = SesionActual.UsuarioId }
            };
            EjecutarComando("AUTENTICACION.SpInsertUsuario", parametros, out pError);
        }

        // ==================== ACTUALIZAR ====================
        public override void ActualizarRegistro(Usuario reg, out string pError)
        {
            pError = string.Empty;

            SqlParameter[] parametros = {
                new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = reg.UsuarioId },
                new SqlParameter("@Usuario", SqlDbType.VarChar) { Value = reg.User },
                new SqlParameter("@Clave", SqlDbType.VarChar) { Value = reg.Clave },
                new SqlParameter("@EmpleadoId", SqlDbType.Int) { Value = reg.EmpleadoId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId },
                new SqlParameter("@RolId", SqlDbType.Int) { Value = reg.IdRol },
                new SqlParameter("@UsuarioModificacionId", SqlDbType.Int) { Value = SesionActual.UsuarioId }
            };
            int filas = EjecutarComando("AUTENTICACION.SpUpdateUsuario", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se actualizó ningún registro. Verifique que el usuario no esté duplicado.";
        }

        // ==================== ELIMINACIÓN LÓGICA ====================
        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            int idInactivo = ObtenerIdEstado("INACTIVO", out pError);
            if (!string.IsNullOrEmpty(pError)) return;

            SqlParameter[] parametros = {
                new SqlParameter("@UsuarioId", SqlDbType.Int) { Value = id },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = idInactivo },
                new SqlParameter("@UsuarioModificacionId", SqlDbType.Int) { Value = SesionActual.UsuarioId }
            };
            EjecutarComando("AUTENTICACION.SpDeleteLogicoUsuario", parametros, out pError);
        }

        // ==================== RESTO DE MÉTODOS (SIN CAMBIOS) ====================
        public List<Usuario> Buscar(string buscar, out string pError)
        {
            List<Usuario> lista = new List<Usuario>();
            pError = string.Empty;

            SqlParameter[] parametros = {
                new SqlParameter("@buscar", SqlDbType.VarChar) { Value = buscar }
            };
            DataTable dt = ObtenerTabla("AUTENTICACION.SpSelectUsuario", parametros, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
                lista.Add(MapearUsuario(row));

            return lista;
        }

        public DataTable ObtenerEstadosUsuario(out string pError)
        {
            DataTable dt = ObtenerTabla("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return null;

            DataTable filtrado = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Entidad"].ToString() == "USUARIO")
                    filtrado.ImportRow(row);
            }
            return filtrado;
        }

        public DataTable ObtenerRoles(out string pError)
        {
            return ObtenerTabla("AUTENTICACION.SpSelectAllRol", null, out pError);
        }

        private int ObtenerIdEstado(string estadoNombre, out string pError)
        {
            pError = string.Empty;
            DataTable dt = ObtenerEstadosUsuario(out pError);
            if (dt == null) return 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Estado"].ToString() == estadoNombre)
                    return Convert.ToInt32(row["Id"]);
            }
            pError = $"No se encontró el estado '{estadoNombre}' para USUARIO.";
            return 0;
        }

        private Usuario MapearUsuario(DataRow row)
        {
            return new Usuario
            {
                UsuarioId = Convert.ToInt32(row["UsuarioId"]),
                User = row["Usuario"].ToString(),
                Clave = row["Clave"].ToString(),
                EmpleadoId = row["EmpleadoId"] != DBNull.Value ? Convert.ToInt32(row["EmpleadoId"]) : 0,
                EmpleadoNombre = row["EmpleadoNombre"]?.ToString(),
                IdRol = Convert.ToInt32(row["RolId"]),
                Rol = row["Rol"]?.ToString(),
                EstadoId = Convert.ToInt32(row["EstadoId"]),
                EstadoNombre = row["EstadoNombre"]?.ToString(),
                UsuarioRegistroId = row["UsuarioRegistroId"] != DBNull.Value ? Convert.ToInt32(row["UsuarioRegistroId"]) : 0,
                UsuarioModificacionId = row["UsuarioModificiacionId"] != DBNull.Value
                    ? Convert.ToInt32(row["UsuarioModificiacionId"]) : 0
            };
        }
    }
}
