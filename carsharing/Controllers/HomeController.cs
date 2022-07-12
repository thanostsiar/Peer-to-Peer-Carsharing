using carsharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace carsharing.Controllers
{
    public class HomeController : Controller
    {
        // get the database context
        private unipicarsContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, unipicarsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var search = new SearchBar();
            return View(search);
        }

        public async Task<IActionResult> Online()
        {
            string email = null;
            var listOfRenters = await _context.Renters.ToListAsync();

            if (TempData.ContainsKey("Email"))
            {
                email = TempData["Email"].ToString();
            }

            foreach (var renter in listOfRenters)
            {
                if (email == renter.Email)
                {
                    return View(renter);
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}