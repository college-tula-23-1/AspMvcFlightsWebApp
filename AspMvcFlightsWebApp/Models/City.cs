using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsWebApp.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "City Title Is Not Empty")]
        public string Title { get; set; } = null!;

        public List<Airport>? Airports { get; set; }
    }
}
