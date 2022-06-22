using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carsharing.Models;
using carsharing.ViewModels;


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
            var owners = _context.Owners.AsQueryable();
            var vehicles = _context.Vehicles.AsQueryable();
            var posts = _context.Posts.AsQueryable();

            foreach (var post in posts.ToList())
            {
                var owner = owners.Where(ow => ow.OwnerId == post.OwnerId).First();
                post.Owner = owner;
            }

            var resultsViewModel = new ResultsViewModel(vehicles, posts);

            return View(resultsViewModel);

        }
    }
}
