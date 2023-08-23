using AutoMapper;
using Core.Utilities.Messages;
using Entities.Dtos.Pages;
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
    public class PageController : Controller
    {
        private readonly IPageApiService _pageApiService;
        private readonly IPageLanguageApiService _pageLanguageApiService;
        private readonly IPageTypeApiService _pageTypeApiService;
        private readonly ILanguageApiService _languageApiService;
        private readonly IMapper _mapper;
        public PageController(IPageApiService pageApiService, IMapper mapper, IPageLanguageApiService pageLanguageApiService, IPageTypeApiService pageTypeApiService, ILanguageApiService languageApiService)
        {
            _pageApiService = pageApiService;
            _mapper = mapper;
            _pageLanguageApiService = pageLanguageApiService;
            _pageTypeApiService = pageTypeApiService;
            _languageApiService = languageApiService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            /*
            Todo:pageTypeResponse boş geliyor kontrol edilecek. 23.08.2023
             */
            var pageResponse = await _pageApiService.GetListAsync();
            var pageLanguageResponse = await _pageLanguageApiService.GetListAsync();
            var pageTypeResponse = await _pageTypeApiService.GetListAsync();
            var languageResponse = await _languageApiService.GetListAsync();
            List<PageViewModel> pageViewModel = new List<PageViewModel>();
            foreach (var page in pageResponse.Data)
            {
                var pageLanguageList = pageLanguageResponse.Data.Where(x => x.PageID == page.Id).ToList();
                foreach (var pageLanguage in pageLanguageList)
                {
                    string languageName = languageResponse.Data.FirstOrDefault(x => x.Id == pageLanguage.LanguageID)?.LanguageName;
                    string pageTypeName = pageTypeResponse.Data.FirstOrDefault(x => x.Id == page.PageTypeID)?.PageTypeName;
                    string parentPageName = pageLanguageResponse.Data.FirstOrDefault(x => x.PageID == page.ParentID)?.PageName;
                    pageViewModel.Add(new PageViewModel
                    {

                        LanguageID = pageLanguage.Id,
                        LanguageName = languageName,
                        DisplayOrder = page.DisplayOrder,
                        IsActive = page.IsActive,
                        MetaDescription = pageLanguage.MetaDescription,
                        MetaKeywords = pageLanguage.MetaKeywords,
                        MetaTitle = pageLanguage.MetaTitle,
                        PageID = pageLanguage.PageID,
                        PageLanguageID = page.Id,
                        PageName = pageLanguage.PageName,
                        PageSeoURL = pageLanguage.PageSeoURL,
                        PageTypeID = page.PageTypeID,
                        PageTypeName = pageTypeName,
                        PageURL = page.PageURL,
                        ParentID = page.ParentID,
                        ParentPageName = parentPageName,
                    });
                }
            }
            return View(pageViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PageAddDto appUserTypeAddDto)
        {
            var result = await _pageApiService.AddAsync(appUserTypeAddDto);
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
            var pageDto = await _pageApiService.GetByIdAsync(id);
            var pageUpdateDto = _mapper.Map<PageUpdateDto>(pageDto.Data);
            return View(pageUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PageUpdateDto pageUpdateDto)
        {
            var result = await _pageApiService.UpdateAsync(pageUpdateDto);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(pageUpdateDto);

            }
            return RedirectToAction(Constants.List);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var pageDto = await _pageApiService.GetByIdAsync(id);
            var pageDeleteDto = _mapper.Map<PageDeleteDto>(pageDto.Data);
            return View(pageDeleteDto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PageDeleteDto pageDeleteDto)
        {
            var result = await _pageApiService.DeleteAsync(pageDeleteDto.Id);
            if (!result.Success)
            {
                var errorList = HelperMethods.ErrorList(result);
                ViewBag.Errors = errorList;
                return View(pageDeleteDto);
            }
            return RedirectToAction(Constants.List);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var pageDto = await _pageApiService.GetByIdAsync(id);
            var pageDetailDto = _mapper.Map<PageDetailDto>(pageDto.Data);
            return View(pageDetailDto);
        }
    }
}