using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilmomStore_DataAccessObject.Migrations
{
    public partial class FixImageAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "39f37c8c-2379-4793-a07d-92d6aa222952");
            //
            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "70e5ff66-0b3f-4efb-83f0-0ca055e5394f");
            //
            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "8e270673-94d8-4cac-9d3e-df7c9472d2fa");
            //
            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "b70707db-7811-4937-83bf-ffc472c41b41");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //     values: new object[,]
            //     {
            //         { "39f37c8c-2379-4793-a07d-92d6aa222952", "a7080e2a-6213-4e3e-9d9d-11c453fdd402", "Customer", "CUSTOMER" },
            //         { "70e5ff66-0b3f-4efb-83f0-0ca055e5394f", "6ab62be2-271b-4943-ab13-8ba23f1e7dbc", "Admin", "ADMIN" },
            //         { "8e270673-94d8-4cac-9d3e-df7c9472d2fa", "bf5f5b9d-c49b-459e-8136-7e7ee9e91e3f", "Manager", "MANAGER" },
            //         { "b70707db-7811-4937-83bf-ffc472c41b41", "36e5a9ba-cb2f-4a0f-b3b4-dc3f9b3e3a7e", "Staff", "STAFF" }
            //     });
        }
    }
}
