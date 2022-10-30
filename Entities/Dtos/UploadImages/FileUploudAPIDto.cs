using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos.UploadImages
{
    public class FileUploadAPIDto : IDto
    {
        public IFormFile files { get; set; }
        public string WebHostEnvironmentWebRootPath { get; set; }
        public string ApiIPAdress { get; set; }
    }
}
