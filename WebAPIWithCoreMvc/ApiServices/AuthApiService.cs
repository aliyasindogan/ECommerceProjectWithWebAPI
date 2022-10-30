using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auths;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class AuthApiService : IAuthApiService
    {
        private readonly IHttpClientService _httpClientService;

        public AuthApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto)
        {
            return await _httpClientService.LoginAsync(loginDto);
        }
    }
}