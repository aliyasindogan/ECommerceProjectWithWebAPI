using Core.Utilities.Responses;
using Entities.Dtos.AppUserTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAppUserTypeApiService
    {
        Task<ApiDataResponse<List<AppUserTypeDto>>> GetListAsync();

        Task<ApiDataResponse<List<AppUserTypeDto>>> GetListDetailAsync();
        Task<ApiDataResponse<AppUserTypeDto>> AddAsync(AppUserTypeAddDto userAddDto);
        Task<ApiDataResponse<AppUserTypeDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<AppUserTypeUpdateDto>> UpdateAsync(AppUserTypeUpdateDto appUserUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);

    }
}