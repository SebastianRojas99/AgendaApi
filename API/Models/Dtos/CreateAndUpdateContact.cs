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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public string Number { get; set; }
        public string? Company { get; set; }
        public User? User;
    }
}
