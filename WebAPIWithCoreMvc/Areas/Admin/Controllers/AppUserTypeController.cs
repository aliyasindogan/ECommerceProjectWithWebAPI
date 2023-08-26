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
using WebAPIWithCoreMvc.Models;

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
            var resultAppUserTypes = await _appUserTypeApiService.GetListAsync();
            var appUserTypeListViewModel = _mapper.Map<List<AppUserTypeListViewModel>>(resultAppUserTypes.Data);

            if (appUserTypeListViewModel == null)
                return View();
            List<int> ids = new List<int>();
            ids.Add((int)EnumAppUserTypes.SystemAdmin);//SystemAdmin
            var userTypes = appUserTypeListViewModel.Where(x => ids.Contains(x.Id) == false).ToList();
            return View(userTypes);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppUserTypeAddViewModel appUserTypeAddViewModel)
        {
            var appUserTypeAddDto = _mapper.Map<AppUserTypeAddDto>(appUserTypeAddViewModel);
            var result = await _appUserTypeApiService.AddAsync(appUserTypeAddDto);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(appUserTypeAddViewModel);
            }
            return RedirectToAction(Constants.List);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var appUserTypeDto = await _appUserTypeApiService.GetByIdAsync(id);
            var appUserTypeUpdateViewModel = _mapper.Map<AppUserTypeUpdateViewModel>(appUserTypeDto.Data);
            return View(appUserTypeUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserTypeUpdateViewModel appUserTypeUpdateViewModel)
        {
            var appUserTypeUpdateDto = _mapper.Map<AppUserTypeUpdateDto>(appUserTypeUpdateViewModel);
            var result = await _appUserTypeApiService.UpdateAsync(appUserTypeUpdateDto);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(appUserTypeUpdateViewModel);

            }
            return RedirectToAction(Constants.List);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var appUserTypeDto = await _appUserTypeApiService.GetByIdAsync(id);
            var appUserTypeDeleteViewModel = _mapper.Map<AppUserTypeDeleteViewModel>(appUserTypeDto.Data);
            return View(appUserTypeDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AppUserTypeDeleteViewModel appUserTypeDeleteViewModel)
        {
            var result = await _appUserTypeApiService.DeleteAsync(appUserTypeDeleteViewModel.Id);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(appUserTypeDeleteViewModel);

            }
            return RedirectToAction(Constants.List);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var appUserTypeDto = await _appUserTypeApiService.GetByIdAsync(id);
            var appUserTypeDetailViewModel = _mapper.Map<AppUserTypeDetailViewModel>(appUserTypeDto.Data);
            return View(appUserTypeDetailViewModel);
        }
    }
}