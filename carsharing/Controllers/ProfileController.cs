using Microsoft.AspNetCore.Mvc;
using carsharing.Models;
using Microsoft.EntityFrameworkCore;
using carsharing.ViewModels;

namespace carsharing.Controllers
{
    public class ProfileController : Controller
    {
        // get the database context
        private unipicarsContext _context;

        public ProfileController(unipicarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Renter r = new Renter();
            Owner o = new Owner();
            string email = "";
            bool isOwner = false;

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
                        }
                    }
                }
            }

            var OwnerRenter = new HomeViewModel
            {
                Renter = r,
                Owner = o
            };
       
            return View(OwnerRenter);
        }
    }
}
