using AspMvcFlightsWebApp.Areas.Dashboard.Models;
using AspMvcFlightsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsWebApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AirlineController : Controller
    {
        private readonly FlightsDbContext flightsDbContext;
        private readonly DashboardDbContext dashboardDbContext;

        string imagesDirecory = @$"{Directory.GetCurrentDirectory()}\wwwroot\images";

        public AirlineController()
        {
            flightsDbContext = new FlightsDbContext();
            dashboardDbContext = new DashboardDbContext();
        }

        public async Task<IActionResult> Index()
        {
            ViewData["MenuItems"] = await dashboardDbContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Airlines";

            return View(await flightsDbContext.Airlines.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewData["MenuItems"] = await dashboardDbContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Airlines";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Logo")] Airline airline)
        {
            ViewData["MenuItems"] = await dashboardDbContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Airlines";

            if(ModelState.IsValid)
            {
                if(Request.Form.Count > 0)
                {
                    var logo = Request.Form.Files[0];

                    using FileStream file = new(@$"{imagesDirecory}\{logo.FileName}", FileMode.Create);
                    await logo.CopyToAsync(file);

                    airline.Logo = logo.FileName;
                }

                flightsDbContext.Add(airline);
                await flightsDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(airline);
        }
    
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["MenuItems"] = await dashboardDbContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Airlines";

            if (id is null)
                return NotFound();

            var airline = await flightsDbContext.Airlines
                                                .FindAsync(id);

            if (airline is null)
                return NotFound();

            return View(airline);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["MenuItems"] = await dashboardDbContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Airlines";

            if(id is null) return NotFound();

            var airline = await flightsDbContext.Airlines.FindAsync(id);

            if(airline is null) return NotFound();

            return View(airline);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Logo")] Airline airline)
        {
            ViewData["MenuItems"] = await dashboardDbContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Airlines";

            if(id != airline.Id) return NotFound();

            if(ModelState.IsValid)
            {
                try
                {
                    if (Request.Form.Count > 0)
                    {
                        var logo = Request.Form.Files[0];

                        using FileStream file = new(@$"{imagesDirecory}\{logo.FileName}", FileMode.Create);
                        await logo.CopyToAsync(file);

                        airline.Logo = logo.FileName;
                    }
                    flightsDbContext.Update(airline);
                    await flightsDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlineExists(airline.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(airline);
        }
    
        private bool AirlineExists(int? id)
        {
            return flightsDbContext.Airlines.Any(a => a.Id == id);
        }
    }
}
