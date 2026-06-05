using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int CargoId { get; set; }
        public int EstadoId { get; set; }
        public int UsuarioRegistroId { get; set; }
        public int UsuarioModificacionId { get; set; }
        public string CargoNombre { get; set; }
        public string EstadoNombre { get; set; }


        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }
        }

        public string EstadoActual
        {
            get { return EstadoId == 1 ? "Activo" : "Inactivo"; }
        }

        public Empleado() { }

        public Empleado(int empleadoId, string nombre, string apellido,
                        string telefono, string email, string direccion,
                        DateTime fechaNac, DateTime fechaContratacion,
                        int cargoId, int estadoId,
                        int usuarioRegistroId, int usuarioModificacionId)
        {
            EmpleadoId = empleadoId;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            FechaNac = fechaNac;
            FechaContratacion = fechaContratacion;
            CargoId = cargoId;
            EstadoId = estadoId;
            UsuarioRegistroId = usuarioRegistroId;
            UsuarioModificacionId = usuarioModificacionId;
        }
    }
}