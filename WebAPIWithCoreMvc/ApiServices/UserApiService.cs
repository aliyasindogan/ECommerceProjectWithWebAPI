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
        private readonly HttpClient _httpClient;

        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AppUserDetailDto>> GetListAsync()
        {
            var response = await _httpClient.GetAsync("Users/GetList");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseSuccess = await response.Content.ReadFromJsonAsync<ApiDataResponse<IEnumerable<AppUserDetailDto>>>();
            return responseSuccess.Data.ToList();
        }
    }
}