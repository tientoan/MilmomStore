using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilmomStore_DataAccessObject.Migrations
{
    public partial class InitalDb06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c31e317-a925-4a67-87d1-0ebd3dc284e4", "72128432-9bf3-433d-8d4f-ee55240fcb4c", "Customer", "CUSTOMER" },
                    { "825099c4-eabf-40a0-ba45-de87c4d2888d", "53bf2e90-9090-412b-a8e9-e5c47e2b9c3c", "Admin", "ADMIN" },
                    { "8d2d7f54-afa2-4053-9180-ffec0fedf55a", "695e0fbd-24da-4db3-91ce-56edcd32d1e5", "Manager", "MANAGER" },
                    { "f29cf0c5-1cba-4ba5-a70e-993439981032", "d7ad7148-706c-410d-9376-0a837735c94b", "Staff", "STAFF" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c31e317-a925-4a67-87d1-0ebd3dc284e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "825099c4-eabf-40a0-ba45-de87c4d2888d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d2d7f54-afa2-4053-9180-ffec0fedf55a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f29cf0c5-1cba-4ba5-a70e-993439981032");
        }
    }
}
