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
            var result = await _appUserApiService.GetListDetailAsync();
            List<int> ids = new List<int>();
            ids.Add((int)EnumAppUserTypes.SystemAdmin);//SystemAdmin
            var users = result.Data.Where(x => ids.Contains(x.Id) == false);
            return View(users.ToList());
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
            ViewBag.AppUserTypes = new SelectList(appUserTypes.Data.Where(x => x.Id > 0).ToList(), "Id", "UserTypeName");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppUserAddDto appUserAddDto, IFormFile file)
        {
            HelperMethods helperMethods = new HelperMethods(_webHostEnvironment);
            string filePath = await helperMethods.FileUpload(file);
            var profileImageUrl = await _uploadImageApiService.UploadImageAsync(new FileInfo(filePath));
            appUserAddDto.ProfileImageUrl = profileImageUrl.Data.FullPath;
            appUserAddDto.RefreshToken = Guid.NewGuid();
            var result = await _appUserApiService.AddAsync(appUserAddDto);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                await DropDownListFill();
                return View(appUserAddDto);
            }
            return RedirectToAction(Constants.List);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            await DropDownListFill();
            var appUserDto = await _appUserApiService.GetByIdAsync(id);
            var appUserUpdateDto = _mapper.Map<AppUserUpdateDto>(appUserDto.Data);
            return View(appUserUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateDto appUserUpdateDto, IFormFile file)
        {
            if (file != null)
            {
                HelperMethods helpers = new HelperMethods(_webHostEnvironment);
                string filePath = await helpers.FileUpload(file);
                var profileImageUrl = await _uploadImageApiService.UploadImageAsync(new FileInfo(filePath));
                appUserUpdateDto.ProfileImageUrl = profileImageUrl.Data.FullPath;
            }
            else
            {
                var appUserDto = await _appUserApiService.GetByIdAsync(appUserUpdateDto.Id);
                appUserUpdateDto.ProfileImageUrl = appUserDto.Data.ProfileImageUrl;
            }
            var result = await _appUserApiService.UpdateAsync(appUserUpdateDto);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(appUserUpdateDto);

            }
            return RedirectToAction(Constants.List);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var appUserDto = await _appUserApiService.GetByIdAsync(id);
            var appUserDeleteDto = _mapper.Map<AppUserDeleteDto>(appUserDto.Data);
            return View(appUserDeleteDto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AppUserDeleteDto appUserDeleteDto)
        {
            var result = await _appUserApiService.DeleteAsync(appUserDeleteDto.Id);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(appUserDeleteDto);

            }
            return RedirectToAction(Constants.List);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var appUserDto = await _appUserApiService.GetByIdAsync(id);
            var appUserDetailDto = _mapper.Map<AppUserDetailDto>(appUserDto.Data);
            return View(appUserDetailDto);
        }
    }
}