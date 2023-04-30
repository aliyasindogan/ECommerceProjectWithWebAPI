using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Entities.Dtos.AppUsers;
using Entities.Dtos.AppUserTypes;
using Entities.Dtos.PagePageLanguages;
using Entities.Dtos.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class PageApiService : IPageApiService
    {
        private readonly IHttpClientService _httpClientService;

        public PageApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListAsync()
        {
            return await _httpClientService.GetListAsync<PagePageLanguageDto>($"{Constants.Pages}/{Constants.GetList}");
        }

        public async Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListDetailAsync()
        {
            return await _httpClientService.GetListAsync<PagePageLanguageDto>($"{Constants.Pages}/{Constants.GetListDetail}");
        }

        public async Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListAdminPanelLeftMenuAsync()
        {
            return await _httpClientService.GetListAsync<PagePageLanguageDto>($"{Constants.Pages}/{"GetListAdminPanelLeftMenu"}");
        }

        public async Task<ApiDataResponse<PagePageLanguageDto>> AddAsync(PageAddDto userAddDto)
        {
            return await _httpClientService.PostAsync($"{Constants.Pages}/{Constants.Add}", userAddDto, new PagePageLanguageDto());
        }

        public async Task<ApiDataResponse<PagePageLanguageDto>> GetByIdAsync(int id)
        {
            return await _httpClientService.GetAsync<PagePageLanguageDto>($"{Constants.Pages}/{Constants.GetById}/", id);
        }

        public async Task<ApiDataResponse<PageUpdateDto>> UpdateAsync(PageUpdateDto appUserUpdateDto)
        {
            return await _httpClientService.PutAsync($"{Constants.Pages}/{Constants.Update}", appUserUpdateDto);
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return await _httpClientService.DeleteAsync($"{Constants.Pages}/{Constants.Delete}/", id);
        }

    
    }
}