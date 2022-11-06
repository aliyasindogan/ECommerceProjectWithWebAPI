using Core.Entities.Enums;
using Entities.Dtos.AppUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;
using WebAPIWithCoreMvc.Helpers;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private IAppUserApiService _userApiService;
        IUploadImageApiService _uploadImageApiService;
        IWebHostEnvironment _webHostEnvironment;
        public AppUserController(IAppUserApiService userApiService, IUploadImageApiService uploadImageApiService, IWebHostEnvironment webHostEnvironment)
        {
            _userApiService = userApiService;
            _uploadImageApiService = uploadImageApiService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _userApiService.GetListDetailAsync();
            return View(result.Data);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppUserAddDto appUserAddDto,IFormFile file)
        {
            HelperMethods helperMethods = new HelperMethods(_webHostEnvironment);
            string filePath = await helperMethods.FileUpload(file);
            var profileImageUrl = await _uploadImageApiService.UploadImageAsync(new FileInfo(filePath));
            appUserAddDto.ProfileImageUrl = profileImageUrl.Data.FullPath;

            appUserAddDto.AppUserTypeID = (int)AppUserTypes.Admin;
            appUserAddDto.RefreshToken = Guid.NewGuid();
            var result = await _userApiService.AddAsync(appUserAddDto);
            if (!result.Success)
            {
                string[] errors = result.Message.Split(";");
                List<string> errorList = new List<string>();
                foreach (string error in errors)
                {
                    if (!String.IsNullOrEmpty(error))
                        errorList.Add(error);
                }
                ViewBag.Errors = errorList;
                return View(appUserAddDto);
            }
            return RedirectToAction("Index");
        }
    }
}