using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? NombreDeUsuario { get; set; }
        [Required]
        public string? Contrasenia { get; set; }
    }
}
