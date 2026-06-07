namespace Modelos
{
    public class DetalleOrdenItem
    {
        public int? MenuId { get; set; }
        public int? ComboId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total => Cantidad * PrecioUnitario;
    }
}