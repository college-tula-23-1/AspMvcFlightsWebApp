using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsWebApp.Models
{
    public class Flight
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = null!;

        public Airline? Airline { get; set; }
        public int? AirlineId { get; set; }

        public Airport? Departure { get; set; }
        public int? DepartureId { get; set; }

        public Airport? Arrival { get; set; }
        public int? ArrivalId { get; set; }

        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
