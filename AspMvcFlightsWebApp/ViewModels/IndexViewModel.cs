using AspMvcFlightsWebApp.Models;

namespace AspMvcFlightsWebApp.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Flight> Flights { get; set; } = new List<Flight>();
        public SortViewModel SortViewModel { get; set; } = new(SortState.AirlineAsc);
    }
}
