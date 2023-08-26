using AutoMapper;
using Entities.Dtos.AppUsers;
using Entities.Dtos.AppUserTypes;
using Entities.Dtos.PageLanguages;
using Entities.Dtos.Pages;
using WebAPIWithCoreMvc.Models;

namespace WebAPIWithCoreMvc.Mappings
{
    public class MappingMvcProfile:Profile
    {
        public MappingMvcProfile()
        {
            #region Page
            CreateMap<PageAddViewModel, PageAddDto>().ReverseMap();
            CreateMap<PageAddViewModel, PageLanguageAddDto>().ReverseMap(); 
            #endregion

            #region AppUser
            CreateMap<AppUserAddViewModel, AppUserAddDto>().ReverseMap();
            CreateMap<AppUserDeleteViewModel, AppUserDeleteDto>().ReverseMap();
            CreateMap<AppUserUpdateViewModel, AppUserUpdateDto>().ReverseMap();
            CreateMap<AppUserDetailViewModel, AppUserDetailDto>().ReverseMap();
            CreateMap<AppUserListViewModel, AppUserDto>().ReverseMap();
            #endregion

            #region AppUserType
            CreateMap<AppUserTypeAddViewModel, AppUserTypeAddDto>().ReverseMap();
            CreateMap<AppUserTypeDeleteViewModel, AppUserTypeDeleteDto>().ReverseMap();
            CreateMap<AppUserTypeUpdateViewModel, AppUserTypeUpdateDto>().ReverseMap();
            CreateMap<AppUserTypeDetailViewModel, AppUserTypeDetailDto>().ReverseMap();
            CreateMap<AppUserTypeListViewModel, AppUserTypeDto>().ReverseMap();
            #endregion
        }
    }
}
