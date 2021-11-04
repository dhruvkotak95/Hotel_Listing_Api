using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Listing_Api.Migrations
{
    public partial class Seeding_Hardcoded_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "Id", "CountryCode", "Name" },
                values: new object[] { 1, "IND", "India" });

            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "Id", "CountryCode", "Name" },
                values: new object[] { 2, "CN", "Canada" });

            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "Id", "CountryCode", "Name" },
                values: new object[] { 3, "US", "America" });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "1 Near main market", 1, "Hotel - 1", 1.2 },
                    { 2, "2 Near main market", 2, "Hotel - 2", 2.2000000000000002 },
                    { 3, "3 Near main market", 3, "Hotel - 3", 3.2000000000000002 },
                    { 4, "4 Near main market", 3, "Hotel - 4", 4.2000000000000002 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "countries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
