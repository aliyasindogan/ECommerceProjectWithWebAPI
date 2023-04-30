using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.PageLanguages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPageLanguageService
    {
        Task<ApiDataResponse<List<PageLanguageDto>>> GetListAsync();
        Task<ApiDataResponse<List<PageLanguageDto>>> GetListDetailAsync();
        Task<ApiDataResponse<PageLanguage>> GetAsync(Expression<Func<PageLanguage, bool>> filter);
        Task<ApiDataResponse<PageLanguageDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<PageLanguageDto>> AddAsync(PageLanguageAddDto pageAddDto);
        Task<ApiDataResponse<PageLanguageUpdateDto>> UpdateAsync(PageLanguageUpdateDto pageUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
    }
}