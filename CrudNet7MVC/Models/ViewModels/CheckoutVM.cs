using System.ComponentModel.DataAnnotations;

namespace FloristeriaWeb.Models.ViewModels
{
    public class CheckoutVM
    {
        // Datos del Cliente
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string NombreCliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^[2578]\d{3}-?\d{4}$", ErrorMessage = "Número de teléfono inválido (Ej: 8888-8888)")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección exacta es necesaria para la entrega")]
        public string Direccion { get; set; } = string.Empty;

        // Ubicación
        [Required(ErrorMessage = "Seleccione un departamento")]
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "Seleccione un municipio")]
        public int MunicipioId { get; set; }

        // Totales (Solo lectura para la vista)
        public decimal Total { get; set; }
    }
}