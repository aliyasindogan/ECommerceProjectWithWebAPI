﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiServices.Interfaces;
using WebAPIWithCoreMvc.Models;

namespace WebAPIWithCoreMvc.Areas.Admin.ViewComponents
{
    public class LeftMenuViewComponent : ViewComponent
    {
        private readonly IPageApiService _pageApiService;
        public LeftMenuViewComponent(IPageApiService pageApiService)
        {
            _pageApiService = pageApiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            LeftMenuViewModel viewModel = new LeftMenuViewModel();
            var result = await _pageApiService.GetListDetailAsync();
            viewModel.MainPage = result.Data.Where(x => x.ParentID == null ).ToList();
            viewModel.ParentPage = result.Data.Where(x => x.ParentID != null ).ToList();
            return View(viewModel);
        }

    }
}
