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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(CreatePost createPost)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            Post post = new Post();
            post.Title = createPost.Title;
            post.Vehicle.Manufacturer = createPost.Manufacturer;
            post.Vehicle.Model = createPost.Model;
            post.Vehicle.Year = createPost.Year;
            post.Vehicle.Type = createPost.Type;
            post.Vehicle.Color = createPost.Color;
            post.MaxDaysOfRent = createPost.MaxDaysOfRent;
            post.Body = createPost.Body;


            TempData["Title"] = post.Title;
            TempData["Manufacturer"] = post.Vehicle.Manufacturer;
            TempData["Model"] = post.Vehicle.Model;
            TempData["Year"] = post.Vehicle.Year;
            TempData["Type"] = post.Vehicle.Type;
            TempData["Color"] = post.Vehicle.Color;
            TempData["MaxDaysOfRent"] = post.MaxDaysOfRent;
            TempData["Body"] = post.Body;

            return View("Index");
        }
    }
}
