using AspMvcFlightsWebApp.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsWebApp.Models
{
    public class FlightsDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Airport> Airports { get; set; } = null!;
        public DbSet<Airline> Airlines { get; set; } = null!;
        public DbSet<Flight> Flights { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                   .SetBasePath(Directory.GetCurrentDirectory())
                                                   .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new AirportConfiguration());
            modelBuilder.ApplyConfiguration(new AirlineConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
        }
    }
}
