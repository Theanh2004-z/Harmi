using Microsoft.AspNetCore.Mvc;
using Harmic.Models;
using Harmic.Utilities;
using System.Linq;

namespace Harmic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly HarmicContext _context;

        public LoginController(HarmicContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Index(TbAccount account)
        {
            if (account == null)
            {
                return NotFound();
            }

            string password = HashMD5.GetMD5(account.Password);

            var check = _context.TbAccounts
                .Where(m => m.Username == account.Username && m.Password == password)
                .FirstOrDefault();

            if (check == null)
            {
                Function._Message = "Invalid Username or Password";
                return RedirectToAction("Index", "Login");
            }

            Function._Message = string.Empty;
            Function._AccountId = check.AccountId;
            Function._Username = check.Username;

            return RedirectToAction("Index", "Home");
        }
    }
}



