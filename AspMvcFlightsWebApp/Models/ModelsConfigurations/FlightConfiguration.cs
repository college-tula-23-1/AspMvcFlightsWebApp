using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspMvcFlightsWebApp.Models.ModelsConfigurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.Property(f => f.Date)
                   .HasDefaultValueSql("GETDATE()");
            builder.Property(f => f.Time)
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
