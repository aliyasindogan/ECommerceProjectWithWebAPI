using Core.Entities.Enums;
using Entities.Dtos.AppUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private IAppUserApiService _userApiService;

        public AppUserController(IAppUserApiService userApiService)
        {
            _userApiService = userApiService;
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
        public async Task<IActionResult> Add(AppUserAddDto appUserAddDto)
        {
            appUserAddDto.AppUserTypeID = (int)AppUserTypes.Admin;
            appUserAddDto.ProfileImageUrl = "default";
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