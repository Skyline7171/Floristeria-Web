using System.ComponentModel.DataAnnotations;

namespace FloristeriaWeb.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del departamento es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del departamento no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }

        public List<Municipio> Municipios { get; set; } = new List<Municipio>();
    }
}