using Business.Abstract;
using Entities.Dtos.Pages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IPageService _pageService;

        public PagesController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _pageService.GetListAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetListDetail()
        {
            var result = await _pageService.GetListDetailAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pageService.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] PageAddDto pageAddDto)
        {
            var result = await _pageService.AddAsync(pageAddDto);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] PageUpdateDto pageUpdateDto)
        {
            var result = await _pageService.UpdateAsync(pageUpdateDto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pageService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}