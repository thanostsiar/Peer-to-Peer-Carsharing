using Microsoft.AspNetCore.Mvc;
using carsharing.Models;
using Microsoft.EntityFrameworkCore;
using carsharing.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace carsharing.Controllers
{
    [Authorize(Roles="Owner,Renter")]
    public class ProfileController : Controller
    {
        // get the database context
        private unipicarsContext _context;

        public ProfileController(unipicarsContext context)
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
        public async Task<IActionResult> Index()
        {
            Renter r = new Renter();
            Owner o = new Owner();
            string email = "";
            bool isOwner = false;
            string label ="";
            string ErrorMessage = "";

            var listOfRenters = await _context.Renters.ToListAsync();
            var listOfOwners = await _context.Owners.ToListAsync();

            if (TempData.ContainsKey("Email"))
            {
                email = TempData["Email"].ToString();


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
                        label = "'s listings:";
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
                            label = "'s previously rented cars:";
                        }
                    }
                }
            }

            var posts = FetchPosts();

            var ownerPosts = posts.Where(post => post.Owner.Email == o.Email);

            if (!ownerPosts.Any())
            {
                var message = "Oops! Seems like there are no cars found!";

                ErrorMessage = message;
            }

            var OwnerRenter = new ResultsViewModel(null, 0, ErrorMessage)
            {
                Owner = o,
                Renter = r,
                Posts = ownerPosts,
            };

            return View(OwnerRenter);
        }
    }
}
