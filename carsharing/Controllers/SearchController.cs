using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carsharing.Models;
using carsharing.ViewModels;
using System.Globalization;

namespace carsharing.Controllers
{
    public class SearchController : Controller
    {
        public String ErrorMessage;

        // get the database context
        private readonly unipicarsContext _context;
        
        private IQueryable<Post> resultPosts;

        public SearchController(unipicarsContext context)
        {
            _context = context;
            resultPosts = Enumerable.Empty<Post>().AsQueryable();
            this.ErrorMessage = "";
        }

        public async Task<IActionResult> Results(SearchBar searchBar)
        {
            var owners = _context.Owners.AsQueryable();
            var vehicles = _context.Vehicles.AsQueryable();
            var posts = _context.Posts.AsQueryable();
            
            var today = DateTime.Now;

            var dateFrom = DateTime.ParseExact(searchBar.DateFrom, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var dateTo = DateTime.ParseExact(searchBar.DateTo, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var numberOfDays = (dateTo.Date - dateFrom.Date).TotalDays;
            var message = "No car was found";

            System.Diagnostics.Debug.WriteLine("dateFrom: ", dateFrom);
            System.Diagnostics.Debug.WriteLine("dateTo: ", dateTo);

            foreach (var post in await posts.ToListAsync())
            {

                if(searchBar.SearchField.Equals(post.City))
                {
                    var owner = owners.Where(ow => ow.OwnerId == post.OwnerId).First();
                    post.Owner = owner;

                    if(numberOfDays > 0 && numberOfDays <= post.MaxDaysOfRent)
                    {
                        System.Diagnostics.Debug.WriteLine("numberOfDays: ", numberOfDays);

                        resultPosts = resultPosts.Append(post);
                    }
                }
            }

            if(!resultPosts.Any())
            {
                this.ErrorMessage = message;
            }

            var resultsViewModel = new ResultsViewModel(vehicles, resultPosts, ErrorMessage);

            return View(resultsViewModel);
        }
    }
}
