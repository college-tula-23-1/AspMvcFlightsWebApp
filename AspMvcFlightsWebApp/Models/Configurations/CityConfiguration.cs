using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace AspMvcFlightsWebApp.Models.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasAlternateKey(c => c.Title);
            builder.HasMany(c => c.Airports)
                   .WithOne(a => a.City);
        }
    }
}
