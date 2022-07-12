using Microsoft.AspNetCore.Mvc;
using carsharing.Models;
using Microsoft.EntityFrameworkCore;

namespace carsharing.Controllers
{
    public class CreatePostController : Controller
    {
        // get the database context
        private unipicarsContext _context;

        // initialize the context
        public CreatePostController(unipicarsContext context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
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
            return View("Index");
        }
    }
}
