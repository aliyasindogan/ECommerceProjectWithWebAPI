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

        public async Task<ApiDataResponse<List<PageDto>>> GetListAsync()
        {
            return await _httpClientService.GetListAsync<PageDto>($"{Constants.Pages}/{Constants.GetList}");
        }

        public async Task<ApiDataResponse<List<PageDto>>> GetListDetailAsync()
        {
            return await _httpClientService.GetListAsync<PageDto>($"{Constants.Pages}/{Constants.GetListDetail}");
        }

        public async Task<ApiDataResponse<List<PagePageLanguageDto>>> GetListAdminPanelLeftMenuAsync()
        {
            return await _httpClientService.GetListAsync<PagePageLanguageDto>($"{Constants.Pages}/{"GetListAdminPanelLeftMenu"}");
        }

        public async Task<ApiDataResponse<PageDto>> AddAsync(PageAddDto userAddDto)
        {
            return await _httpClientService.PostAsync($"{Constants.Pages}/{Constants.Add}", userAddDto, new PageDto());
        }

        public async Task<ApiDataResponse<PageDto>> GetByIdAsync(int id)
        {
            return await _httpClientService.GetAsync<PageDto>($"{Constants.Pages}/{Constants.GetById}/", id);
        }

        public async Task<ApiDataResponse<PageUpdateDto>> UpdateAsync(PageUpdateDto pageUpdateDto)
        {
            return await _httpClientService.PutAsync($"{Constants.Pages}/{Constants.Update}", pageUpdateDto);
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return await _httpClientService.DeleteAsync($"{Constants.Pages}/{Constants.Delete}/", id);
        }

    
    }
}