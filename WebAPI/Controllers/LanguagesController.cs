using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService userTypeService)
        {
            _languageService = userTypeService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _languageService.GetListAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> GetListDetail()
        //{
        //    var result = await _languageService.GetListDetailAsync();
        //    if (result.Success)
        //        return Ok(result);
        //    return BadRequest(result);
        //}


        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _languageService.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> Add([FromBody] LanguageAddDto userTypeAddDto)
        //{
        //    var result = await _languageService.AddAsync(userTypeAddDto);
        //    if (result.Success)
        //        return Ok(result);
        //    return BadRequest();
        //}

        //[HttpPut]
        //[Route("[action]")]
        //public async Task<IActionResult> Update([FromBody] LanguageUpdateDto userTypeUpdateDto)
        //{
        //    var result = await _languageService.UpdateAsync(userTypeUpdateDto);
        //    if (result.Success)
        //        return Ok(result);
        //    return BadRequest(result);
        //}

        //[HttpDelete]
        //[Route("[action]/{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _languageService.DeleteAsync(id);
        //    if (result.Success)
        //        return Ok(result);
        //    return BadRequest(result);
        //}
    }
}