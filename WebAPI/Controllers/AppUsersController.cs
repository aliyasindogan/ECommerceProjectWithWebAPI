using Business.Abstract;
using Entities.Dtos.AppUser;
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
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _appUserService.GetByIdAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] AppUserAddDto userAddDto)
        {
            var result = await _appUserService.AddAsync(userAddDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] AppUserUpdateDto userUpdateDto)
        {
            var result = await _appUserService.UpdateAsync(userUpdateDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _appUserService.DeleteAsync(id);
            if (result.Data)
                return Ok(true);
            return BadRequest(false);
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> Authenticate([FromBody] LoginDto userForLoginDto)
        //{
        //    var result = await _userService.Authenticate(userForLoginDto);
        //    if (result != null)
        //        return Ok(result);
        //    return BadRequest();
        //}
    }
}