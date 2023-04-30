using Entities.Dtos.PagePageLanguages;
using Entities.Dtos.Pages;
using System.Collections.Generic;

namespace WebAPIWithCoreMvc.Models
{
    public class LeftMenuViewModel
    {
        public List<PagePageLanguageDto> MainPage { get; set; }
        public List<PagePageLanguageDto> ParentPage { get; set; }
    }
}
