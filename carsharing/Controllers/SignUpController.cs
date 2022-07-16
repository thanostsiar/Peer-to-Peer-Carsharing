using Microsoft.AspNetCore.Mvc;
using carsharing.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace carsharing.Controllers
{
    public class SignUpController : Controller
    {
        // get the database context
        private unipicarsContext _context;

        // initialize the context
        public SignUpController(unipicarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUp signUp)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            bool exists = false;
            var listOfRenters = await _context.Renters.ToListAsync();

            foreach (var renter_ in listOfRenters)
            {
                if (signUp.Email == renter_.Email)
                {
                    exists = true;
                    return View("Index");
                }
            } 
                
            Renter renter = new Renter();
            renter.FirstName = signUp.FirstName;
            renter.LastName = signUp.LastName;
            renter.Age = signUp.Age;
            renter.ProfilePicture = "http://srnet.ca/wp-content/uploads/2017/01/Default-Profile.png";
            renter.Experience = 1.2;
            renter.Password = signUp.Password;
            renter.Email = signUp.Email;
            renter.Phone = signUp.Phone;

            _context.Add(renter);
            await _context.SaveChangesAsync();

            TempData["FirstName"] = renter.FirstName;
            TempData["LastName"] = renter.LastName;
            TempData["Age"] = renter.Age;
            TempData["Email"] = renter.Email;
            TempData["Phone"] = renter.Phone;
            TempData["ProfilePicture"] = renter.ProfilePicture;
            TempData["Role"] = "Renter";

            return RedirectToAction("Index", "Profile");
        }


        private bool RenterExists(int id)
        {
            return (_context.Renters?.Any(e => e.RenterId == id)).GetValueOrDefault();
        }
    }
}
