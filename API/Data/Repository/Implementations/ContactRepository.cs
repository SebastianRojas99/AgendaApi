using AgendaApi.Data.Repository.Interfaces;
using AgendaApi.Entities;
using AgendaApi.Models;
using AutoMapper;

namespace AgendaApi.Data.Repository.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly AgendaContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(AgendaContext context, IMapper autoMapper)
        {
            _context = context;
            _mapper = autoMapper;
        }
        public List<Contact> GetAllByUser(int id)
        {

            return _context.Contacts.Where(c => c.User.Id == id).ToList();
        }

        public void Create(CreateAndUpdateContact dto, int id)
        {
            Contact contact = _mapper.Map<Contact>(dto);
            contact.UserId = id;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(CreateAndUpdateContact dto)
        {
            _context.Contacts.Update(_mapper.Map<Contact>(dto));
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Single(c => c.Id == id));
            _context.SaveChanges();
        }
    }
}
