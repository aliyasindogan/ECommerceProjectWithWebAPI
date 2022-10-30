using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dtos.AppUsers;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserDto>().ReverseMap();

            CreateMap<AppUser, AppUserAddDto>().ReverseMap();

            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();

            CreateMap<AppUserDto, AppUserUpdateDto>().ReverseMap();
        }
    }
}