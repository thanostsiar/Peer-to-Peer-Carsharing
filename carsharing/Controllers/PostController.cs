using carsharing.Models;
using carsharing.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace carsharing.Controllers
{
    public class PostController : Controller
    {
        // get the database context
        private unipicarsContext _context;

        // initialize the context
        public PostController(unipicarsContext context)
        {
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
        public async Task<IActionResult> Details(int id)
        {

            var posts = FetchPosts();

            var currentPost = posts.Where(post => post.PostId == id).FirstOrDefault();

            var Post = new ResultsViewModel(null, 0)
            {
                Post = currentPost
            };

            return View(Post);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync([Bind(Prefix = "Post")] Post post_com)
        {
            return RedirectToAction("Details", new { id=post_com.PostId});
        }

    }
}
