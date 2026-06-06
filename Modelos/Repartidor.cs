using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Repartidor
    {
        public int RepartidorId { get; set; }
        public int EmpleadoId { get; set; }
        public string EmpleadoNombre { get; set; }
        public string Telefono { get; set; }
        public string NoPlacaMoto { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
    }
}