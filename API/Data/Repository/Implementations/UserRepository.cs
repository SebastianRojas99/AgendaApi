using AgendaApi.Entities;
using AgendaApi.Models;
using AgendaApi.Data;
using AgendaApi.Data.Repository.Interfaces;
using AutoMapper;
using AgendaApi.Models.Enum;

namespace AgendaApi.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private AgendaContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AgendaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }
        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Create(CreateAndUpdateUserDto dto)
        {

            _context.Users.Add(_mapper.Map<User>(dto));
            _context.SaveChanges();
        }

        public void Update(CreateAndUpdateUserDto dto)
        {
            _context.Users.Update(_mapper.Map<User>(dto));
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
            _context.SaveChanges();
        }

        public void Archive(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.State = State.Archived;
                _context.Update(user);
            }
            _context.SaveChanges();
        }
    }
}
