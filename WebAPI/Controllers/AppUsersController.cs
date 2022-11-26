using Business.Abstract;
using Entities.Dtos.AppUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUsersController(IAppUserService userService)
        {
            _appUserService = userService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _appUserService.GetListAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetListDetail()
        {
            var result = await _appUserService.GetListDetailAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _appUserService.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] AppUserAddDto userAddDto)
        {
            var result = await _appUserService.AddAsync(userAddDto);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] AppUserUpdateDto userUpdateDto)
        {
            var result = await _appUserService.UpdateAsync(userUpdateDto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _appUserService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}