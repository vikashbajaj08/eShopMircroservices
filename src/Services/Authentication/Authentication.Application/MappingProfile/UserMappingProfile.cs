using Authentication.Domain.Entities;
using AuthService.Application.DTOs;
using AutoMapper;

namespace Authentication.Application.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest=>dest.Roles, opt=>opt.MapFrom(src=>src.Roles.Select(r=>r.Name).ToArray()));
            CreateMap<User, UserRegisterDTO>().ReverseMap();
        }
    }
}
