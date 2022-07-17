using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using carsharing.Models;

namespace carsharing.Controllers
{
    public class SignInController : Controller
    {
        // get the database context
        private readonly unipicarsContext _context;

        // initialize the context
        public SignInController(unipicarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignIn signIn)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            bool isOwner = false;
            bool renterExists = true;
            Owner o = new Owner();

            var listOfRenters = await _context.Renters.ToListAsync();
            var listOfOwners = await _context.Owners.ToListAsync();

            foreach (var owner in listOfOwners)
            {
                if (signIn.Email == owner.Email && signIn.Password == owner.Password)
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

            if (isOwner == true)
            {
                TempData["FirstName"] = o.FirstName;
                TempData["LastName"] = o.LastName;
                TempData["Age"] = o.Age;
                TempData["Email"] =o.Email;
                TempData["Phone"] = o.Phone;
                TempData["Phone"] = o.Phone;
                TempData["ProfilePicture"] = o.ProfilePicture;
                TempData["Role"] = "Owner";

                return RedirectToAction("Index", "Profile");
            }
            else
            {
                foreach (var renter in listOfRenters)
                {
                    if (signIn.Email == renter.Email && signIn.Password == renter.Password)
                    {
                        TempData["FirstName"] = renter.FirstName;
                        TempData["LastName"] = renter.LastName;
                        TempData["Age"] = renter.Age;
                        TempData["Email"] = renter.Email;
                        TempData["Phone"] = renter.Phone;
                        TempData["Role"] = "Renter";

                        return RedirectToAction("Index", "Profile");
                    }
                    else
                    {
                        renterExists = false;
                    }
                }
                if (!renterExists)
                {
                    TempData["Error"] = " Wrong Email and/or Password";
                    return View("Index");
                }
            }
            return View("Index");
        }

        private bool RenterExists(int id)
        {
            return (_context.Renters?.Any(e => e.RenterId == id)).GetValueOrDefault();
        }

    }
}
