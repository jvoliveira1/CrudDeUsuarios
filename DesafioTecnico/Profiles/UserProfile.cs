using AutoMapper;
using DesafioTecnico.Data.Dtos;
using DesafioTecnico.Models;

namespace DesafioTecnico.Profiles
{
    public class UserProfile : Profile 
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReaderUserDto>();
            CreateMap<UpdateUserDto, User>();
        }
    }
    
}
