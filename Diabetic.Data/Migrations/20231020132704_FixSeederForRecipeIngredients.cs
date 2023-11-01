using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class FixSeederForRecipeIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductId",
                value: 19);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductId",
                value: 81);
        }
    }
}
