using Core.Entities.Concrete;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auths;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto);
        Task<ApiDataResponse<AccessToken>> RegisterAsync(RegisterDto registerDto, string password);
        Task<AccessToken> CreateAccessTokenAsync(User user);
    }
}