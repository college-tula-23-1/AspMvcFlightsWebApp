namespace AspMvcFlightsWebApp.Areas.Dashboard.Models
{
    public class MainMenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Controller { get; set; } = null!;

    }
}
