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

        public IActionResult Index()
        {
            return View();
        }
    }
}
