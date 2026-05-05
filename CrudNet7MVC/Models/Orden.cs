using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FloristeriaWeb.Models
{
    public class Orden
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        [Display(Name = "Nombre del destinatario")]
        public string NombreDestinatario { get; set; }

        [Required(ErrorMessage = "El apellido del cliente es obligatorio")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres")]
        [Display(Name = "Apellido del destinatario")]
        public string ApellidoDestinatario { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(256)]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
        public string Email { get; set; }

        [Display(Name = "Fecha de Pedido")]
        [Editable(false)]
        public DateTime FechaOrden { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^[2578]\d{3}-?\d{4}$", ErrorMessage = "Número de teléfono inválido (Ej: 8888-8888)")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El total es obligatorio")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total (C$)")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El estado de pago es obligatorio")]
        [Display(Name = "Estado de Pago")]
        public int EstadoPagoId { get; set; }

        [ForeignKey("EstadoPagoId")]
        public Estado? Estado { get; set; }

        [Required(ErrorMessage = "La dirección de entrega es obligatoria")]
        [StringLength(500, ErrorMessage = "La dirección no puede exceder los 500 caracteres")]
        [Display(Name = "Dirección Exacta")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Por favor, seleccione un municipio")]
        [Display(Name = "Municipio")]
        public int MunicipioId { get; set; }

        [ForeignKey("MunicipioId")]
        public Municipio? Municipio { get; set; }

        [Display(Name = "ID de Transacción PayPal")]
        public string? TransactionId { get; set; }

        public List<DetalleOrden> Detalles { get; set; } = new List<DetalleOrden>();
    }
}