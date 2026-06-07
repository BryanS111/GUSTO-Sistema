using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos;

namespace DAO
{
    public class InventarioDAO : AbstractDAO<Inventario>
    {
        // Métodos abstractos que no usamos directamente pero deben existir
        public override List<Inventario> ObtenerTodos(out string pError)
        {
            List<Inventario> lista = new List<Inventario>();
            pError = string.Empty;

            DataTable dt = ObtenerTabla("COMPRA.SpSelectAllInventario", null, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
                lista.Add(MapearInventario(row));
            return lista;
        }

        public override Inventario ObtenerPorId(int id, out string pError)
        {
            pError = "No implementado.";
            return null;
        }

        public override Inventario ObtenerPorId(string id, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@Buscar", SqlDbType.VarChar) { Value = id } };
            DataTable dt = ObtenerTabla("COMPRA.SpSelectInventarioNombre", parametros, out pError);
            if (dt == null || dt.Rows.Count == 0) return null;
            return MapearInventario(dt.Rows[0]);
        }

        // NUEVA VERSIÓN de GuardarRegistro (no override, recibe usuarioId)
        public void GuardarRegistro(Inventario reg, int usuarioId, out string pError)
        {
            pError = string.Empty;
            if (usuarioId == 0)
            {
                pError = "No hay sesión de usuario activa.";
                return;
            }

            SqlParameter[] parametros = {
                new SqlParameter("@NombreProducto", SqlDbType.VarChar) { Value = reg.NombreProducto },
                new SqlParameter("@UnidadDeMedida", SqlDbType.VarChar) { Value = reg.UnidadDeMedida },
                new SqlParameter("@Cantidad", SqlDbType.Float) { Value = reg.Cantidad },
                new SqlParameter("@PrecioCosto", SqlDbType.Decimal) { Value = reg.PrecioCosto },
                new SqlParameter("@TipoInventarioId", SqlDbType.Int) { Value = reg.TipoInventarioId },
                new SqlParameter("@UsuarioRegistroId", SqlDbType.Int) { Value = usuarioId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            EjecutarComando("COMPRA.SpInsertInventario", parametros, out pError);
        }

        // NUEVA VERSIÓN de ActualizarRegistro (no override, recibe usuarioId)
        public void ActualizarRegistro(Inventario reg, int usuarioId, out string pError)
        {
            pError = string.Empty;
            if (usuarioId == 0)
            {
                pError = "No hay sesión de usuario activa.";
                return;
            }

            SqlParameter[] parametros = {
                new SqlParameter("@InventarioId", SqlDbType.Int) { Value = reg.InventarioId },
                new SqlParameter("@NombreProducto", SqlDbType.VarChar) { Value = reg.NombreProducto },
                new SqlParameter("@UnidadDeMedida", SqlDbType.VarChar) { Value = reg.UnidadDeMedida },
                new SqlParameter("@Cantidad", SqlDbType.Float) { Value = reg.Cantidad },
                new SqlParameter("@PrecioCosto", SqlDbType.Decimal) { Value = reg.PrecioCosto },
                new SqlParameter("@TipoInventarioId", SqlDbType.Int) { Value = reg.TipoInventarioId },
                new SqlParameter("@UsuarioModificacionId", SqlDbType.Int) { Value = usuarioId },
                new SqlParameter("@EstadoId", SqlDbType.Int) { Value = reg.EstadoId }
            };
            int filas = EjecutarComando("COMPRA.SpUpdateInventario", parametros, out pError);
            if (!string.IsNullOrEmpty(pError)) return;
            if (filas == 0)
                pError = "No se actualizó el registro. Verifique los datos.";
        }

        public override void EliminarLogico(int id, out string pError)
        {
            pError = string.Empty;
            SqlParameter[] parametros = { new SqlParameter("@InventarioId", SqlDbType.Int) { Value = id } };
            EjecutarComando("COMPRA.SpDeleteLogicoInventario", parametros, out pError);
        }

        public List<Inventario> Buscar(string buscar, out string pError)
        {
            List<Inventario> lista = new List<Inventario>();
            pError = string.Empty;

            SqlParameter[] parametros = { new SqlParameter("@Buscar", SqlDbType.VarChar) { Value = buscar } };
            DataTable dt = ObtenerTabla("COMPRA.SpSelectInventarioNombre", parametros, out pError);
            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
                lista.Add(MapearInventario(row));
            return lista;
        }

        public DataTable ObtenerTiposInventario(out string pError)
        {
            return ObtenerTabla("COMPRA.SpSelectAllTipoInventario", null, out pError);
        }

        public DataTable ObtenerEstadosInventario(out string pError)
        {
            DataTable dt = ObtenerTabla("GLOBAL.SpSelectAllEstado", null, out pError);
            if (dt == null) return null;

            DataTable filtrado = dt.Clone();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Entidad"].ToString() == "INVENTARIO")
                    filtrado.ImportRow(row);
            }
            return filtrado;
        }

        // Los métodos originales de AbstractDAO no se implementan (se lanza excepción si se llaman)
        public override void GuardarRegistro(Inventario reg, out string pError)
        {
            throw new NotImplementedException("Usar la versión con parámetro usuarioId.");
        }

        public override void ActualizarRegistro(Inventario reg, out string pError)
        {
            throw new NotImplementedException("Usar la versión con parámetro usuarioId.");
        }

        private Inventario MapearInventario(DataRow row)
        {
            return new Inventario
            {
                InventarioId = Convert.ToInt32(row["Codigo"]),
                NombreProducto = row["Producto"].ToString(),
                UnidadDeMedida = row["Unidad de Medida"].ToString(),
                Cantidad = Convert.ToDouble(row["Cantidad"]),
                PrecioCosto = Convert.ToDecimal(row["Precio Costo"]),
                TipoInventario = row["Tipo Inventario"].ToString(),
                EstadoId = Convert.ToInt32(row["EstadoId"]),
                EstadoNombre = row["EstadoNombre"].ToString()
            };
        }
    }
}