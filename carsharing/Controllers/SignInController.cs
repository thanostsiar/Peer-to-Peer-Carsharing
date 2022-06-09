using Microsoft.AspNetCore.Mvc;

namespace carsharing.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
