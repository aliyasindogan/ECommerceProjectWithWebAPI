using Core.Utilities.Responses;
using Entities.Dtos.UploadImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUploadImageService
    {
        Task<ApiDataResponse<UploadImageDto>> UploadImageAsync(FileUploadAPIDto fileUploudAPI);
    }
}
