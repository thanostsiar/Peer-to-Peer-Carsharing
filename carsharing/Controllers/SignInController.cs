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

            var listOfRenters = await _context.Renters.ToListAsync();

            foreach (var renter in listOfRenters)
            {
                if (signIn.Email == renter.Email && signIn.Password == renter.Password)
                {
                    return View("Temp", renter);
                }
                else
                {
                    TempData["msg"] = "<script>alert('The Email or Password is incorrect, please try again.');</script>";
                }
                

            }
            return RedirectToAction("Index");
        }

        private bool RenterExists(int id)
        {
            return (_context.Renters?.Any(e => e.RenterId == id)).GetValueOrDefault();
        }

    }
}
