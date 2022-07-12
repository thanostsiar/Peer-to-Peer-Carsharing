using Microsoft.AspNetCore.Mvc;
using carsharing.Models;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task <IActionResult> Index(CreatePost createPost)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            string email = null;
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
            post.CostPerDay = createPost.CostPerDay;/*
            post.ThumbnailUrl = createPost.ThumbnailUrl;*/
            DateTime date = DateTime.Now;
            DateTime dateOnly = date.Date;
            DateTime today = DateTime.ParseExact(dateOnly.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            post.Created = DateOnly.FromDateTime(today);

            _context.Add(vehicle);
            _context.Add(post);
            _context.SaveChanges();

            TempData["Title"] = post.Title;
            TempData["Manufacturer"] = post.Vehicle.Manufacturer;
            TempData["Model"] = post.Vehicle.Model;
            TempData["Year"] = post.Vehicle.Year;
            TempData["Type"] = post.Vehicle.Type;
            TempData["Color"] = post.Vehicle.Color;
            TempData["MaxDaysOfRent"] = post.MaxDaysOfRent;
            TempData["Body"] = post.Body;
            TempData["CostPerDay"] = post.CostPerDay;
            TempData["City"] = post.City;/*
            TempData["ThumbnailUrl"] = post.ThumbnailUrl;*/
            TempData["Created"] = post.Created;
            return View("Index");
        }
    }
}
