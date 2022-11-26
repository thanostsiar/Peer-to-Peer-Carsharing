using carsharing.Areas.Identity.Data;
using carsharing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace carsharing.Controllers
{
    public class RenterController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<Admin> _logger;

        public RenterController(SignInManager<User> signInManager, ILogger<Admin> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
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
            await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Index","Profile");
        }
    }
}
