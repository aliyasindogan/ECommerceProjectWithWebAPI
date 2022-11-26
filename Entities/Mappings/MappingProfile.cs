using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dtos.AppUsers;

namespace Entities.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUser, AppUserAddDto>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();
            CreateMap<AppUserDto, AppUserUpdateDto>().ReverseMap();
            CreateMap<AppUserDto, AppUserDeleteDto>().ReverseMap();
            CreateMap<AppUserDto, AppUserDetailDto>().ReverseMap();
        }
    }
}