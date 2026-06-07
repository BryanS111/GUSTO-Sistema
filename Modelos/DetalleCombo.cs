namespace Modelos
{
    public class DetalleCombo
    {
        public int DetalleComboId { get; set; }
        public int ComboId { get; set; }
        public int MenuId { get; set; }
        public string MenuNombre { get; set; }
        public int Cantidad { get; set; }
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
    }
}