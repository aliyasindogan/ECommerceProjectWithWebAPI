using Microsoft.AspNetCore.Mvc;

namespace WebAPIWithCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorController : Controller
    {
        public IActionResult MyStatusCode(int code)
        {
            if (code == 404)
            {
                ViewBag.ErrorMessage = "Sayfa bulunamadı!";
                return RedirectToAction("Error404", "Error", new { area = "Admin" });
            }
            if (code == 500)
            {
                ViewBag.ErrorMessage = "Sunucu hatası!";
                return RedirectToAction("InternalServerError500", "Error", new { area = "Admin" });
            }
            if (code == 401)
            {
                ViewBag.ErrorMessage = "Yetkisiz erişim!";
                return RedirectToAction("Unauthorize401", "Error", new { area = "Admin" });
            }
            if (code == 400)
            {
                ViewBag.ErrorMessage = "Geçersiz istek!";
                return RedirectToAction("BadRequest400", "Error", new { area = "Admin" });
            }
            else
            {
                ViewBag.ErrorMessage = "İşleminiz gerçekleştirilirken bir hata oluştu!";
            }
            ViewBag.ErrorStatusCode = code;
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult InternalServerError500()
        {
            return View();
        }

        public IActionResult Unauthorize401()
        {
            return View();
        }

        public IActionResult BadRequest400()
        {
            return View();
        }
    }
}