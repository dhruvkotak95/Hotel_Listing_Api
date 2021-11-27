using Hotel_Listing_Api.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Listing_Api.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
