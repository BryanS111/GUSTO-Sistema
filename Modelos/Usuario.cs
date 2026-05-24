using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        string _user;
        string _clave;
        int _idEmpleado;
        int _idRol;

        public string User { get => _user; set => _user = value; }
        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public int IdRol { get => _idRol; set => _idRol = value; }
    }
}
