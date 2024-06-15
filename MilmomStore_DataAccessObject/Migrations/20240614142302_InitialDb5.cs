using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilmomStore_DataAccessObject.Migrations
{
    public partial class InitialDb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11c6cbc9-f45b-413b-851c-c79e20fa1142");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36d94568-871e-4cc3-bb39-3049a7b9be1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6a83981-2a46-49c5-b1d3-ead1ec170e2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e99618f6-ccdb-433f-a051-903382645066");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11c6cbc9-f45b-413b-851c-c79e20fa1142", "79aa2dbc-dfa7-432f-8b4b-5cc18252c2fc", "Customer", "CUSTOMER" },
                    { "36d94568-871e-4cc3-bb39-3049a7b9be1e", "1d379941-ba95-4af5-9d07-62426187f8a6", "Manager", "MANAGER" },
                    { "e6a83981-2a46-49c5-b1d3-ead1ec170e2b", "9191e9b9-9fe6-4174-ac77-faeedb544aa5", "Admin", "ADMIN" },
                    { "e99618f6-ccdb-433f-a051-903382645066", "1cf9f73a-50db-497f-bd78-30c7a15f64dd", "Staff", "STAFF" }
                });
        }
    }
}
