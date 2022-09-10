using Core.Utilities.Responses;
using Entities.Dtos.AppUser;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class UserApiService : IUserApiService
    {
        private readonly IHttpClientService _httpClientService;

        public UserApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<List<AppUserDetailDto>>> GetListAsync()
        {
            return await _httpClientService.GetListAsync<AppUserDetailDto>("AppUsers/GetList");
        }
    }
}