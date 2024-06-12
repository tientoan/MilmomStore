using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilmomStore.Server.Migrations
{
    public partial class InitialDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "053d5b34-b408-4d58-9cf9-e9e859bc94ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be66a18a-eeb5-4535-b279-3d6d60083f2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1aeabae-9e2d-411c-8faa-644003c09382");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e22fe111-fcef-42f3-969c-ad0fd6e5b5e5");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "053d5b34-b408-4d58-9cf9-e9e859bc94ac", "48bb6122-ef85-426d-bc65-05c91633d100", "Admin", "ADMIN" },
                    { "be66a18a-eeb5-4535-b279-3d6d60083f2f", "7cdd6863-1bbc-47f5-9ab7-d43716fe7927", "Staff", "STAFF" },
                    { "e1aeabae-9e2d-411c-8faa-644003c09382", "51b4e27c-fc7b-417f-bbab-82d4169bbcd8", "Customer", "CUSTOMER" },
                    { "e22fe111-fcef-42f3-969c-ad0fd6e5b5e5", "c22f4ce7-ac33-4050-b381-5c34d23b8e54", "Manager", "MANAGER" }
                });
        }
    }
}
