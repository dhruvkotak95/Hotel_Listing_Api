using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel_Listing_Api.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2d0b2a6-534d-478e-8b1b-54b74f5f63d4", "42a097c6-5e5d-44e6-aafa-bb28d11a4489", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "660d636d-e630-4d82-984a-d8d14bf90563", "9300555f-729f-404b-b30c-c6d16cf33d8e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "660d636d-e630-4d82-984a-d8d14bf90563");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2d0b2a6-534d-478e-8b1b-54b74f5f63d4");
        }
    }
}
