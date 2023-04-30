using AutoMapper;
using Core.Utilities.Messages;
using Entities.Abstract.Enums;
using Entities.Dtos.AppUserTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;
using WebAPIWithCoreMvc.Helpers;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AppUserTypeController : Controller
    {
        private readonly IAppUserTypeApiService _appUserTypeApiService;
        private readonly IMapper _mapper;
        public AppUserTypeController(IAppUserTypeApiService userTypeApiService, IMapper mapper)
        {
            _appUserTypeApiService = userTypeApiService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _appUserTypeApiService.GetListAsync();
            if (result == null)
                return View();
            List<int> ids = new List<int>();
            ids.Add((int)EnumAppUserTypes.SystemAdmin);//SystemAdmin
            var userTypes = result.Data.Where(x => ids.Contains(x.Id) == false);
            return View(userTypes.ToList());
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppUserTypeAddDto appUserTypeAddDto)
        {
            var result = await _appUserTypeApiService.AddAsync(appUserTypeAddDto);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(appUserTypeAddDto);
            }
            return RedirectToAction(Constants.List);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var appUserTypeDto = await _appUserTypeApiService.GetByIdAsync(id);
            var appUserTypeUpdateDto = _mapper.Map<AppUserTypeUpdateDto>(appUserTypeDto.Data);
            return View(appUserTypeUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserTypeUpdateDto appUserTypeUpdateDto)
        {
            var result = await _appUserTypeApiService.UpdateAsync(appUserTypeUpdateDto);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(appUserTypeUpdateDto);

            }
            return RedirectToAction(Constants.List);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var appUserTypeDto = await _appUserTypeApiService.GetByIdAsync(id);
            var appUserTypeDeleteDto = _mapper.Map<AppUserTypeDeleteDto>(appUserTypeDto.Data);
            return View(appUserTypeDeleteDto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AppUserTypeDeleteDto appUserTypeDeleteDto)
        {
            var result = await _appUserTypeApiService.DeleteAsync(appUserTypeDeleteDto.Id);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(appUserTypeDeleteDto);

            }
            return RedirectToAction(Constants.List);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var appUserTypeDto = await _appUserTypeApiService.GetByIdAsync(id);
            var appUserTypeDetailDto = _mapper.Map<AppUserTypeDetailDto>(appUserTypeDto.Data);
            return View(appUserTypeDetailDto);
        }
    }
}