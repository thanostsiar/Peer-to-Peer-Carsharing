using Microsoft.AspNetCore.Mvc;

namespace carsharing.Controllers
{
    public class VehiclesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
