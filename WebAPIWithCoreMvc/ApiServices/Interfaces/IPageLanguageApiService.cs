using Core.Utilities.Responses;
using Entities.Dtos.PageLanguages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IPageLanguageApiService
    {
        Task<ApiDataResponse<List<PageLanguageDto>>> GetListAsync();
        Task<ApiDataResponse<List<PageLanguageDto>>> GetListDetailAsync();
        Task<ApiDataResponse<PageLanguageDto>> AddAsync(PageLanguageAddDto pageLanguageAddDto);
        Task<ApiDataResponse<PageLanguageDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<PageLanguageUpdateDto>> UpdateAsync(PageLanguageUpdateDto pageLanguageUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);
    }
}