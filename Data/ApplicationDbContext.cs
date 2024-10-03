using inz.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace inz.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Continent> continents { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Airport> airports { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<Trip> trips { get; set; }
        public DbSet<TripPurchase> tripPurchases { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
