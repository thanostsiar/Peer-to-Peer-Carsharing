using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carsharing.Models;
using carsharing.ViewModels;
using System.Globalization;

namespace carsharing.Controllers
{
    public class SearchController : Controller
    {
        // get the database context
        private readonly unipicarsContext _context;
        
        private IQueryable<Post> resultPosts;

        private double numberOfDays;
        
        private String ErrorMessage;

        public static string PreviousSearchField;

        public static string PreviousDateFrom;

        public static string PreviousDateTo;

        private double CalculateNumberOfDays(string dateFrom, string dateTo)
        {
            var from = DateTime.ParseExact(dateFrom, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var to = DateTime.ParseExact(dateTo, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            return (to.Date - from.Date).TotalDays;
        }

        private IQueryable<Post> FetchPosts()
        {
            var owners = _context.Owners.AsQueryable();
            var vehicles = _context.Vehicles.AsQueryable();
            var postComments = _context.PostComments.AsQueryable();
            var posts = _context.Posts.AsQueryable();

            foreach(var post in posts.ToList())
            {
                var owner = owners.Where(ow => ow.OwnerId == post.OwnerId).First();
                var vehicle = vehicles.Where(vh => vh.VehicleId == post.VehicleId).First();
                var comments = postComments.Where(pc => pc.PostId == post.PostId);

                foreach(var comment in comments)
                {
                    post.PostComments.Add(comment);
                }

                post.Owner = owner;
                post.Vehicle = vehicle;
            }

            return posts;
        }

        public SearchController(unipicarsContext context)
        {
            _context = context;
            resultPosts = Enumerable.Empty<Post>().AsQueryable();
            this.ErrorMessage = "";
        }


        public async Task<IActionResult> Results(SearchBar searchBar, FilterPost filterPost)
        {
            var message = "";
            ResultsViewModel resultsFilteredViewModel;

            var filtered = Enumerable.Empty<Post>().AsQueryable();

            if ((filterPost.CarColor != null || filterPost.CarManufacturer != null || filterPost.CarType != null || filterPost.CreatedAt != null)
                && (searchBar.DateFrom == null && searchBar.DateTo == null && searchBar.SearchField == null))
            {
                // start by having all the posts stored
                var filterred = FetchPosts();

                this.numberOfDays = CalculateNumberOfDays(PreviousDateFrom, PreviousDateTo);


                if (filterPost.CarColor != null)
                {
                    filterred = filterred.Where(post => post.Vehicle.Color.ToLower() == filterPost.CarColor.ToLower()
                                                                                       && PreviousSearchField.ToLower() == post.City.ToLower());
                }

                if(filterPost.CarManufacturer != null)
                {
                    filterred = filterred.Where(post => post.Vehicle.Manufacturer.ToLower() == filterPost.CarManufacturer.ToLower()
                                                          && PreviousSearchField.ToLower() == post.City.ToLower());
                }

                if (filterPost.CarType != null)
                {
                    filterred = filterred.Where(post => post.Vehicle.Type.ToLower() == filterPost.CarType.ToLower()
                                                          && PreviousSearchField.ToLower() == post.City.ToLower());
                }

                if(filterPost.CreatedAt != null)
                {
                    if(filterPost.CreatedAt.Equals("Newest"))
                    {
                        filterred = filterred.OrderByDescending(post => post.Created);
                    }
                    else
                    {
                        filterred = filterred.OrderBy(post => post.Created);
                    }
                }

                if (!filterred.Any()) 
                {
                    message = "Oops! Seems like there are no cars found!";

                    this.ErrorMessage = message;
                }

                resultsFilteredViewModel = new ResultsViewModel(filterred, this.numberOfDays, ErrorMessage);
                return View(resultsFilteredViewModel);
            }

            if(searchBar.SearchField == null)
            {
                searchBar.SearchField = PreviousSearchField;
            }

            if(searchBar.DateFrom == null)
            {
                searchBar.DateFrom = PreviousDateFrom;
            }

            if(searchBar.DateTo == null)
            {
                searchBar.DateTo = PreviousDateTo;
            }

            this.numberOfDays = CalculateNumberOfDays(searchBar.DateFrom, searchBar.DateTo);

            PreviousSearchField = searchBar.SearchField.ToLower();
            PreviousDateFrom = searchBar.DateFrom.ToLower();
            PreviousDateTo = searchBar.DateTo.ToLower();

            var posts = FetchPosts();

            foreach (var post in await posts.ToListAsync())
            {

                if (searchBar.SearchField.ToLower().Equals(post.City.ToLower()))
                {

                    if (this.numberOfDays > 0 && this.numberOfDays <= post.MaxDaysOfRent)
                    {
                        this.resultPosts = this.resultPosts.Append(post);
                    }
                }
            }

            if (!this.resultPosts.Any())
            {
                message = "Oops! Seems like there are no cars found!";

                this.ErrorMessage = message;
            }

            var resultsViewModel = new ResultsViewModel(this.resultPosts, this.numberOfDays, ErrorMessage);
            
            return View(resultsViewModel);
        }
    }
}
