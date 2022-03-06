using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.AppUser;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserDetailDto>();
            CreateMap<AppUserDetailDto, AppUser>();

            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>();

            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserAddDto, AppUser>();

            CreateMap<AppUser, AppUserUpdateDto>();
            CreateMap<AppUserUpdateDto, AppUser>();

            CreateMap<AppUserDto, AppUserUpdateDto>();
            CreateMap<AppUserUpdateDto, AppUserDto>();
        }
    }
}