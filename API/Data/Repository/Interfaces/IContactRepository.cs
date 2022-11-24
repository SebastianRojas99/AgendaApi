using AgendaApi.Entities;
using AgendaApi.Models;

namespace AgendaApi.Data.Repository.Interfaces
{
    public interface IContactRepository
    {
        public List<Contact> GetAllByUser(int id);
        public void Create(CreateAndUpdateContact dto, int id);
        public void Update(CreateAndUpdateContact dto);
        public void Delete(int id);
    }
}
