using System.ComponentModel.DataAnnotations;

namespace FloristeriaWeb.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del estado es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del estado no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        public List<Orden> Ordenes { get; set; } = new List<Orden>();
    }
}