using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Core.Utilities.Responses;
using Entities.Dtos.Auth;
using Entities.Dtos.User;
using Newtonsoft.Json;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class AuthApiService : IAuthApiService
    {
        private readonly HttpClient _httpClient;

        public AuthApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("Auth/Login", loginDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var data = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiDataResponse<UserDto>>(data);
                return await Task.FromResult(result);
            }
            return null;
        }
    }
}