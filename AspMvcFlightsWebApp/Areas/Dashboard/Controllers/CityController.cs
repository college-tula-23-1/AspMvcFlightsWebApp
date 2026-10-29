using AspMvcFlightsWebApp.Areas.Dashboard.Models;
using AspMvcFlightsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsWebApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CityController : Controller
    {
        FlightsDbContext flightsContext = new();
        DashboardDbContext dashboardContext = new();


        // GET All
        public async Task<IActionResult> Index()
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Cities";

            return View(await flightsContext.Cities.ToListAsync());
        }

        // GET Create
        public async Task<IActionResult> Create()
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            return View();
        }

        // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Title")] City city)
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();

            if(ModelState.IsValid)
            {
                flightsContext.Cities.Add(city);
                await flightsContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(city);
        }
    }
}
