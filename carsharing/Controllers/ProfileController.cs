using Microsoft.AspNetCore.Mvc;
using carsharing.Models;
using Microsoft.EntityFrameworkCore;
using carsharing.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using carsharing.Areas.Identity.Data;

namespace carsharing.Controllers
{
    [Authorize(Roles="Owner,Renter")]
    public class ProfileController : Controller
    {
        // get the database context
        private unipicarsContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<Admin> _logger;

        public ProfileController(SignInManager<User> signInManager, ILogger<Admin> logger, unipicarsContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        private IQueryable<Post> FetchPosts()
        {
            var owners = _context.Owners.AsQueryable();
            var renters = _context.Renters.AsQueryable();
            var vehicles = _context.Vehicles.AsQueryable();
            var postComments = _context.PostComments.AsQueryable();
            var posts = _context.Posts.AsQueryable();

            foreach (var post in posts.ToList())
            {
                var owner = owners.Where(ow => ow.OwnerId == post.OwnerId).First();
                var vehicle = vehicles.Where(vh => vh.VehicleId == post.VehicleId).First();
                var comments = postComments.Where(pc => pc.PostId == post.PostId);

                foreach (var comment in comments.ToList())
                {
                    var renter = renters.Where(r => r.RenterId == comment.RenterId).First();
                    comment.Renter = renter;

                    post.PostComments.Add(comment);
                }

                post.Owner = owner;
                post.Vehicle = vehicle;
            }

            return posts;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);

            UserViewModel userViewModel = new UserViewModel();


            // get his role
            var current_role = await _signInManager.UserManager.GetRolesAsync(user);

            if (current_role.First().Equals("Renter"))
            {
                userViewModel.Role = "Renter";

                // get the renter by searching with the user id
                userViewModel.Renter = _context.Renters.Find(user.Id);
            }
            else
            {
                userViewModel.Role = "Owner";

                // get the owner by searching with the user id
                userViewModel.Owner = _context.Owners.Find(user.Id);
            }

            return View(userViewModel);
        }
    }
}
