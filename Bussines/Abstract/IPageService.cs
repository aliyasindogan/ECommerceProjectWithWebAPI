using Core.Utilities.Responses;
using Entities.Concrete;
using Entities.Dtos.PagePageLanguages;
using Entities.Dtos.Pages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPageService
    {
        Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListAsync();
        Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListDetailAsync();
        Task<ApiDataResponse<Page>> GetAsync(Expression<Func<Page, bool>> filter);
        Task<ApiDataResponse<PagePageLanguageDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<PagePageLanguageDto>> AddAsync(PageAddDto pageAddDto);
        Task<ApiDataResponse<PageUpdateDto>> UpdateAsync(PageUpdateDto pageUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
        Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListAdminPanelLeftMenuAsync();
    }
}