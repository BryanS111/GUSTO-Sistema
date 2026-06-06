
namespace Modelos
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string User { get; set; }
        public string Clave { get; set; }
        public int EmpleadoId { get; set; }
        public string EmpleadoNombre { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
        public int UsuarioRegistroId { get; set; }
        public int UsuarioModificacionId { get; set; }
    }
}
