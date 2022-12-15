using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Entities.Dtos.AppUsers;
using Entities.Dtos.AppUserTypes;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class AppUserTypeApiService : IAppUserTypeApiService
    {
        private readonly IHttpClientService _httpClientService;

        public AppUserTypeApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<List<AppUserTypeDto>>> GetListAsync()
        {
            return await _httpClientService.GetListAsync<AppUserTypeDto>($"{Constants.AppUserTypes}/{Constants.GetList}");
        }

        public async Task<ApiDataResponse<List<AppUserTypeDto>>> GetListDetailAsync()
        {
            return await _httpClientService.GetListAsync<AppUserTypeDto>($"{Constants.AppUserTypes}/{Constants.GetListDetail}");
        }
        public async Task<ApiDataResponse<AppUserTypeDto>> AddAsync(AppUserTypeAddDto userAddDto)
        {
            return await _httpClientService.PostAsync($"{Constants.AppUserTypes}/{Constants.Add}", userAddDto, new AppUserTypeDto());
        }

        public async Task<ApiDataResponse<AppUserTypeDto>> GetByIdAsync(int id)
        {
            return await _httpClientService.GetAsync<AppUserTypeDto>($"{Constants.AppUserTypes}/{Constants.GetById}/", id);
        }

        public async Task<ApiDataResponse<AppUserTypeUpdateDto>> UpdateAsync(AppUserTypeUpdateDto appUserUpdateDto)
        {
            return await _httpClientService.PutAsync($"{Constants.AppUserTypes}/{Constants.Update}", appUserUpdateDto);
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return await _httpClientService.DeleteAsync($"{Constants.AppUserTypes}/{Constants.Delete}/", id);
        }
    }
}