using Microsoft.AspNetCore.Mvc;

namespace carsharing.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
