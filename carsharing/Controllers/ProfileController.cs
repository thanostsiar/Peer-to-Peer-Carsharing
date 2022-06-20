using Microsoft.AspNetCore.Mvc;

namespace carsharing.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
