using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auth;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto);
    }
}