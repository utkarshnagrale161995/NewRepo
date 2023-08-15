using Microsoft.EntityFrameworkCore.Migrations;

namespace Infosys.CodeFirstCore.DataAccessLayer.Migrations
{
    public partial class ConfigureEntitiesUsingFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Products",
                type: "char(4)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddUniqueConstraint(
                name: "uq_ProductName",
                table: "Products",
                column: "ProductName");

            migrationBuilder.AddUniqueConstraint(
                name: "uq_CategoryName",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.AddForeignKey(
                name: "fh_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fh_CategoryId",
                table: "Products");

            migrationBuilder.DropUniqueConstraint(
                name: "uq_ProductName",
                table: "Products");

            migrationBuilder.DropUniqueConstraint(
                name: "uq_CategoryName",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(4)");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
