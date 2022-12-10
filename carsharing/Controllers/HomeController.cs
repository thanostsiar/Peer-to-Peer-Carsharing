using carsharing.Models;
using carsharing.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace carsharing.Controllers
{
    [AllowAnonymous]
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

        public async Task <IActionResult> Index()
        {
            var search = new SearchBar();

            var HomeView = new ResultsViewModel(null, 0)
            {
                SearchBar = search
            };

            return View(HomeView);
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