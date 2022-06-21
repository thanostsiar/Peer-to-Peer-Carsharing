using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carsharing.Models;


namespace carsharing.Controllers
{
    public class SearchController : Controller
    {
        // get the database context
        private readonly unipicarsContext _context;

        public SearchController(unipicarsContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<IActionResult> Results(SearchBar searchBar)
        {
            var listOfPosts = await _context.Posts.ToListAsync();

            return View(listOfPosts);

        }
    }
}
