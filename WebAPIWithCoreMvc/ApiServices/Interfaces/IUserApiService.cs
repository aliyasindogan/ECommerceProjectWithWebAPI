using Core.Utilities.Responses;
using Entities.Dtos.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAppUserApiService
    {
        Task<ApiDataResponse<List<AppUserDto>>> GetListAsync();
        Task<ApiDataResponse<List<AppUserDto>>> GetListDetailAsync();
    }
}