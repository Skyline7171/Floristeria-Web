namespace FloristeriaWeb.Models
{
    public class ElementoCarrito
    {
        public int FlorId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string? ImagenUrl { get; set; }
        public decimal Importe => Precio * Cantidad; // Propiedad calculada
    }
}