using System.ComponentModel.DataAnnotations;

namespace FloristeriaWeb.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El número de célular es obligatorio")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
