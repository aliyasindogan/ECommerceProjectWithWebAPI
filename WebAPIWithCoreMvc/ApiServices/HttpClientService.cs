using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class HttpClientService : IHttpClientService
    {
        IHttpContextAccessor _httpContextAccessor;
        HttpClient _httpClient;

        public HttpClientService(IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
        }

        public async Task<ApiDataResponse<List<T>>> GetListAsync<T>(string url)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            string _language = _httpContextAccessor.HttpContext.User.FindFirst("language").Value;
            httpRequestMessage.Headers.Add(Constants.AcceptLangauge, _language);
            var response = await _httpClient.GetAsync(url);
            var result = JsonConvert.DeserializeObject<ApiDataResponse<List<T>>>(await response.Content.ReadAsStringAsync());
            return result;
        }

        public async Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto)
        {
            string _language = String.Empty;
            var dataCookie = _httpContextAccessor.HttpContext.
                Request.Cookies[Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.DefaultCookieName];
            if (dataCookie != null)
            {
                if (dataCookie.Contains("tr"))
                    _language = Constants.LangTR;
                else
                    _language = Constants.LangEN;
                _httpClient.DefaultRequestHeaders.Add(Constants.AcceptLangauge, _language);
            }

            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync("Auth/Login", loginDto);
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiDataResponse<AccessToken>>(data);
            return await Task.FromResult(result);
        }
    }
}
