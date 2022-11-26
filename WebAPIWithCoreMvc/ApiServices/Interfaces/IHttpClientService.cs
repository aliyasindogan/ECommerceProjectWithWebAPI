using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auths;
using Entities.Dtos.UploadImages;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IHttpClientService
    {
        Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto);
        Task<ApiDataResponse<List<T>>> GetListAsync<T>(string url);
        Task<ApiDataResponse<TResponseEntity>> PostAsync<TRequestEntity, TResponseEntity>(string url, TRequestEntity requestEntity, TResponseEntity responseEntity);
        Task<ApiDataResponse<UploadImageDto>> UploadImageAsync<T>(FileInfo fileInfo);
        Task<ApiDataResponse<T>> GetAsync<T>(string url, int id);
        Task<ApiDataResponse<T>> PutAsync<T>(string url, T entity);
        Task<ApiDataResponse<bool>> DeleteAsync(string url, int id);

    }
}
