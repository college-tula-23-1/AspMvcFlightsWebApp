namespace AspMvcFlightsWebApp.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public int AirlineId { get; set; }
        public Airline Airline { get; set; } = null!;


        public int DapartueId { get; set; }
        public Airport Departure { get; set; } = null!;

        public int ArrivalId { get; set; }
        public Airport Arrival { get; set; } = null!;

        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
