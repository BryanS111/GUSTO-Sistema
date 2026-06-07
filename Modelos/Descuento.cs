using System;

public class Descuento
{
    public int DescuentoId { get; set; }
    public string Nombre { get; set; }
    public decimal Porcentaje { get; set; }
    public int? TipoDescuentoId { get; set; }
    public string TipoDescuento { get; set; }
    public int? MenuId { get; set; }
    public string MenuNombre { get; set; }
    public int? ComboId { get; set; }
    public string ComboNombre { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
    public int EstadoId { get; set; }
    public string EstadoNombre { get; set; }
}