using AspMvcFlightsWebApp.Areas.Dashboard.Models;
using AspMvcFlightsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsWebApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FlightController : Controller
    {
        FlightsDbContext _context = new();
        DashboardDbContext dashboardContext = new();
        public async Task<IActionResult> Index()
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Flights";
            return View(await _context.Flights
                                      .Include(f => f.Airline)
                                      .Include(f => f.Arrival)
                                      .Include(f => f.Departure)
                                      .ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Flights";
            ViewData["Airlines"] = await _context.Airlines.ToListAsync();
            ViewData["Airports"] = await _context.Airports.ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Title,Date,Time,Airline,AirlineId,Departure,DepartureId,Arrival,ArrivalId")] Flight flight)
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Flights";

            if (ModelState.IsValid)
            {
                _context.Flights.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }
    
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Flights";

            if (id is null) return NotFound();

            var flight = await _context.Flights
                                      .Include(f => f.Airline)
                                      .Include(f => f.Arrival)
                                      .Include(f => f.Departure)
                                      .FirstOrDefaultAsync(f => f.Id == id);
            
            if(flight is null) return NotFound();

            return View(flight);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();

            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Flights";

            ViewData["Airlines"] = await _context.Airlines.ToListAsync();
            ViewData["Airports"] = await _context.Airports.ToListAsync();

            var flight = await _context.Flights
                                      .Include(f => f.Airline)
                                      .Include(f => f.Arrival)
                                      .Include(f => f.Departure)
                                      .FirstOrDefaultAsync(f => f.Id == id);

            if (flight is null) return NotFound();
            
            return View(flight);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,
            [Bind("Id,Title,Date,Time,Airline,AirlineId,Departure,DepartureId,Arrival,ArrivalId")] Flight flight)
        {
            if (id is null) return NotFound();

            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Flights";
            ViewData["Airlines"] = await _context.Airlines.ToListAsync();
            ViewData["Airports"] = await _context.Airports.ToListAsync();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    if (FlightsExists(flight.Id))
                        throw;
                    else
                        return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();

            ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
            ViewData["Title"] = "Flights";

            var flight = await _context.Flights
                                      .Include(f => f.Airline)
                                      .Include(f => f.Arrival)
                                      .Include(f => f.Departure)
                                      .FirstOrDefaultAsync(f => f.Id == id);

            if (flight is null) return NotFound();

            return View(flight);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if(flight is null) return NotFound();

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightsExists(int? id)
        {
            return _context.Flights.Any(f => f.Id == id);
        }
    }
}
