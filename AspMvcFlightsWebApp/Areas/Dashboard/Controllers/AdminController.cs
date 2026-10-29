using AspMvcFlightsWebApp.Areas.Dashboard.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcFlightsWebApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            using(DashboardDbContext dbContext = new())
            {
                ViewData["MenuItems"] = dbContext.MainMenuItems.ToList();
            }

            return View();
        }
    }
}
