namespace Modelos
{
    public class DetalleProduccionItem
    {
        public int InventarioId { get; set; }
        public string Producto { get; set; }
        public double Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal Total => (decimal)Cantidad * CostoUnitario;
    }
}