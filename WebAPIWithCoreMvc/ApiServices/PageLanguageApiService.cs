using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Entities.Dtos.PageLanguages;
using Entities.Dtos.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class PageLanguageApiService : IPageLanguageApiService
    {
        private readonly IHttpClientService _httpClientService;

        public PageLanguageApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<List<PageLanguageDto>>> GetListAsync()
        {
            return await _httpClientService.GetListAsync<PageLanguageDto>($"{Constants.PageLanguages}/{Constants.GetList}");
        }

        public async Task<ApiDataResponse<List<PageLanguageDto>>> GetListDetailAsync()
        {
            return await _httpClientService.GetListAsync<PageLanguageDto>($"{Constants.PageLanguages}/{Constants.GetListDetail}");
        }

        public async Task<ApiDataResponse<PageLanguageDto>> AddAsync(PageLanguageAddDto pageLanguageAddDto)
        {
            throw new System.NotImplementedException();
        }
        public async Task<ApiDataResponse<PageLanguageDto>> GetByIdAsync(int id)
        {
            return await _httpClientService.GetAsync<PageLanguageDto>($"{Constants.PageLanguages}/{Constants.GetById}/", id);
        }

        public async Task<ApiDataResponse<PageLanguageUpdateDto>> UpdateAsync(PageLanguageUpdateDto pageLanguageUpdateDto)
        {
            return await _httpClientService.PutAsync($"{Constants.PageLanguages}/{Constants.Update}", pageLanguageUpdateDto);
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return await _httpClientService.DeleteAsync($"{Constants.PageLanguages}/{Constants.Delete}/", id);
        }

       
    }
}