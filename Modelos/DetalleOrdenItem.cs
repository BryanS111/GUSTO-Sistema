namespace Modelos
{
    public class DetalleOrdenItem
    {
        public int? MenuId { get; set; }
        public int? ComboId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal? PorcentajeDescuento { get; set; }
        public string NombreDescuento { get; set; }
        public decimal PrecioConDescuento => PorcentajeDescuento.HasValue
            ? PrecioUnitario - (PrecioUnitario * PorcentajeDescuento.Value / 100)
            : PrecioUnitario;
        public decimal Total => Cantidad * PrecioConDescuento;
    }
}