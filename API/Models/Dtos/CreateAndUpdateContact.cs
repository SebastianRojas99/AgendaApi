using AgendaApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Models
{
    public class CreateAndUpdateContact
    {
        /*NOTA IMPORTANTE*/
        /*Los DTOS están en ESPAÑOL porque el front tiene las intefaces
         definidas en ESPAÑOL, esta es una de las ventajas de utilizar DTOs
        para transportar datos desde el back a una capa del front ya que nos permite adaptarnos
        y tener flexibilidad a la hora de responder a las requests*/
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Direccion { get; set; }
        public string Email { get; set; }
        public string? Imagen { get; set; }
        public string Telefono { get; set; }
        public string? Empresa { get; set; }
        public User? User;
    }
}
