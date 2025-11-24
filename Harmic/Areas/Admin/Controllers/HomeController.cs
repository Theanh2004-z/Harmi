using Microsoft.AspNetCore.Mvc;
using Harmic.Utilities;

namespace Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]   // ✔ ĐÚNG VỊ TRÍ
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Kiểm tra đăng nhập
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login", new { area = "Admin" });

            return View();
        }

        public IActionResult Logout()
        {
            Function._AccountId = 0;
            Function._Username = string.Empty;
            Function._Message = string.Empty;

            // ✔ Redirect đúng Area
            return RedirectToAction("Index", "Login", new { area = "Admin" });
        }
    }
}

