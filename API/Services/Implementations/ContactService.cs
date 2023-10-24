using AgendaApi.Data;
using AgendaApi.Entities;
using AgendaApi.Models;
using AgendaApi.Services.Interfaces;

namespace AgendaApi.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly AgendaContext _context;

        public ContactService(AgendaContext context)
        {
            _context = context;
        }
        public List<Contact> GetAllByUser(int id)
        {

            return _context.Contacts.Where(c => c.User.Id == id).ToList();
        }

        public void Create(CreateAndUpdateContact dto, int loggedUserId)
        {
            Contact contact = new Contact()
            {
                Email = dto.Email,
                Image = dto.Imagen,
                Number = dto.Telefono,
                Company = dto.Empresa,
                Address = dto.Direccion,
                LastName = dto.Apellido,
                Name = dto.Nombre,
                UserId = loggedUserId,
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(CreateAndUpdateContact dto, int contactId)
        {
            Contact? contact = _context.Contacts.SingleOrDefault(contact => contact.Id == contactId);
            if (contact is not null)
            {
                contact.Email = dto.Email;
                contact.Image = dto.Imagen;
                contact.Number = dto.Telefono;
                contact.Company = dto.Empresa;
                contact.Address = dto.Direccion;
                contact.LastName = dto.Apellido;
                contact.Name = dto.Nombre;
                _context.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
            _context.SaveChanges();
        }
    }
}
