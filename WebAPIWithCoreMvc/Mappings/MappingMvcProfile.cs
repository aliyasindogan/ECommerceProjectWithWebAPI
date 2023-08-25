using AutoMapper;
using Entities.Dtos.PageLanguages;
using Entities.Dtos.Pages;
using WebAPIWithCoreMvc.Models;

namespace WebAPIWithCoreMvc.Mappings
{
    public class MappingMvcProfile:Profile
    {
        public MappingMvcProfile()
        {
            CreateMap<PageAddViewModel, PageAddDto>().ReverseMap();
            CreateMap<PageAddViewModel, PageLanguageAddDto>().ReverseMap();
        }
    }
}
