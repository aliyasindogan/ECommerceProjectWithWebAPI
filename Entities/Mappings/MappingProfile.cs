using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos.AppUsers;
using Entities.Dtos.AppUserTypes;
using Entities.Dtos.Languages;
using Entities.Dtos.PageLanguages;
using Entities.Dtos.PagePageLanguages;
using Entities.Dtos.Pages;

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

            #region User
            CreateMap<AppUser, User>().ReverseMap();
            #endregion

            #region AppUserType

            CreateMap<AppUserType, AppUserTypeDto>().ReverseMap();
            CreateMap<AppUserType, AppUserTypeAddDto>().ReverseMap();
            CreateMap<AppUserType, AppUserTypeUpdateDto>().ReverseMap();
            CreateMap<AppUserTypeDto, AppUserTypeUpdateDto>().ReverseMap();
            CreateMap<AppUserTypeDto, AppUserTypeDeleteDto>().ReverseMap();
            CreateMap<AppUserTypeDto, AppUserTypeDetailDto>().ReverseMap();
            #endregion

            #region Page
            CreateMap<Page, PageDto>().ReverseMap();
            CreateMap<Page, PageAddDto>().ReverseMap();
            CreateMap<Page, PageUpdateDto>().ReverseMap();
            CreateMap<PagePageLanguageDto, PageUpdateDto>().ReverseMap();
            CreateMap<PagePageLanguageDto, PageDeleteDto>().ReverseMap();
            CreateMap<PagePageLanguageDto, PageDetailDto>().ReverseMap();
            #endregion

            #region PageLanguage
            CreateMap<PageLanguage, PageLanguageDto>().ReverseMap();
            CreateMap<PageLanguage, PageLanguageAddDto>().ReverseMap();
            CreateMap<PageLanguage, PageLanguageUpdateDto>().ReverseMap();
            CreateMap<PageLanguageDto, PageLanguageUpdateDto>().ReverseMap();
            CreateMap<PageLanguageDto, PageLanguageDeleteDto>().ReverseMap();
            CreateMap<PageLanguageDto, PageLanguageDetailDto>().ReverseMap();
            #endregion

            #region Language
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<LanguageDto, LanguageDetailDto>().ReverseMap();
            #endregion
        }
    }
}