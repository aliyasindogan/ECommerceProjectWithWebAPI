using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dtos.AppUsers;
using Entities.Dtos.AppUserTypes;

namespace Entities.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region AppUser
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUser, AppUserAddDto>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();
            CreateMap<AppUserDto, AppUserUpdateDto>().ReverseMap();
            CreateMap<AppUserDto, AppUserDeleteDto>().ReverseMap();
            CreateMap<AppUserDto, AppUserDetailDto>().ReverseMap(); 
            #endregion

            #region AppUserType

            CreateMap<AppUserType, AppUserTypeDto>().ReverseMap();
            CreateMap<AppUserType, AppUserTypeAddDto>().ReverseMap();
            CreateMap<AppUserType, AppUserTypeUpdateDto>().ReverseMap();
            CreateMap<AppUserTypeDto, AppUserTypeUpdateDto>().ReverseMap();
            CreateMap<AppUserTypeDto, AppUserTypeDeleteDto>().ReverseMap();
            CreateMap<AppUserTypeDto, AppUserTypeDetailDto>().ReverseMap(); 
            #endregion
        }
    }
}