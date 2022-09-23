using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using carsharing.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace carsharing.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> rm;

        public RoleController(RoleManager<IdentityRole> rm)
        {
            this.rm = rm;
        }

        /*[Authorize(Roles = "Admin")]*/
        public IActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("-------------------------------");

            var roles = rm.Roles.ToList();
            return View(roles);
        }

        /*[Authorize(Roles="Admin")]*/
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await rm.CreateAsync(role);
            return RedirectToAction("Index");
        }

    }
}
