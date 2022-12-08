using carsharing.Areas.Identity.Data;
using carsharing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using carsharing.Models;

namespace carsharing.Controllers
{
    public class RenterController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<Admin> _logger;
        private unipicarsContext _context;

        public RenterController(SignInManager<User> signInManager, ILogger<Admin> logger, unipicarsContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public IActionResult RentYourCar()
        {
            return View();
        }

        public async Task<IActionResult> BecomeOwner(String id)
        {
            var user = await _signInManager.UserManager.FindByIdAsync(id);

            await _signInManager.UserManager.RemoveFromRoleAsync(user, "Renter");
            await _signInManager.UserManager.AddToRoleAsync(user, "Owner");

            var renter = new Renter();

            renter.RenterId = user.Id;

            _context.Renters.Remove(renter);

            Owner owner = new Owner();
            owner.OwnerId = user.Id;

            await _context.Owners.AddAsync(owner);

            await _context.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Index","Profile");
        }
    }
}
