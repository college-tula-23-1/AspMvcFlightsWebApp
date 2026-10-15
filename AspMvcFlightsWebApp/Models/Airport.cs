using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsWebApp.Models
{
    public class Airport
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [StringLength(3)]
        public string? IataCode { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public List<Flight>? Flights { get; set; }
    }
}
