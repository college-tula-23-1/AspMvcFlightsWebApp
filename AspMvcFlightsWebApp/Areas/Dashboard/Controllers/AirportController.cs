
using AspMvcFlightsWebApp.Areas.Dashboard.Models;
using AspMvcFlightsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Area("Dashboard")]
public class AirportController : Controller
{
    FlightsDbContext _context = new();
    DashboardDbContext dashboardContext = new();

    // GET: AIRPORTS
    public async Task<IActionResult> Index()    
    {
        ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
        ViewData["Title"] = "Airports";

        return View(await _context.Airports
                                  .Include(a => a.City)
                                  .ToListAsync());
    }

    // GET: AIRPORTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var airport = await _context.Airports
            .FirstOrDefaultAsync(m => m.Id == id);
        if (airport == null)
        {
            return NotFound();
        }

        return View(airport);
    }

    // GET: AIRPORTS/Create
    public async Task<IActionResult> Create()
    {
        ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
        ViewData["Title"] = "Airports";
        ViewData["Cities"] = await _context.Cities.ToListAsync();

        return View();
    }

    // POST: AIRPORTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,City,CityId")] Airport airport)
    {
        ViewData["MenuItems"] = await dashboardContext.MainMenuItems.ToListAsync();
        ViewData["Title"] = "Airports";

        if (ModelState.IsValid)
        {
            _context.Add(airport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(airport);
    }

    // GET: AIRPORTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var airport = await _context.Airports.FindAsync(id);
        if (airport == null)
        {
            return NotFound();
        }
        return View(airport);
    }

    // POST: AIRPORTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,City,CityId")] Airport airport)
    {
        if (id != airport.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(airport);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportExists(airport.Id))
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
        return View(airport);
    }

    // GET: AIRPORTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var airport = await _context.Airports
            .FirstOrDefaultAsync(m => m.Id == id);
        if (airport == null)
        {
            return NotFound();
        }

        return View(airport);
    }

    // POST: AIRPORTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var airport = await _context.Airports.FindAsync(id);
        if (airport != null)
        {
            _context.Airports.Remove(airport);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AirportExists(int? id)
    {
        return _context.Airports.Any(e => e.Id == id);
    }
}
