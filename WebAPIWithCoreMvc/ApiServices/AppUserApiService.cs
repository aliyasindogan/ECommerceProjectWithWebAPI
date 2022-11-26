using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Entities.Dtos.AppUsers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class AppUserApiService : IAppUserApiService
    {
        private readonly IHttpClientService _httpClientService;

        public AppUserApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<List<AppUserDto>>> GetListAsync()
        {
            return await _httpClientService.GetListAsync<AppUserDto>($"{Constants.AppUsers}/{Constants.GetList}");
        }

        public async Task<ApiDataResponse<List<AppUserDto>>> GetListDetailAsync()
        {
            return await _httpClientService.GetListAsync<AppUserDto>($"{Constants.AppUsers}/{Constants.GetListDetail}");
        }
        public async Task<ApiDataResponse<AppUserDto>> AddAsync(AppUserAddDto userAddDto)
        {
            return await _httpClientService.PostAsync($"{Constants.AppUsers}/{Constants.Add}", userAddDto, new AppUserDto());
        }

        public async Task<ApiDataResponse<AppUserDto>> GetByIdAsync(int id)
        {
            return await _httpClientService.GetAsync<AppUserDto>($"{Constants.AppUsers}/{Constants.GetById}/", id);
        }

        public async Task<ApiDataResponse<AppUserUpdateDto>> UpdateAsync(AppUserUpdateDto appUserUpdateDto)
        {
            return await _httpClientService.PutAsync($"{Constants.AppUsers}/{Constants.Update}", appUserUpdateDto);
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return await _httpClientService.DeleteAsync($"{Constants.AppUsers}/{Constants.Delete}/", id);
        }
    }
}