namespace Modelos
{
    public class Combo
    {
        public int ComboId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
    }
}