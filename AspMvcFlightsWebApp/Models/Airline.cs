using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsWebApp.Models
{
    public class Airline
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        public string? Logo { get; set; }
        public string? Description { get; set; }

        public List<Flight>? Flights { get; set; }
    }
}
