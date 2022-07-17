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
            Owner o = new Owner();
            Renter r = new Renter();
            string email = "";
            bool isOwner = false;
            bool isOnline = false;

            var listOfRenters = await _context.Renters.ToListAsync();
            var listOfOwners = await _context.Owners.ToListAsync();

            if (TempData.ContainsKey("Email"))
            {
                email = TempData["Email"].ToString();
                isOnline = true;

                foreach (var owner in listOfOwners)
                {
                    if (email == owner.Email)
                    {
                        isOwner = true;
                        o.FirstName = owner.FirstName;
                        o.LastName = owner.LastName;
                        o.Email = owner.Email;
                        o.Age = owner.Age;
                        o.Phone = owner.Phone;
                        o.ProfilePicture = owner.ProfilePicture;
                        break;
                    }
                }

                if (isOwner == false)
                {
                    foreach (var renter in listOfRenters)
                    {
                        if (email == renter.Email)
                        {
                            r.FirstName = renter.FirstName;
                            r.LastName = renter.LastName;
                            r.Email = renter.Email;
                            r.Age = renter.Age;
                            r.Phone = renter.Phone;
                            r.ProfilePicture = renter.ProfilePicture;
                            break;
                        }
                    }
                }
            }

            if (isOnline == true)
            {
                TempData["Online"] = "Yes";
            }

            var posts = FetchPosts();

            var currentPost = posts.Where(post => post.PostId == id).FirstOrDefault();

            var Post = new ResultsViewModel(null, 0)
            {
                Renter = r,
                Owner = o,
                Post = currentPost
            };

            return View(Post);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync([Bind(Prefix = "Post")] Post post_com)
        {
            string email = "";
            bool isOwner = false;
            bool isOnline = false;
            var listOfRenters = await _context.Renters.ToListAsync();
            var listOfOwners = await _context.Owners.ToListAsync();
            if (TempData.ContainsKey("Email"))
            {
                email = TempData["Email"].ToString();
                isOnline = true;
                foreach (var owner in listOfOwners)
                {
                    if (email == owner.Email)
                    {
                        PostComment postcomment = new PostComment();
                        postcomment.PostId = post_com.PostId;
                        postcomment.RenterId = owner.OwnerId;
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
                if (isOwner == false)
                {
                    foreach (var renter in listOfRenters)
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
            }
            if (isOnline == true)
            {
                TempData["Online"] = "Yes";
            }
            return RedirectToAction("Details", new { id=post_com.PostId});

        }

    }
}
