using Business.Abstract;
using Entities.Dtos.AppUsers;
using Entities.Dtos.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _resourceService.GetListAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> GetListDetail()
        //{
        //    var result = await _resourceService.GetListDetailAsync();
        //    if (result.Success)
        //        return Ok(result);
        //    return BadRequest(result);
        //}


        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _resourceService.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] ResourceAddDto resourceAddDto)
        {
            var result = await _resourceService.AddAsync(resourceAddDto);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] ResourceUpdateDto resourceUpdateDto)
        {
            var result = await _resourceService.UpdateAsync(resourceUpdateDto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _resourceService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}