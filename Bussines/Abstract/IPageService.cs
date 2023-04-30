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
        Task<ApiDataResponse<List<PageDto>>> GetListAsync();
        Task<ApiDataResponse<List<PageDto>>> GetListDetailAsync();
        Task<ApiDataResponse<Page>> GetAsync(Expression<Func<Page, bool>> filter);
        Task<ApiDataResponse<PageDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<PageDto>> AddAsync(PageAddDto pageAddDto);
        Task<ApiDataResponse<PageUpdateDto>> UpdateAsync(PageUpdateDto pageUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
        Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListAdminPanelLeftMenuAsync();
    }
}