using AspMvcFlightsWebApp.Models;
using AspMvcFlightsWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsWebApp.Controllers
{
    

    public class HomeController : Controller
    {
        FlightsDbContext context = new();
        public async Task<IActionResult> Index(SortState current, SortState property)
        {
            ViewData["Title"] = "Flights Shedule";
            
            var flights = await context.Flights
                                 .Include(f => f.Airline)
                                 .Include(f => f.Departure)
                                    .ThenInclude(d => d.City)
                                 .Include(f => f.Arrival)
                                    .ThenInclude(d => d.City)
                                 .OrderBy(f => f.Airline.Title)
                                 .ToListAsync();

            flights = property switch
            {
                SortState.AirlineDesc => flights.OrderByDescending(f => f.Airline.Title).ToList(),
                SortState.DepartureAsc => flights.OrderBy(f => f.Departure.Title).ToList(),
                SortState.DepartureDesc => flights.OrderByDescending(f => f.Departure.Title).ToList(),
                SortState.ArrivalAsc => flights.OrderBy(f => f.Arrival.Title).ToList(),
                SortState.ArrivalDesc => flights.OrderByDescending(f => f.Arrival.Title).ToList(),
                SortState.DateAsc => flights.OrderBy(f => f.Date).ToList(),
                SortState.DateDesc => flights.OrderByDescending(f => f.Date).ToList(),
                _ => flights.OrderBy(f => f.Airline.Title).ToList(),
            };

            IndexViewModel indexViewModel = new()
            {
                Flights = flights,
                SortViewModel = new SortViewModel(property)
            };
                                 
            return View(indexViewModel);
        }
    }
}
