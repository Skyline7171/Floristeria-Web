using Microsoft.AspNetCore.Identity;

namespace FloristeriaWeb.Models
{
    public class UsuarioAplicacion : IdentityUser
    {
        [PersonalData]
        public string? NombreCompleto { get; set; }
    }
}