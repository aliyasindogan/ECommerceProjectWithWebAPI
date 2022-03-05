using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.User;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDetailDto>();
            CreateMap<UserDetailDto, AppUser>();

            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>();

            CreateMap<AppUser, UserAddDto>();
            CreateMap<UserAddDto, AppUser>();

            CreateMap<AppUser, UserUpdateDto>();
            CreateMap<UserUpdateDto, AppUser>();

            CreateMap<AppUserDto, UserUpdateDto>();
            CreateMap<UserUpdateDto, AppUserDto>();
        }
    }
}