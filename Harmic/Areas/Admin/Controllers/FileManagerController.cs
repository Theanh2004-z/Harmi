using Microsoft.AspNetCore.Mvc;

namespace Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]  // ✔ đúng
    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

