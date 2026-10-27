using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspMvcFlightsWebApp.Models.ModelsConfigurations
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasAlternateKey(a => a.Title);
            builder.HasOne(a => a.City)
                   .WithMany(c => c.Airports)
                   .HasForeignKey(a => a.CityId);
        }
    }
}
