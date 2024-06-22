using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilmomStore_DataAccessObject.Migrations
{
    public partial class AddWardInShippinginfor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "ShippingInfor",
                newName: "Ward");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "ShippingInfor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "Province",
                table: "ShippingInfor");

            migrationBuilder.RenameColumn(
                name: "Ward",
                table: "ShippingInfor",
                newName: "City");
        }
    }
}
