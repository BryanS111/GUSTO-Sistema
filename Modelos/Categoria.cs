using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
    }
}