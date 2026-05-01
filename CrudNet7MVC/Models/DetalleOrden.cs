using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloristeriaWeb.Models
{
    public class DetalleOrden
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrdenId { get; set; }
        [ForeignKey("OrdenId")]
        public Orden? Orden { get; set; }

        [Required]
        public int FlorId { get; set; }
        [ForeignKey("FlorId")]
        public Flor? Flor { get; set; }

        [Range(1, 1000, ErrorMessage = "La cantidad debe estar entre 1 y 1000")]
        public int Cantidad { get; set; } // Cambiado a int por lógica de unidades

        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; } // Para guardar el precio en el momento de la compra

        // Propiedad calculada (no se guarda en la DB)
        [NotMapped]
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}