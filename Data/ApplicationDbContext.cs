using Biuro_podrozy_praca_inzynierska.Model;
using Microsoft.EntityFrameworkCore;

namespace Biuro_podrozy_praca_inzynierska.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Continent> continents { get; set; }
        public DbSet<Country> country { get; set; }
        public DbSet<Airport> airports { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Trip> trips { get; set; }
        public DbSet<TripPurchase> tripPurchases { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Client> clients { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Continent>()
        //        .HasMany(c => c.Countries)
        //        .WithOne(c => c.Continent)
        //        .HasForeignKey(c => c.ContinentId);
        //}
    }
}
