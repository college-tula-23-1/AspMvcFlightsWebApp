using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsWebApp.Models
{
    public class Airport
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;
        public City? City { get; set; }
        public int? CityId { get; set; }
    }
}
