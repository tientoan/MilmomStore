// using Microsoft.EntityFrameworkCore.Migrations;
//
// #nullable disable
//
// namespace MilmomStore.Server.Migrations
// {
//     public partial class FixCart : Migration
//     {
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_CartItems_AspNetUsers_AccountID",
//                 table: "CartItems");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_CartItems_AccountID",
//                 table: "CartItems");
//
//             migrationBuilder.DeleteData(
//                 table: "AspNetRoles",
//                 keyColumn: "Id",
//                 keyValue: "0c0d7cd5-022e-4496-9719-eb91c2908199");
//
//             migrationBuilder.DeleteData(
//                 table: "AspNetRoles",
//                 keyColumn: "Id",
//                 keyValue: "846bc4a3-3032-495d-8f7f-b9a23536e8a2");
//
//             migrationBuilder.DeleteData(
//                 table: "AspNetRoles",
//                 keyColumn: "Id",
//                 keyValue: "d4522bd0-3efd-4bf6-8d26-38b8f761ee67");
//
//             migrationBuilder.DeleteData(
//                 table: "AspNetRoles",
//                 keyColumn: "Id",
//                 keyValue: "f0218fb0-85f1-40d7-8406-7bcbca6214e4");
//
//             migrationBuilder.DropColumn(
//                 name: "AccountID",
//                 table: "CartItems");
//
//             migrationBuilder.AddColumn<string>(
//                 name: "AccountApplicationId",
//                 table: "CartItems",
//                 type: "nvarchar(450)",
//                 nullable: true);
//
//             migrationBuilder.AddColumn<int>(
//                 name: "CartID",
//                 table: "CartItems",
//                 type: "int",
//                 nullable: false,
//                 defaultValue: 0);
//
//             migrationBuilder.CreateTable(
//                 name: "Cart",
//                 columns: table => new
//                 {
//                     CartID = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     AccountID = table.Column<string>(type: "nvarchar(450)", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Cart", x => x.CartID);
//                     table.ForeignKey(
//                         name: "FK_Cart_AspNetUsers_AccountID",
//                         column: x => x.AccountID,
//                         principalTable: "AspNetUsers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 });
//
//             // migrationBuilder.InsertData(
//             //     table: "AspNetRoles",
//             //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
//             //     values: new object[,]
//             //     {
//             //         { "07aa36c7-d918-4160-b072-4c6e2b7c23d2", "26f6b5a8-6ead-44c1-8349-d5a7efda0fcf", "Customer", "CUSTOMER" },
//             //         { "1794057e-55f2-44f4-a911-e5dc847e26fe", "d129051b-8481-4949-9565-94c90fce3f47", "Admin", "ADMIN" },
//             //         { "5cb4cce8-ff02-4c2d-bf41-b7a66360c4b8", "cced79a5-490d-4838-a474-27b5bf7a9190", "Staff", "STAFF" },
//             //         { "99cb7fe8-fff7-4bbb-a300-b81af72e90f2", "86b9b35d-5cc0-4483-9b8a-9359415e9bd9", "Manager", "MANAGER" }
//             //     });
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_CartItems_AccountApplicationId",
//                 table: "CartItems",
//                 column: "AccountApplicationId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_CartItems_CartID",
//                 table: "CartItems",
//                 column: "CartID");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Cart_AccountID",
//                 table: "Cart",
//                 column: "AccountID");
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_CartItems_AspNetUsers_AccountApplicationId",
//                 table: "CartItems",
//                 column: "AccountApplicationId",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id");
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_CartItems_Cart_CartID",
//                 table: "CartItems",
//                 column: "CartID",
//                 principalTable: "Cart",
//                 principalColumn: "CartID",
//                 onDelete: ReferentialAction.Cascade);
//         }
//
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropForeignKey(
//                 name: "FK_CartItems_AspNetUsers_AccountApplicationId",
//                 table: "CartItems");
//
//             migrationBuilder.DropForeignKey(
//                 name: "FK_CartItems_Cart_CartID",
//                 table: "CartItems");
//
//             migrationBuilder.DropTable(
//                 name: "Cart");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_CartItems_AccountApplicationId",
//                 table: "CartItems");
//
//             migrationBuilder.DropIndex(
//                 name: "IX_CartItems_CartID",
//                 table: "CartItems");
//
//             // migrationBuilder.DeleteData(
//             //     table: "AspNetRoles",
//             //     keyColumn: "Id",
//             //     keyValue: "07aa36c7-d918-4160-b072-4c6e2b7c23d2");
//             //
//             // migrationBuilder.DeleteData(
//             //     table: "AspNetRoles",
//             //     keyColumn: "Id",
//             //     keyValue: "1794057e-55f2-44f4-a911-e5dc847e26fe");
//             //
//             // migrationBuilder.DeleteData(
//             //     table: "AspNetRoles",
//             //     keyColumn: "Id",
//             //     keyValue: "5cb4cce8-ff02-4c2d-bf41-b7a66360c4b8");
//             //
//             // migrationBuilder.DeleteData(
//             //     table: "AspNetRoles",
//             //     keyColumn: "Id",
//             //     keyValue: "99cb7fe8-fff7-4bbb-a300-b81af72e90f2");
//
//             migrationBuilder.DropColumn(
//                 name: "AccountApplicationId",
//                 table: "CartItems");
//
//             migrationBuilder.DropColumn(
//                 name: "CartID",
//                 table: "CartItems");
//
//             migrationBuilder.AddColumn<string>(
//                 name: "AccountID",
//                 table: "CartItems",
//                 type: "nvarchar(450)",
//                 nullable: false,
//                 defaultValue: "");
//
//             // migrationBuilder.InsertData(
//             //     table: "AspNetRoles",
//             //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
//             //     values: new object[,]
//             //     {
//             //         { "0c0d7cd5-022e-4496-9719-eb91c2908199", "b966d59e-0505-4fcf-9831-4fabe7e7b442", "Manager", "MANAGER" },
//             //         { "846bc4a3-3032-495d-8f7f-b9a23536e8a2", "6f756e7b-0463-4faf-9bc8-1e83467f97fb", "Staff", "STAFF" },
//             //         { "d4522bd0-3efd-4bf6-8d26-38b8f761ee67", "9cdd4408-7217-45a7-b2db-dd64e4c8c0c1", "Customer", "CUSTOMER" },
//             //         { "f0218fb0-85f1-40d7-8406-7bcbca6214e4", "04aca13d-600b-4da9-8661-644a38781c35", "Admin", "ADMIN" }
//             //     });
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_CartItems_AccountID",
//                 table: "CartItems",
//                 column: "AccountID");
//
//             migrationBuilder.AddForeignKey(
//                 name: "FK_CartItems_AspNetUsers_AccountID",
//                 table: "CartItems",
//                 column: "AccountID",
//                 principalTable: "AspNetUsers",
//                 principalColumn: "Id",
//                 onDelete: ReferentialAction.Cascade);
//         }
//     }
// }
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MilmomStore.Server.Migrations
{
    public partial class FixCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
