using AgendaApi.Entities;
using AgendaApi.Models;
using AutoMapper;

namespace AgendaApi.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateAndUpdateContact, Contact>();
        }
    }
}
