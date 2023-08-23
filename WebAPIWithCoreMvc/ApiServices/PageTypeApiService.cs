using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Entities.Dtos.PageTypes;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class PageTypeApiService : IPageTypeApiService
    {
        private readonly IHttpClientService _httpClientService;

        public PageTypeApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<List<PageTypeDto>>> GetListAsync()
        {
            return await _httpClientService.GetListAsync<PageTypeDto>($"{Constants.PageTypes}/{Constants.GetList}");
        }
    }
}