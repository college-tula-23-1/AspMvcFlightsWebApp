using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspMvcFlightsWebApp.Models.Configurations
{
    public class AirlineConfiguration : IEntityTypeConfiguration<Airline>
    {
        public void Configure(EntityTypeBuilder<Airline> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasAlternateKey(a => a.Title);
            builder.HasMany(a => a.Flights)
                   .WithOne(f => f.Airline);
        }
    }
}
