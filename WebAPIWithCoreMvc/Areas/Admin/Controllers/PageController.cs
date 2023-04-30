using AutoMapper;
using Core.Utilities.Messages;
using Entities.Dtos.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;
using WebAPIWithCoreMvc.Helpers;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PageController : Controller
    {
        private readonly IPageApiService _pageApiService;
        private readonly IMapper _mapper;
        public PageController(IPageApiService pageApiService, IMapper mapper)
        {
            _pageApiService = pageApiService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _pageApiService.GetListAsync();
            if (result == null)
                return View();
            return View(result.Data.ToList());
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