using System.ComponentModel.DataAnnotations;

namespace AspMvcFlightsWebApp.Models
{
    public class Airline
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public string? Logo { get; set; }
    }
}
