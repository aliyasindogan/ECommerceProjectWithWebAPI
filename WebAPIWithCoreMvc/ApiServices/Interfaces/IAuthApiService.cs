using Core.Utilities.Responses;
using Entities.Dtos.AppUser;
using Entities.Dtos.Auth;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<AppUserDto>> LoginAsync(LoginDto loginDto);
    }
}