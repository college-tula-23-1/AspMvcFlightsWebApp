using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsWebApp.Areas.Dashboard.Models
{
    public class DashboardDbContext : DbContext
    {
        public DbSet<MainMenuItem> MainMenuItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                   .SetBasePath(Directory.GetCurrentDirectory())
                                                   .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
