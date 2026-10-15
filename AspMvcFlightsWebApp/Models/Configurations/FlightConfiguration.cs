using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspMvcFlightsWebApp.Models.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.Id);
            builder.HasAlternateKey(f => f.Title);
            builder.Property(f => f.Title)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.HasOne(f => f.Airline)
                   .WithMany(a => a.Flights)
                   .HasForeignKey(f => f.AirlineId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Property(f => f.Date)
                   .HasDefaultValueSql("GETDATE()");
            builder.HasOne(f => f.Departure)
                   .WithMany(a => a.Flights)
                   .HasForeignKey(f => f.DapartueId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
