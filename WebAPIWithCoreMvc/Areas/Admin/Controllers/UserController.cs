using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}