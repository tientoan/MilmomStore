using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilmomStore_DataAccessObject.Migrations
{
    public partial class Fixproductproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_AspNetUsers_AccountID",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Cart_CartID",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "07aa36c7-d918-4160-b072-4c6e2b7c23d2");
            //
            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "1794057e-55f2-44f4-a911-e5dc847e26fe");
            //
            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "5cb4cce8-ff02-4c2d-bf41-b7a66360c4b8");
            //
            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "99cb7fe8-fff7-4bbb-a300-b81af72e90f2");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_AccountID",
                table: "Carts",
                newName: "IX_Carts_AccountID");

            migrationBuilder.AddColumn<string>(
                name: "Instruction",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "CartID");

            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //     values: new object[,]
            //     {
            //         { "053d5b34-b408-4d58-9cf9-e9e859bc94ac", "48bb6122-ef85-426d-bc65-05c91633d100", "Admin", "ADMIN" },
            //         { "be66a18a-eeb5-4535-b279-3d6d60083f2f", "7cdd6863-1bbc-47f5-9ab7-d43716fe7927", "Staff", "STAFF" },
            //         { "e1aeabae-9e2d-411c-8faa-644003c09382", "51b4e27c-fc7b-417f-bbab-82d4169bbcd8", "Customer", "CUSTOMER" },
            //         { "e22fe111-fcef-42f3-969c-ad0fd6e5b5e5", "c22f4ce7-ac33-4050-b381-5c34d23b8e54", "Manager", "MANAGER" }
            //     });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_AccountID",
                table: "Carts",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartID",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_AccountID",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "053d5b34-b408-4d58-9cf9-e9e859bc94ac");
            //
            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "be66a18a-eeb5-4535-b279-3d6d60083f2f");
            //
            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e1aeabae-9e2d-411c-8faa-644003c09382");
            //
            // migrationBuilder.DeleteData(
            //     table: "AspNetRoles",
            //     keyColumn: "Id",
            //     keyValue: "e22fe111-fcef-42f3-969c-ad0fd6e5b5e5");

            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_AccountID",
                table: "Cart",
                newName: "IX_Cart_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "CartID");

            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //     values: new object[,]
            //     {
            //         { "07aa36c7-d918-4160-b072-4c6e2b7c23d2", "26f6b5a8-6ead-44c1-8349-d5a7efda0fcf", "Customer", "CUSTOMER" },
            //         { "1794057e-55f2-44f4-a911-e5dc847e26fe", "d129051b-8481-4949-9565-94c90fce3f47", "Admin", "ADMIN" },
            //         { "5cb4cce8-ff02-4c2d-bf41-b7a66360c4b8", "cced79a5-490d-4838-a474-27b5bf7a9190", "Staff", "STAFF" },
            //         { "99cb7fe8-fff7-4bbb-a300-b81af72e90f2", "86b9b35d-5cc0-4483-9b8a-9359415e9bd9", "Manager", "MANAGER" }
            //     });

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_AspNetUsers_AccountID",
                table: "Cart",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Cart_CartID",
                table: "CartItems",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
