using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NoRegistro { get; set; }
        public string NIT { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
    }
}