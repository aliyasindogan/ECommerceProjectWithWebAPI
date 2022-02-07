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

            CreateMap<AppUser, UserDto>();
            CreateMap<UserDto, AppUser>();

            CreateMap<AppUser, UserAddDto>();
            CreateMap<UserAddDto, AppUser>();

            CreateMap<AppUser, UserUpdateDto>();
            CreateMap<UserUpdateDto, AppUser>();

            CreateMap<UserDto, UserUpdateDto>();
            CreateMap<UserUpdateDto, UserDto>();
        }
    }
}