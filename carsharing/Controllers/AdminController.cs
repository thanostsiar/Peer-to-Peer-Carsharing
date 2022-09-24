using carsharing.Areas.Identity.Data;
using carsharing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace carsharing.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<Admin> _logger;

        public AdminController(SignInManager<User> signInManager, ILogger<Admin> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(Admin admin)
        {
            if (ModelState.IsValid)
            {
                // find user by email
                var usr = await _signInManager.UserManager.FindByEmailAsync(admin.Email);

                // get his role
                var current_role = await _signInManager.UserManager.GetRolesAsync(usr);

                if (current_role.First() != "Admin")
                {
                    return RedirectToAction("Index");
                }
                
                var result = await _signInManager.PasswordSignInAsync(admin.Email, admin.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Index", "Home");
                }

            }

            return View("Index");
        }
    }
}
