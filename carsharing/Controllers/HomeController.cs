using carsharing.Models;
using carsharing.ViewModels;
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

        public async Task <IActionResult> Index()
        {
            Renter r = new Renter();
            Owner o = new Owner();
            bool isOwner = false;
            bool isOnline = false;

            var search = new SearchBar();

            var listOfRenters = await _context.Renters.ToListAsync();
            var listOfOwners = await _context.Owners.ToListAsync();

            if (TempData.ContainsKey("Email"))
            {
                string email = TempData["Email"].ToString();
                isOnline = true;

                foreach (var owner in listOfOwners)
                {
                    if (email == owner.Email)
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

                if (isOwner == false)
                {
                    foreach (var renter in listOfRenters)
                    {
                        if (email == renter.Email)
                        {
                            r.FirstName = renter.FirstName;
                            r.LastName = renter.LastName;
                            r.Email = renter.Email;
                            r.Age = renter.Age;
                            r.Phone = renter.Phone;
                            r.ProfilePicture = renter.ProfilePicture;
                            break;
                        }
                    }
                }
            }

            if (isOnline == true)
            {
                TempData["Online"] = "Yes";
            }

            var HomeView = new HomeViewModel
            {
                Renter = r,
                Owner = o,
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