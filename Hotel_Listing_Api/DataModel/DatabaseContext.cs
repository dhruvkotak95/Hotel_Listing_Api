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
    }
}
