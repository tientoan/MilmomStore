using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilmomStore_DataAccessObject.Migrations
{
    public partial class SolveAddressProblem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Receiver",
                table: "ShippingInfor",
                newName: "ReceiverName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ShippingInfor",
                newName: "District");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ShippingInfor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DetailAddress",
                table: "ShippingInfor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "ShippingInfor");

            migrationBuilder.DropColumn(
                name: "DetailAddress",
                table: "ShippingInfor");

            migrationBuilder.RenameColumn(
                name: "ReceiverName",
                table: "ShippingInfor",
                newName: "Receiver");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "ShippingInfor",
                newName: "Address");
        }
    }
}
