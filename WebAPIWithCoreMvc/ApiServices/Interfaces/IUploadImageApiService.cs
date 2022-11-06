using Core.Utilities.Responses;
using Entities.Dtos.UploadImages;
using System.IO;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IUploadImageApiService
    {
        Task<ApiDataResponse<UploadImageDto>> UploadImageAsync(FileInfo fileInfo);
    }
}
