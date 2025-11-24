using Harmic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harmic.Controllers
{
    public class ContactController : Controller
    {
        private readonly HarmicContext _context;

        public ContactController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(string name, string phone, string email, string message)
        {
            try
            {
                var contact = new TbContact
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Message = message,
                    CreatedDate = DateTime.Now,
                    IsRead = 0
                };

                _context.Add(contact);
                _context.SaveChanges();

                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
