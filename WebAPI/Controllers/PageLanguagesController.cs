using Business.Abstract;
using Entities.Dtos.PageLanguages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageLanguagesController : ControllerBase
    {
        private readonly IPageLanguageService _pageLanguageService;

        public PageLanguagesController(IPageLanguageService pageLanguageService)
        {
            _pageLanguageService = pageLanguageService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _pageLanguageService.GetListAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetListDetail()
        {
            var result = await _pageLanguageService.GetListDetailAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pageLanguageService.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] PageLanguageAddDto pageLanguageAddDto)
        {
            var result = await _pageLanguageService.AddAsync(pageLanguageAddDto);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] PageLanguageUpdateDto pageLanguageUpdateDto)
        {
            var result = await _pageLanguageService.UpdateAsync(pageLanguageUpdateDto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pageLanguageService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}