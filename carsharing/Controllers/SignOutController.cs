using Microsoft.AspNetCore.Mvc;

namespace carsharing.Controllers
{
    public class SignOutController : Controller
    {
        public IActionResult Index()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
