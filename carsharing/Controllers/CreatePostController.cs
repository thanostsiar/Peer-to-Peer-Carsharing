using Microsoft.AspNetCore.Mvc;
using carsharing.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using carsharing.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using carsharing.Areas.Identity.Data;

namespace carsharing.Controllers
{
    [Authorize(Roles = "Owner")]
    public class CreatePostController : Controller
    {
        // get the database context
        private unipicarsContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<User> _logger;

        // initialize the context
        public CreatePostController(SignInManager<User> signInManager, ILogger<User> logger, unipicarsContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
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

            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _signInManager.UserManager.GetUserAsync(User);

            Post post = new Post();
            Vehicle vehicle = new Vehicle();

            post.Vehicle = vehicle;
            post.Vehicle.Manufacturer = createPost.Manufacturer;
            post.Vehicle.Model = createPost.Model;
            post.Vehicle.Year = createPost.Year;
            post.Vehicle.Type = createPost.Type;
            post.Vehicle.Color = createPost.Color;

            post.Owner = await _context.Owners.FindAsync(user.Id);
            vehicle.Owner = post.Owner;

            post.Title = createPost.Title;
            post.MaxDaysOfRent = createPost.MaxDaysOfRent;
            post.Body = createPost.Body;
            post.City = createPost.City;
            post.CostPerDay = createPost.CostPerDay;
            post.ThumbnailUrl = createPost.ThumbnailUrl;

            DateTime date = DateTime.Now;
            DateTime dateOnly = date.Date;
            DateTime today = DateTime.ParseExact(dateOnly.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            post.Created = DateOnly.FromDateTime(today);

            await _context.AddAsync(vehicle);
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","Profile");
        }
    }
}
