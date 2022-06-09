using Microsoft.AspNetCore.Mvc;

namespace carsharing.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
