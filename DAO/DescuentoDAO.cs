using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class DescuentoDAO
    {
        private Conexion _conexion;

        public DescuentoDAO()
        {
            _conexion = new Conexion();
        }

        // Obtener todos los descuentos
        public List<Descuento> ObtenerTodos(out string pError)
        {
            pError = string.Empty;
            DataTable dt = EjecutarReader("VENTA.SpSelectDescuento",
                new SqlParameter[] { new SqlParameter("@Buscar", "") }, out pError);
            if (dt == null) return null;

            List<Descuento> lista = new List<Descuento>();
            foreach (DataRow row in dt.Rows)
                lista.Add(MapearDescuento(row));
            return lista;
        }

        // Buscar descuentos por nombre o ID
        public List<Descuento> Buscar(string buscar, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@Buscar", buscar) };
            DataTable dt = EjecutarReader("VENTA.SpSelectDescuento", parametros, out pError);
            if (dt == null) return null;

            List<Descuento> lista = new List<Descuento>();
            foreach (DataRow row in dt.Rows)
                lista.Add(MapearDescuento(row));
            return lista;
        }

        // Insertar un descuento
        public void Guardar(Descuento d, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@Nombre", d.Nombre),
                new SqlParameter("@Porcentaje", d.Porcentaje),
                new SqlParameter("@TipoDescuentoId", (object)d.TipoDescuentoId ?? DBNull.Value),
                new SqlParameter("@MenuId", (object)d.MenuId ?? DBNull.Value),
                new SqlParameter("@ComboId", (object)d.ComboId ?? DBNull.Value),
                new SqlParameter("@FechaDesde", d.FechaDesde),
                new SqlParameter("@FechaHasta", d.FechaHasta),
                new SqlParameter("@EstadoId", d.EstadoId)
            };
            EjecutarNonQuery("VENTA.SpInsertDescuento", parametros, out pError);
        }

        // Actualizar un descuento
        public void Actualizar(Descuento d, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = {
                new SqlParameter("@DescuentoId", d.DescuentoId),
                new SqlParameter("@Nombre", d.Nombre),
                new SqlParameter("@Porcentaje", d.Porcentaje),
                new SqlParameter("@TipoDescuentoId", (object)d.TipoDescuentoId ?? DBNull.Value),
                new SqlParameter("@MenuId", (object)d.MenuId ?? DBNull.Value),
                new SqlParameter("@ComboId", (object)d.ComboId ?? DBNull.Value),
                new SqlParameter("@FechaDesde", d.FechaDesde),
                new SqlParameter("@FechaHasta", d.FechaHasta),
                new SqlParameter("@EstadoId", d.EstadoId)
            };
            EjecutarNonQuery("VENTA.SpUpdateDescuento", parametros, out pError);
        }

        // Eliminación lógica
        public void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@DescuentoId", id) };
            EjecutarNonQuery("VENTA.SpDeleteLogicoDescuento", parametros, out pError);
        }

        // Combos auxiliares
        public DataTable ObtenerTiposDescuento(out string pError)
        {
            return EjecutarReader("VENTA.SpSelectAllTipoDescuento", null, out pError);
        }

        public DataTable ObtenerMenus(out string pError)
        {
            return EjecutarReader("VENTA.SpSelectAllMenu", null, out pError);
        }

        public DataTable ObtenerCombos(out string pError)
        {
            return EjecutarReader("VENTA.SpSelectAllCombo", null, out pError);
        }

        public DataTable ObtenerEstadosDescuento(out string pError)
        {
            DataTable dt = EjecutarReader("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return null;

            DataTable filtrado = dt.Clone();
            foreach (DataRow row in dt.Rows)
                if (row["Entidad"].ToString() == "DESCUENTO")
                    filtrado.ImportRow(row);
            return filtrado;
        }

        // Métodos internos
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
            catch (Exception ex)
            {
                pError = ex.Message;
                return null;
            }
            finally
            {
                _conexion.CerrarConexion(out _);
            }
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
            catch (Exception ex)
            {
                pError = ex.Message;
                return -1;
            }
            finally
            {
                _conexion.CerrarConexion(out _);
            }
        }

        private Descuento MapearDescuento(DataRow row)
        {
            return new Descuento
            {
                DescuentoId = Convert.ToInt32(row["Id"]),
                Nombre = row["Nombre"].ToString(),
                Porcentaje = Convert.ToDecimal(row["Porcentaje"]),
                TipoDescuentoId = row["TipoDescuentoId"] != DBNull.Value ? Convert.ToInt32(row["TipoDescuentoId"]) : (int?)null,
                TipoDescuento = row["TipoDescuento"]?.ToString(),
                MenuId = row["MenuId"] != DBNull.Value ? Convert.ToInt32(row["MenuId"]) : (int?)null,
                MenuNombre = row["MenuNombre"]?.ToString(),
                ComboId = row["ComboId"] != DBNull.Value ? Convert.ToInt32(row["ComboId"]) : (int?)null,
                ComboNombre = row["ComboNombre"]?.ToString(),
                FechaDesde = Convert.ToDateTime(row["FechaDesde"]),
                FechaHasta = Convert.ToDateTime(row["FechaHasta"]),
                EstadoId = Convert.ToInt32(row["EstadoId"]),
                EstadoNombre = row["EstadoNombre"].ToString()
            };
        }
    }
}