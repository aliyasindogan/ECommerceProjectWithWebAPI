using Business.Abstract;
using Entities.Dtos.UploadImages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImagesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        private IUploadImageService _uploadImageService;

        public UploadImagesController(IWebHostEnvironment webHostEnvironment, IUploadImageService uploadImageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _uploadImageService = uploadImageService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddUploadImage([FromForm] FileUploadAPIDto fileUploadAPI)
        {
            fileUploadAPI.ApiIPAdress = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            fileUploadAPI.WebHostEnvironmentWebRootPath = _webHostEnvironment.WebRootPath + "\\Upload\\";
            var result = await _uploadImageService.UploadImageAsync(fileUploadAPI);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
