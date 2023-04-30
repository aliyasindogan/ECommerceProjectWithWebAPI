using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.PagePageLanguages;
using Entities.Dtos.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPageDal : IBaseRepository<Page>
    {
        Task<List<PagePageLanguageDto>> GetListAdminPanelLeftMenuAsync();
        Task<List<PageDto>> GetListDetailAsync();

    }
}