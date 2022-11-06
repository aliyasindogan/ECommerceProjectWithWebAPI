using Core.Utilities.Responses;
using Entities.Dtos.UploadImages;
using System.IO;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class UploadImageApiService : IUploadImageApiService
    {
        private readonly IHttpClientService _httpClientService;

        public UploadImageApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<UploadImageDto>> UploadImageAsync(FileInfo fileInfo)
        {
            return await _httpClientService.UploadImageAsync<UploadImageDto>(fileInfo);
        }
    }
}
