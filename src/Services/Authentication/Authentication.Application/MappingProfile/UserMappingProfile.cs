using Authentication.Domain.Entities;
using AuthService.Application.DTOs;
using AutoMapper;

namespace Authentication.Application.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserRegisterDTO>().ReverseMap();
        }
    }
}
