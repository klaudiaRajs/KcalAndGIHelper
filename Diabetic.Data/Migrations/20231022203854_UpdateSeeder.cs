using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class UpdateSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealRecipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MealsId", "RecipesId" },
                values: new object[] { 3, 7 });

            migrationBuilder.InsertData(
                table: "MealRecipes",
                columns: new[] { "Id", "MealsId", "RecipesId" },
                values: new object[] { 2, 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MealRecipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "MealRecipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MealsId", "RecipesId" },
                values: new object[] { 1, 5 });
        }
    }
}
