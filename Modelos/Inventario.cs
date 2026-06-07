using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Inventario
    {
        public int InventarioId { get; set; }
        public string NombreProducto { get; set; }
        public string UnidadDeMedida { get; set; }
        public double Cantidad { get; set; }
        public decimal PrecioCosto { get; set; }
        public int TipoInventarioId { get; set; }
        public string TipoInventario { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
        public int UsuarioRegistroId { get; set; }
        public int UsuarioModificacionId { get; set; }
    }
}