using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class Product_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatogoryId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatogoryId",
                table: "Products",
                column: "CatogoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CatogoryId",
                table: "Products",
                column: "CatogoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CatogoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatogoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatogoryId",
                table: "Products");
        }
    }
}
