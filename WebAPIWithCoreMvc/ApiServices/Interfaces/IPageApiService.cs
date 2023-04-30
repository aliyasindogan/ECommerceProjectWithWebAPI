using Core.Utilities.Responses;
using Entities.Dtos.PagePageLanguages;
using Entities.Dtos.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IPageApiService
    {
        Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListAsync();
        Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListDetailAsync();
        Task<ApiDataResponse<PagePageLanguageDto>> AddAsync(PageAddDto pageAddDto);
        Task<ApiDataResponse<PagePageLanguageDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<PageUpdateDto>> UpdateAsync(PageUpdateDto pageUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
        Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListAdminPanelLeftMenuAsync();
    }
}