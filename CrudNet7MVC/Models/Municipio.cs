using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloristeriaWeb.Models
{
    public class Municipio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del municipio es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del municipio no puede exceder los 100 caracteres")]
        [Display(Name = "Municipio")]
        public string Nombre { get; set; }

        // Relación con Departamento
        [Required(ErrorMessage = "Debe seleccionar un departamento")]
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }

        [ForeignKey("DepartamentoId")]
        public Departamento? Departamento { get; set; }

        public List<Orden> Ordenes { get; set; } = new List<Orden>();
    }
}