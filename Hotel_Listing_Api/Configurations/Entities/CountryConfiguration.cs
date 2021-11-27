using Hotel_Listing_Api.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel_Listing_Api.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}
