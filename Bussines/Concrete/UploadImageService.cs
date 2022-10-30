using Business.Abstract;
using Core.Utilities.Localization;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using Entities.Dtos.UploadImages;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UploadImageService : IUploadImageService
    {
        private readonly ILocalizationService _localizationService;

        public UploadImageService(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        public async Task<ApiDataResponse<UploadImageDto>> UploadImageAsync(FileUploadAPIDto fileUploudAPI)
        {
            if (fileUploudAPI.files.Length <= 0)
                return new ErrorApiDataResponse<UploadImageDto>(
                    data: null, 
                    message: _localizationService[ResultCodes.ERROR_ImageNotFound], 
                    resultCodes :ResultCodes.ERROR_ImageNotFound) ;

            if (!Directory.Exists(fileUploudAPI.WebHostEnvironmentWebRootPath))
                Directory.CreateDirectory(fileUploudAPI.WebHostEnvironmentWebRootPath);
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUploudAPI.files.FileName);
            using (FileStream fileStream= File.Create(fileUploudAPI.WebHostEnvironmentWebRootPath+newFileName))
            {
                fileUploudAPI.files.CopyTo(fileStream);
                fileStream.Flush();
                UploadImageDto uploadImageDto = new UploadImageDto();
                uploadImageDto.FullPath = await Task.FromResult(fileUploudAPI.ApiIPAdress + "/Upload/" + newFileName);
                return new SuccessApiDataResponse<UploadImageDto>(uploadImageDto, _localizationService[ResultCodes.HTTP_OK]);
            }
        }
    }
}
