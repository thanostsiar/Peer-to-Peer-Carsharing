using carsharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace carsharing.Controllers
{
    public class PostController : Controller
    {
        // get the database context
        private unipicarsContext _context;

        // initialize the context
        public PostController(unipicarsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Posts.ToList();
            return View(data[0]);
        }

    }
}
