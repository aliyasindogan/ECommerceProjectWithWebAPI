using Core.Utilities.Responses;
using Entities.Dtos.AppUsers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAppUserApiService
    {
        Task<ApiDataResponse<List<AppUserDto>>> GetListAsync();
        Task<ApiDataResponse<List<AppUserDto>>> GetListDetailAsync();
        Task<ApiDataResponse<AppUserDto>> AddAsync(AppUserAddDto userAddDto);
        Task<ApiDataResponse<AppUserDto>> GetByIdAsync(int id);
        Task<ApiDataResponse<AppUserUpdateDto>> UpdateAsync(AppUserUpdateDto appUserUpdateDto);
        Task<ApiDataResponse<bool>> DeleteAsync(int id);

    }
}