using Microsoft.AspNetCore.Mvc;
using carsharing.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using carsharing.ViewModels;

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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Owner o = new Owner();
            string email = "";

            var listOfOwners = await _context.Owners.ToListAsync();

            if (TempData.ContainsKey("Email"))
            {
                email = TempData["Email"].ToString();

                foreach (var owner in listOfOwners)
                {
                    if (email == owner.Email)
                    {
                        o.FirstName = owner.FirstName;
                        o.LastName = owner.LastName;
                        o.Email = owner.Email;
                        o.Age = owner.Age;
                        o.Phone = owner.Phone;
                        o.ProfilePicture = owner.ProfilePicture;
                        break;
                    }
                }
            }

            var OwnerRenter = new ResultsViewModel(null, 0)
            {
                Owner = o,
                Renter = new Renter()
            };

            return View(OwnerRenter);
        }


        [HttpPost]
        public async Task <IActionResult> Index(CreatePost createPost)
        {
            // Saving the first name from the temp view, in order for his name to be visible in the navbar.

            string first_name = TempData["FirstName"].ToString();
            Owner ownr = new Owner();
            ownr.FirstName = first_name;

            var CreatePost = new ResultsViewModel(null, 0)
            {
                Renter = new Renter(),
                Owner = ownr
            };

            if (!ModelState.IsValid)
            {
                return View(CreatePost);
            }

            string email = "";
            Renter r = new Renter();

            var listOfOwners = await _context.Owners.ToListAsync();

            if (TempData.ContainsKey("Email"))
            {
                email = TempData["Email"].ToString();
            }

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
