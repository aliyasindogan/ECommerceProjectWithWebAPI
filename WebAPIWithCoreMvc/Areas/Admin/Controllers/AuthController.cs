using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Utilities.Messages;
using Entities.Abstract.Enums;
using Entities.Dtos.Auths;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private IAuthApiService _authApiService;
        private IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthApiService authApiService, IHttpContextAccessor httpContextAccessor)
        {
            _authApiService = authApiService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            GetLanguages();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            GetLanguages();

            string _language = loginDto.LanguageId == (int)EnumLanguages.Turkish ? Constants.LangTR : Constants.LangEN;

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(_language)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(7) }
            );


            var user = await _authApiService.LoginAsync(loginDto);
            if (user != null && !user.Success)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                 return View(loginDto);
            }
            var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            userClaims.AddClaim(new Claim("token", user.Data.Token));
            userClaims.AddClaim(new Claim("language", _language));
            userClaims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Data.AppUserID.ToString()));
            userClaims.AddClaim(new Claim(ClaimTypes.Name, user.Data.UserName));
            userClaims.AddClaim(new Claim("FullName", user.Data.FullName));
            var claimPrincipal = new ClaimsPrincipal(userClaims);
            var authProperties = new AuthenticationProperties() { IsPersistent = loginDto.IsRememberMe };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, authProperties);
            return RedirectToAction(Constants.List, Constants.AppUser, new { area = Constants.Admin });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(Constants.Login);
        }

        private void GetLanguages()
        {
            List<SelectListItem> languageList = new()
            {
                new SelectListItem { Value = "1", Text = "Türkçe" },
                new SelectListItem { Value = "2", Text = "English" },
            };
            ViewBag.LanguageList = languageList;
        }
    }
}