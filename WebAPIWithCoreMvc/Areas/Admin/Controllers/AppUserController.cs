using AutoMapper;
using Core.Utilities.Messages;
using Entities.Abstract.Enums;
using Entities.Dtos.AppUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;
using WebAPIWithCoreMvc.Helpers;
using WebAPIWithCoreMvc.Models;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private readonly IAppUserApiService _appUserApiService;
        private readonly IAppUserTypeApiService _appUserTypeApiService;
        private readonly IUploadImageApiService _uploadImageApiService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        public AppUserController(IAppUserApiService userApiService, IUploadImageApiService uploadImageApiService, IWebHostEnvironment webHostEnvironment, IMapper mapper, IAppUserTypeApiService appUserTypeApiService)
        {
            _appUserApiService = userApiService;
            _uploadImageApiService = uploadImageApiService;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            _appUserTypeApiService = appUserTypeApiService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var resultAppUser = await _appUserApiService.GetListDetailAsync();
            var appUserListViewModel = _mapper.Map<List<AppUserListViewModel>>(resultAppUser.Data);
            List<int> ids = new List<int>();
            ids.Add((int)EnumAppUserTypes.SystemAdmin);//SystemAdmin
            var users = appUserListViewModel.Where(x => ids.Contains(x.Id) == false).ToList();
            return View(users);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            await DropDownListFill();
            return View();
        }

        private async Task DropDownListFill()
        {
            var appUserTypes = await _appUserTypeApiService.GetListAsync();
            ViewBag.AppUserTypes = new SelectList(appUserTypes.Data.ToList(), "Id", "UserTypeName");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppUserAddViewModel appUserAddViewModel, IFormFile file)
        {
            HelperMethods helperMethods = new HelperMethods(_webHostEnvironment);
            string filePath = await helperMethods.FileUpload(file);
            var profileImageUrl = await _uploadImageApiService.UploadImageAsync(new FileInfo(filePath));
            appUserAddViewModel.ProfileImageUrl = profileImageUrl.Data.FullPath;
            appUserAddViewModel.RefreshToken = Guid.NewGuid();
            var appUserDto= _mapper.Map<AppUserAddDto>(appUserAddViewModel);
            var result = await _appUserApiService.AddAsync(appUserDto);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                await DropDownListFill();
                return View(appUserAddViewModel);
            }
            return RedirectToAction(Constants.List);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            await DropDownListFill();
            var appUserDto = await _appUserApiService.GetByIdAsync(id);
            var appUserUpdateViewModel = _mapper.Map<AppUserUpdateViewModel>(appUserDto.Data);
            return View(appUserUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateViewModel appUserUpdateViewModel, IFormFile file)
        {
            if (file != null)
            {
                HelperMethods helpers = new HelperMethods(_webHostEnvironment);
                string filePath = await helpers.FileUpload(file);
                var profileImageUrl = await _uploadImageApiService.UploadImageAsync(new FileInfo(filePath));
                appUserUpdateViewModel.ProfileImageUrl = profileImageUrl.Data.FullPath;
            }
            else
            {
                var appUserDto = await _appUserApiService.GetByIdAsync(appUserUpdateViewModel.Id);
                appUserUpdateViewModel.ProfileImageUrl = appUserDto.Data.ProfileImageUrl;
            }
            var appUserUpdateDto = _mapper.Map<AppUserUpdateDto>(appUserUpdateViewModel);
            var result = await _appUserApiService.UpdateAsync(appUserUpdateDto);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(appUserUpdateViewModel);

            }
            return RedirectToAction(Constants.List);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var appUserDto = await _appUserApiService.GetByIdAsync(id);
            var appUserDeleteViewModel = _mapper.Map<AppUserDeleteViewModel>(appUserDto.Data);
            return View(appUserDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AppUserDeleteViewModel appUserDeleteViewModel)
        {
            var result = await _appUserApiService.DeleteAsync(appUserDeleteViewModel.Id);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(appUserDeleteViewModel);

            }
            return RedirectToAction(Constants.List);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var appUserDto = await _appUserApiService.GetByIdAsync(id);
            var appUserDetailViewModel = _mapper.Map<AppUserDetailViewModel>(appUserDto.Data);
            return View(appUserDetailViewModel);
        }
    }
}