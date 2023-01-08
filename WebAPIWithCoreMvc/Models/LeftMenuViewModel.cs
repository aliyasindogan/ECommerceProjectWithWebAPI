using Entities.Dtos.Pages;
using System.Collections.Generic;

namespace WebAPIWithCoreMvc.Models
{
    public class LeftMenuViewModel
    {
        public List<PageDto> MainPage { get; set; }
        public List<PageDto> ParentPage { get; set; }
    }
}
