using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public int DireccionId { get; set; }
        public string DireccionNombre { get; set; }
        public string PuntoReferencia { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
    }
}