using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAppUserService _userService;

        public UsersController(IAppUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userService.GetListAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] UserAddDto userAddDto)
        {
            var result = await _userService.AddAsync(userAddDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto userUpdateDto)
        {
            var result = await _userService.UpdateAsync(userUpdateDto);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
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