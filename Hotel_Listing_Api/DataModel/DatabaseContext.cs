using Microsoft.EntityFrameworkCore;

namespace Hotel_Listing_Api.DataModel
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> countries { get; set; }
        public DbSet<Hotel> hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "India",
                    CountryCode = "IND"
                },
                new Country
                {
                    Id = 2,
                    Name = "Canada",
                    CountryCode = "CN"
                },
                new Country
                {
                    Id = 3,
                    Name = "America",
                    CountryCode = "US"
                });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel - 1",
                    Rating = 1.2,
                    Address = "1 Near main market",
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Hotel - 2",
                    Rating = 2.2,
                    Address = "2 Near main market",
                    CountryId = 2
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Hotel - 3",
                    Rating = 3.2,
                    Address = "3 Near main market",
                    CountryId = 3
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Hotel - 4",
                    Rating = 4.2,
                    Address = "4 Near main market",
                    CountryId = 3
                });
        }
    }
}
