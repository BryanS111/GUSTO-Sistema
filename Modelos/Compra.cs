
using System;
using System.Collections.Generic;

namespace Modelos
{
    public class Compra
    {
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public string NoDocumento { get; set; }
        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public decimal Total { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
    }

    public class DetalleCompraItem
    {
        public int InventarioId { get; set; }
        public string Producto { get; set; }
        public double Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal TotalDetalle { get; set; }
    }
}