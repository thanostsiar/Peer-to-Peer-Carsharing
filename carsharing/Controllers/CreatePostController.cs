using Microsoft.AspNetCore.Mvc;
using carsharing.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using carsharing.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace carsharing.Controllers
{
    [Authorize(Roles = "Owner")]
    public class CreatePostController : Controller
    {
        // get the database context
        private unipicarsContext _context;

        // initialize the context
        public CreatePostController(unipicarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var OwnerRenter = new ResultsViewModel(null, 0)
            {
                Renter = new Renter()
            }; 

            return View(OwnerRenter);
        }


        [HttpPost]
        public async Task <IActionResult> Index(CreatePost createPost)
        {

            var CreatePost = new ResultsViewModel(null, 0)
            {
                Renter = new Renter()
            };

            if (!ModelState.IsValid)
            {
                return View(CreatePost);
            }

            string email = "";
            Renter r = new Renter();

            var listOfOwners = await _context.Owners.ToListAsync();

            Post post = new Post();
            Vehicle vehicle = new Vehicle();
            var owners = _context.Owners.AsQueryable();
            var owner = listOfOwners.Where(o => o.Email == email).First();
            vehicle.OwnerId = owner.OwnerId;
            post.Owner = owner;

            vehicle.Owner = owner;
            post.OwnerId = owner.OwnerId;
            post.Vehicle = vehicle;
            post.Title = createPost.Title;
            post.Vehicle.Manufacturer = createPost.Manufacturer;
            post.Vehicle.Model = createPost.Model;
            post.Vehicle.Year = createPost.Year;
            post.Vehicle.Type = createPost.Type;
            post.Vehicle.Color = createPost.Color;
            post.MaxDaysOfRent = createPost.MaxDaysOfRent;
            post.Body = createPost.Body;
            post.City = createPost.City;
            post.CostPerDay = createPost.CostPerDay;
            post.ThumbnailUrl = createPost.ThumbnailUrl;

            DateTime date = DateTime.Now;
            DateTime dateOnly = date.Date;
            DateTime today = DateTime.ParseExact(dateOnly.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            post.Created = DateOnly.FromDateTime(today);

            _context.Add(vehicle);
            _context.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Index","Profile");
        }
    }
}
