using carsharing.Models;
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
        public IActionResult Details(int id)
        {
            var posts = FetchPosts();

            var currentPost = posts.Where(post => post.PostId == id).FirstOrDefault();

            return View(currentPost);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(Post post_com)
        {
            string email = "";
            var listOfRenters = await _context.Renters.ToListAsync();
            if (TempData.ContainsKey("Email"))
            {
                email = TempData["Email"].ToString();
                foreach(var renter in listOfRenters)
                {
                    if (email == renter.Email)
                    {
                        PostComment postcomment = new PostComment();
                        postcomment.PostId = post_com.PostId;
                        postcomment.RenterId = renter.RenterId;
                        postcomment.VehicleId = post_com.VehicleId;
                        DateTime date = DateTime.Now;
                        DateTime dateOnly = date.Date;
                        DateTime today = DateTime.ParseExact(dateOnly.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        postcomment.Created = DateOnly.FromDateTime(today);
                        postcomment.Rating = post_com.Rating;
                        postcomment.Body = post_com.Body;
                        _context.Add(postcomment);
                        _context.SaveChanges();
                        break;
                    }
                }
            }
            return RedirectToAction("Index", "Home");

        }

    }
}
