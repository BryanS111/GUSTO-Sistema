namespace Modelos
{
    public class Direccion
    {
        public int DireccionId { get; set; }
        public int MunicipioId { get; set; }
        public string MunicipioNombre { get; set; }
        public string ColoniaBarrio { get; set; }
        public string NoCasa { get; set; }
        public string PuntoReferencia { get; set; }
        public string CoordenadasMaps { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
    }
}