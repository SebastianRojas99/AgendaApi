using AgendaApi.Entities;
using AgendaApi.Models;
using AutoMapper;

namespace AgendaApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateAndUpdateUserDto>();
            CreateMap<GetUserByIdResponse, User>();
        }


    }
}
