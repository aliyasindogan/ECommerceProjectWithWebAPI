using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}