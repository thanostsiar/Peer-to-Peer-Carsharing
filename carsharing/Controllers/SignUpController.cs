using Microsoft.AspNetCore.Mvc;
<<<<<<< Updated upstream
using carsharing.Models;
using Microsoft.EntityFrameworkCore;
=======
using Npgsql;
>>>>>>> Stashed changes

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

            foreach (var renter in listOfRenters)
            {
                if (signUp.Email == renter.Email)
                {
                    exists = true;
                }
            }

            if (exists == false)
            {   
                
                Renter renter = new Renter();
                renter.FirstName = signUp.FirstName;
                renter.LastName = signUp.LastName;
                renter.Age = signUp.Age;
                renter.ProfilePicture = "Skata.png";
                renter.Experience = 1.2;
                renter.Password = signUp.Password;
                renter.Email = signUp.Email;
                renter.Phone = signUp.Phone;

                _context.Add(renter);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
              

            return View();

        }

        private bool RenterExists(int id)
        {
            return (_context.Renters?.Any(e => e.RenterId == id)).GetValueOrDefault();
        }
    }
}
