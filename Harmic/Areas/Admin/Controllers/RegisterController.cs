using Harmic.Models;
using Harmic.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly HarmicContext _context;   // 👉 thêm dòng này

        public RegisterController(HarmicContext context)  // 👉 thêm constructor này
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TbAccount account)
        {
            if (account == null) { return NotFound(); }

            var check = _context.TbAccounts
                .Where(m => m.Username == account.Username)
                .FirstOrDefault();

            if (check != null)
            {
                Function._Message = "Trùng tài khoản";
                return RedirectToAction("Index", "Register");
            }

            Function._Message = string.Empty;
            account.Password = HashMD5.GetMD5(account.Password != null ? account.Password : "");

            _context.Add(account);
            _context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}
