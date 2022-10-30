using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.AppUsers;
using Entities.Dtos.Auths;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto);
    }
}