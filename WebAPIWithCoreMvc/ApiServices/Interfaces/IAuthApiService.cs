using Core.Utilities.Responses;
using Entities.Dtos.User;
using System.Threading.Tasks;
using Entities.Dtos.Auth;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<AppUserDto>> LoginAsync(LoginDto loginDto);
    }
}