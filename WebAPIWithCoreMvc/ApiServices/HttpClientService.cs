using Core.Entities;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auths;
using Entities.Dtos.UploadImages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<ApiDataResponse<bool>> DeleteAsync(string url, int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync(url+id);
            string _language = _httpContextAccessor.HttpContext.User.FindFirst("language").Value;
            httpResponseMessage.Headers.Add("Accept-Language", _language);
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiDataResponse<bool>>(data);
            return await Task.FromResult(result);
        }

        public async Task<ApiDataResponse<T>> GetAsync<T>(string url, int id)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            string _language = _httpContextAccessor.HttpContext.User.FindFirst("language").Value;
            httpRequestMessage.Headers.Add("Accept-Language", _language);
            var response = await _httpClient.GetAsync(url + id);
            var result = JsonConvert.DeserializeObject<ApiDataResponse<T>>(await response.Content.ReadAsStringAsync());
            return result;
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

        public async Task<ApiDataResponse<TResponseEntity>> PostAsync<TRequestEntity, TResponseEntity>(string url, TRequestEntity requestEntity, TResponseEntity responseEntity)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync(url, requestEntity);
            string _language = _httpContextAccessor.HttpContext.User.FindFirst("language").Value;
            httpResponseMessage.Headers.Add("Accept-Language", _language);
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiDataResponse<TResponseEntity>>(data);
            return await Task.FromResult(result);
        }

        public async Task<ApiDataResponse<T>> PutAsync<T>(string url, T entity)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url, entity);
            string _language = _httpContextAccessor.HttpContext.User.FindFirst("language").Value;
            httpResponseMessage.Headers.Add("Accept-Language", _language);
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiDataResponse<T>>(data);
            return await Task.FromResult(result);
        }

        public async Task<ApiDataResponse<UploadImageDto>> UploadImageAsync<T>(FileInfo fileInfo)
        {
            byte[] fileContents = File.ReadAllBytes(fileInfo.FullName);
            MultipartFormDataContent multiPartContent = new MultipartFormDataContent();
            ByteArrayContent byteArrayContent = new ByteArrayContent(fileContents);
            byteArrayContent.Headers.Add("Content-Type", "application/octet-stream");
            multiPartContent.Add(byteArrayContent, "\"files\"", string.Format("\"{0}\"", fileInfo.Name));
            HttpResponseMessage response = await _httpClient.PostAsync("UploadImages/AddUploadImage", multiPartContent);
            string data = await response.Content.ReadAsStringAsync();
            var result = await Task.FromResult(JsonConvert.DeserializeObject<ApiDataResponse<UploadImageDto>>(data));
            return result;
        }
    }
}
