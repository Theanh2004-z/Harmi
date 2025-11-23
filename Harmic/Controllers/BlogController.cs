using Harmic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harmic.Controllers
{
    public class BlogController : Controller
    {
        private readonly HarmicContext _context;

        public BlogController(HarmicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/blog/{alias}-{id}.html", Name = "BlogDetails")]
        public async Task<IActionResult> Details(string alias, int? id)
        {
            if (id == null || _context.TbBlogs == null)
            {
                return NotFound();
            }

            var blog = await _context.TbBlogs
                .FirstOrDefaultAsync(m => m.BlogId == id);

            if (blog == null)
            {
                return NotFound();
            }

            ViewBag.blogComment = await _context.TbBlogComments
                .Where(i => i.BlogId == id)
                .ToListAsync();

            return View(blog);
        }
    }
}