using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyShop.Migrations
{
    public partial class uploadfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_UsersId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesDetail_Products_ProductsId",
                table: "InvoicesDetail");

            migrationBuilder.DropIndex(
                name: "IX_InvoicesDetail_ProductsId",
                table: "InvoicesDetail");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_UsersId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "InvoicesDetail");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Invoices");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesDetail_ProductId",
                table: "InvoicesDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesDetail_Products_ProductId",
                table: "InvoicesDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicesDetail_Products_ProductId",
                table: "InvoicesDetail");

            migrationBuilder.DropIndex(
                name: "IX_InvoicesDetail_ProductId",
                table: "InvoicesDetail");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "InvoicesDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesDetail_ProductsId",
                table: "InvoicesDetail",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UsersId",
                table: "Invoices",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_UsersId",
                table: "Invoices",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicesDetail_Products_ProductsId",
                table: "InvoicesDetail",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
