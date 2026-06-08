using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class MenuComboDAO
    {
        private Conexion _conexion;

        public MenuComboDAO()
        {
            _conexion = new Conexion();
        }

        // ==================== MENÚ ====================
        public List<Menu> ObtenerTodosMenus(out string pError)
        {
            List<Menu> lista = new List<Menu>();
            pError = string.Empty;
            DataTable dt = EjecutarReader("VENTA.SpSelectAllMenu", null, out pError);
            if (dt == null) return null;
            foreach (DataRow row in dt.Rows)
                lista.Add(MapearMenu(row));
            return lista;
        }

        public List<Menu> BuscarMenus(string buscar, out string pError)
        {
            List<Menu> lista = new List<Menu>();
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@Buscar", SqlDbType.VarChar) { Value = buscar } };
            DataTable dt = EjecutarReader("VENTA.SpSelectMenu", parametros, out pError);
            if (dt == null) return null;
            foreach (DataRow row in dt.Rows)
                lista.Add(MapearMenu(row));
            return lista;
        }

        public void GuardarMenu(Menu reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@Precio", SqlDbType.Decimal) { Value = reg.Precio },
                new SqlParameter("@InventarioId", SqlDbType.Int) { Value = reg.InventarioId ?? (object)DBNull.Value },
                new SqlParameter("@CategoriaId", SqlDbType.Int) { Value = reg.CategoriaId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            EjecutarNonQuery("VENTA.SpInsertMenu", parametros, out pError);
        }

        public void ActualizarMenu(Menu reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@MenuId", SqlDbType.Int) { Value = reg.MenuId },
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@Precio", SqlDbType.Decimal) { Value = reg.Precio },
                new SqlParameter("@InventarioId", SqlDbType.Int) { Value = reg.InventarioId ?? (object)DBNull.Value },
                new SqlParameter("@CategoriaId", SqlDbType.Int) { Value = reg.CategoriaId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            EjecutarNonQuery("VENTA.SpUpdateMenu", parametros, out pError);
        }

        public void EliminarLogicoMenu(int menuId, out string pError)
        {
            pError = string.Empty;
            // Obtener ID del estado 'NO DISPONIBLE' para MENU
            int idNoDisponible = ObtenerIdEstado("MENU", "NO DISPONIBLE", out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            SqlParameter[] parametros = {
                new SqlParameter("@MenuId", SqlDbType.Int) { Value = menuId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = idNoDisponible }
            };
            EjecutarNonQuery("VENTA.SpDesactivarMenu", parametros, out pError);
        }

        // ==================== COMBO ====================
        public List<Combo> ObtenerTodosCombos(out string pError)
        {
            List<Combo> lista = new List<Combo>();
            pError = string.Empty;
            DataTable dt = EjecutarReader("VENTA.SpSelectAllCombo", null, out pError);
            if (dt == null) return null;
            foreach (DataRow row in dt.Rows)
                lista.Add(MapearCombo(row));
            return lista;
        }

        public List<Combo> BuscarCombos(string buscar, out string pError)
        {
            List<Combo> lista = new List<Combo>();
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@Buscar", SqlDbType.VarChar) { Value = buscar } };
            DataTable dt = EjecutarReader("VENTA.SpSelectCombo", parametros, out pError);
            if (dt == null) return null;
            foreach (DataRow row in dt.Rows)
                lista.Add(MapearCombo(row));
            return lista;
        }

        public void GuardarCombo(Combo reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = reg.Descripcion ?? "" },
                new SqlParameter("@Precio", SqlDbType.Decimal) { Value = reg.Precio },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId },
                new SqlParameter("@CategoriaId", SqlDbType.Int) { Value = reg.CategoriaId }
            };
            EjecutarNonQuery("VENTA.SpInsertCombo", parametros, out pError);
        }

        public void ActualizarCombo(Combo reg, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@ComboId", SqlDbType.Int) { Value = reg.ComboId },
                new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = reg.Nombre },
                new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = reg.Descripcion ?? "" },
                new SqlParameter("@Precio", SqlDbType.Decimal) { Value = reg.Precio },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId },
                new SqlParameter("@CategoriaId", SqlDbType.Int) { Value = reg.CategoriaId }
            };
            EjecutarNonQuery("VENTA.SpUpdateCombo", parametros, out pError);
        }

        public void EliminarLogicoCombo(int comboId, out string pError)
        {
            pError = string.Empty;
            int idNoDisponible = ObtenerIdEstado("COMBO", "NO DISPONIBLE", out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            SqlParameter[] parametros = {
                new SqlParameter("@ComboId", SqlDbType.Int) { Value = comboId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = idNoDisponible }
            };
            EjecutarNonQuery("VENTA.SpDesactivarCombo", parametros, out pError);
        }

        // ==================== DETALLE COMBO ====================
        public List<DetalleCombo> ObtenerDetalleCombo(int comboId, out string pError)
        {
            List<DetalleCombo> lista = new List<DetalleCombo>();
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@ComboId", SqlDbType.Int) { Value = comboId } };
            DataTable dt = EjecutarReader("VENTA.SpSelectDetCombo", parametros, out pError);
            if (dt == null) return null;
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new DetalleCombo
                {
                    DetalleComboId = Convert.ToInt32(row["Id"]),
                    MenuNombre = row["Menu"].ToString(),
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    Categoria = row["Categoria"].ToString()
                });
            }
            return lista;
        }

        public void AgregarDetalleCombo(int comboId, int menuId, int cantidad, int categoriaId, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@ComboId", SqlDbType.Int) { Value = comboId },
                new SqlParameter("@IdMenu", SqlDbType.Int) { Value = menuId },
                new SqlParameter("@Cantidad", SqlDbType.Int) { Value = cantidad },
                new SqlParameter("@CategoriaId", SqlDbType.Int) { Value = categoriaId }
            };
            EjecutarNonQuery("VENTA.SpInsertDetCombo", parametros, out pError);
        }

        public void QuitarDetalleCombo(int detalleComboId, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@DetalleComboId", SqlDbType.Int) { Value = detalleComboId } };
            EjecutarNonQuery("VENTA.SpDeleteDetCombo", parametros, out pError);
        }

        // ==================== COMBOS PARA EL FORMULARIO ====================
        public DataTable ObtenerCategorias(out string pError)
        {
            return EjecutarReader("VENTA.SpSelectAllCategoria", null, out pError);
        }

        public DataTable ObtenerEstados(string entidad, out string pError)
        {
            DataTable dt = EjecutarReader("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return null;
            DataTable filtrado = dt.Clone();
            foreach (DataRow row in dt.Rows)
                if (row["Entidad"].ToString() == entidad)
                    filtrado.ImportRow(row);
            return filtrado;
        }

        public DataTable ObtenerInventarios(out string pError)
        {
            return EjecutarReader("COMPRA.SpSelectAllInventario", null, out pError);
        }

        // ==================== MÉTODOS PRIVADOS ====================
        private DataTable EjecutarReader(string sp, SqlParameter[] parametros, out string pError)
        {
            pError = string.Empty;
            DataTable dt = new DataTable();
            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null) return null;
            try
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);
                }
            }
            catch (Exception ex) { pError = ex.Message; return null; }
            finally { _conexion.CerrarConexion(out _); }
            return dt;
        }

        private int EjecutarNonQuery(string sp, SqlParameter[] parametros, out string pError)
        {
            pError = string.Empty;
            SqlConnection conn = _conexion.AbrirConexion(out pError);
            if (conn == null) return -1;
            try
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parametros != null)
                        cmd.Parameters.AddRange(parametros);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { pError = ex.Message; return -1; }
            finally { _conexion.CerrarConexion(out _); }
        }

        private int ObtenerIdEstado(string entidad, string estado, out string pError)
        {
            pError = string.Empty;
            DataTable dt = ObtenerEstados(entidad, out pError);
            if (dt == null) return 0;
            foreach (DataRow row in dt.Rows)
                if (row["Estado"].ToString() == estado)
                    return Convert.ToInt32(row["Id"]);
            pError = $"No se encontró el estado '{estado}' para {entidad}.";
            return 0;
        }

        private Menu MapearMenu(DataRow row)
        {
            return new Menu
            {
                MenuId = Convert.ToInt32(row["MenuId"]),
                Nombre = row["Nombre"].ToString(),
                Precio = Convert.ToDecimal(row["Precio"]),
                InventarioId = row["InventarioId"] != DBNull.Value ? Convert.ToInt32(row["InventarioId"]) : (int?)null,
                InventarioNombre = row["InventarioNombre"].ToString(),
                Stock = row["Stock"] != DBNull.Value ? Convert.ToDouble(row["Stock"]) : 0,  // ← NUEVA LÍNEA
                CategoriaId = Convert.ToInt32(row["CategoriaId"]),
                Categoria = row["Categoria"].ToString(),
                EstadoId = Convert.ToInt32(row["EstadoId"]),
                EstadoNombre = row["EstadoNombre"].ToString()
            };
        }

        private Combo MapearCombo(DataRow row)
        {
            return new Combo
            {
                ComboId = Convert.ToInt32(row["ComboId"]),
                Nombre = row["Nombre"].ToString(),
                Descripcion = row["Descripcion"]?.ToString(),
                Precio = Convert.ToDecimal(row["Precio"]),
                CategoriaId = Convert.ToInt32(row["CategoriaId"]),
                Categoria = row["Categoria"].ToString(),
                EstadoId = Convert.ToInt32(row["EstadoId"]),
                EstadoNombre = row["EstadoNombre"].ToString()
            };
        }
    }
}