using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloristeriaWeb.Models
{
    public class Flor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la flor es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre de la flor no puede exceder los 100 caracteres")]
        [Display(Name = "Nombre de la Flor")]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; } // Añadido para el catálogo

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 10000, ErrorMessage = "El precio debe estar entre 0.01 y 10000")]
        [Column(TypeName = "decimal(18,2)")] // Precisión para moneda
        [Display(Name = "Precio (C$)")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock inicial es obligatorio")]
        [Range(0, 5000, ErrorMessage = "El stock debe ser un número positivo")]
        [Display(Name = "Inventario/Stock")]
        public int Stock { get; set; }

        [Display(Name = "Imagen")]
        public string? ImagenUrl { get; set; }

        [Display(Name = "¿Está disponible?")]
        public bool Activo { get; set; } = true; // Para ocultar productos sin borrarlos

        [Required(ErrorMessage = "La categoría de la flor es obligatoria")]
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }

        // Relación con los detalles de las órdenes
        public List<DetalleOrden> Detalles { get; set; } = new List<DetalleOrden>();
    }
}