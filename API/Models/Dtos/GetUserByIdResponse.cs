using AgendaApi.Entities;
using AgendaApi.Models.Enum;

namespace AgendaApi.Models
{
    public class GetUserByIdResponse
    {
        /*NOTA IMPORTANTE*/
        /*Los DTOS están en ESPAÑOL porque el front tiene las intefaces
         definidas en ESPAÑOL, esta es una de las ventajas de utilizar DTOs
        para transportar datos desde el back a una capa del front ya que nos permite adaptarnos
        y tener flexibilidad a la hora de responder a las requests*/
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreDeUsuario { get; set; }
        public List<Contact> Contactos { get; set; }
        public State Estado { get; set; }
        public Rol Rol { get; set; }
    }
}
