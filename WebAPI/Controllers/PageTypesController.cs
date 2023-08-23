﻿using Business.Abstract;
using Entities.Dtos.AppUsers;
using Entities.Dtos.AppUserTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageTypesController : ControllerBase
    {
        private readonly IAppUserTypeService _appUserTypeService;

        public PageTypesController(IAppUserTypeService userTypeService)
        {
            _appUserTypeService = userTypeService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _appUserTypeService.GetListAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> GetListDetail()
        //{
        //    var result = await _appUserTypeService.GetListDetailAsync();
        //    if (result.Success)
        //        return Ok(result);
        //    return BadRequest(result);
        //}


        //[HttpGet]
        //[Route("[action]/{id:int}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var result = await _appUserTypeService.GetByIdAsync(id);
        //    if (result.Success)
        //        return Ok(result);
        //    return BadRequest(result);
        //}

        //[HttpPost]
        //[Route("[action]")]
        //public async Task<IActionResult> Add([FromBody] AppUserTypeAddDto userTypeAddDto)
        //{
        //    var result = await _appUserTypeService.AddAsync(userTypeAddDto);
        //    if (result.Success)
        //        return Ok(result);
        //    return BadRequest();
        //}

        //[HttpPut]
        //[Route("[action]")]
        //public async Task<IActionResult> Update([FromBody] AppUserTypeUpdateDto userTypeUpdateDto)
        //{
        //    var result = await _appUserTypeService.UpdateAsync(userTypeUpdateDto);
        //    if (result.Success)
        //        return Ok(result);
        //    return BadRequest(result);
        //}

        //[HttpDelete]
        //[Route("[action]/{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _appUserTypeService.DeleteAsync(id);
        //    if (result.Success)
        //        return Ok(result);
        //    return BadRequest(result);
        //}
    }
}