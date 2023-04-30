using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.PageLanguages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPageLanguageDal : IBaseRepository<PageLanguage>
    {
        Task<List<PageLanguageDto>> GetListDetailAsync();

    }
}