using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Entities.Dtos.Languages;
using Entities.Dtos.PageTypes;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class LanguageApiService : ILanguageApiService
    {
        private readonly IHttpClientService _httpClientService;

        public LanguageApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<List<LanguageDto>>> GetListAsync()
        {
            return await _httpClientService.GetListAsync<LanguageDto>($"{Constants.Languages}/{Constants.GetList}");
        }
    }
}