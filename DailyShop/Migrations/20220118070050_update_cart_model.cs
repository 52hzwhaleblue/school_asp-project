using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyShop.Migrations
{
    public partial class update_cart_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "importedDate",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "ProductQuantity",
                table: "Carts",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Carts",
                newName: "ProductQuantity");

            migrationBuilder.AddColumn<DateTime>(
                name: "importedDate",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
