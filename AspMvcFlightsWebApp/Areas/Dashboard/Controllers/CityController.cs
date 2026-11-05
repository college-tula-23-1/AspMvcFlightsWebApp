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
            ViewData["Title"] = "Cities";
            return View();
        }

        // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Title")] City city)
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Cities";

            if (ModelState.IsValid)
            {
                flightsContext.Cities.Add(city);
                await flightsContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(city);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Cities";

            if (id is null)
                return NotFound();

            var city = await flightsContext.Cities
                                           .Include(c => c.Airports)
                                           .FirstOrDefaultAsync(c => c.Id == id);
            if (city is null)
                return NotFound();

            return View(city);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Cities";

            if (id is null) return NotFound();

            var city = await flightsContext.Cities.FindAsync(id);

            if (city is null) return NotFound();

            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Title")] City city)
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Cities";

            if (id != city.Id) return NotFound();

            if(ModelState.IsValid)
            {
                try
                {
                    flightsContext.Update(city);
                    await flightsContext.SaveChangesAsync();
                }
                catch(Exception ex)
                {
                    if (!CityExists(city.Id))
                        NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }
    
        private bool CityExists(int? id)
        {
            return flightsContext.Cities.Any(c => c.Id == id);
        }
    
    }
}
