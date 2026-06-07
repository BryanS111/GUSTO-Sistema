namespace Modelos
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int? InventarioId { get; set; }
        public string InventarioNombre { get; set; }
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
    }
}