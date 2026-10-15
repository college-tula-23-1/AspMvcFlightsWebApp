using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsWebApp.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public List<Airport>? Airports { get; set; }
    }
}
