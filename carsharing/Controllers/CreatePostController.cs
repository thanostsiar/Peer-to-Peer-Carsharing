using Microsoft.AspNetCore.Mvc;
using carsharing.Models;

namespace carsharing.Controllers
{
    public class CreatePostController : Controller
    {
        // get the database context
        private unipicarsContext _context;

        // initialize the context
        public CreatePostController(unipicarsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
