using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilmomStore.Server.Migrations
{
    public partial class Init : Migration
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

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07aa36c7-d918-4160-b072-4c6e2b7c23d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1794057e-55f2-44f4-a911-e5dc847e26fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb4cce8-ff02-4c2d-bf41-b7a66360c4b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99cb7fe8-fff7-4bbb-a300-b81af72e90f2");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_AccountID",
                table: "Carts",
                newName: "IX_Carts_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "CartID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46c6b92d-40cc-407d-a8c2-907a72693b63", "ccec1be7-cb4a-44db-97e9-0e226746acfd", "Staff", "STAFF" },
                    { "5910b549-6b02-499a-a01f-d80c86358255", "9e185125-eed1-4fa1-8fa5-7757c828c028", "Customer", "CUSTOMER" },
                    { "593ce739-d017-41fc-b7b2-0150218c9416", "80a1aa10-8e02-4268-a62c-4d44f8b77d75", "Manager", "MANAGER" },
                    { "d940196c-103b-469b-8d0c-2d62f539d8d7", "6a569698-38c7-418d-815d-93b57ca2b684", "Admin", "ADMIN" }
                });

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

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46c6b92d-40cc-407d-a8c2-907a72693b63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5910b549-6b02-499a-a01f-d80c86358255");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "593ce739-d017-41fc-b7b2-0150218c9416");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d940196c-103b-469b-8d0c-2d62f539d8d7");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07aa36c7-d918-4160-b072-4c6e2b7c23d2", "26f6b5a8-6ead-44c1-8349-d5a7efda0fcf", "Customer", "CUSTOMER" },
                    { "1794057e-55f2-44f4-a911-e5dc847e26fe", "d129051b-8481-4949-9565-94c90fce3f47", "Admin", "ADMIN" },
                    { "5cb4cce8-ff02-4c2d-bf41-b7a66360c4b8", "cced79a5-490d-4838-a474-27b5bf7a9190", "Staff", "STAFF" },
                    { "99cb7fe8-fff7-4bbb-a300-b81af72e90f2", "86b9b35d-5cc0-4483-9b8a-9359415e9bd9", "Manager", "MANAGER" }
                });

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
