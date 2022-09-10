using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IHttpClientService
    {
        Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto);
        Task<ApiDataResponse<List<T>>> GetListAsync<T>(string url);
    }
}
