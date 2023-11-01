using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class AddSeederForAssigningRecipeToMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Meal",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" },
                    { 3, "Dinner" },
                    { 4, "Snack" },
                    { 5, "Supper" }
                });

            migrationBuilder.InsertData(
                table: "MealRecipe",
                columns: new[] { "MealsId", "RecipesId" },
                values: new object[] { 1, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MealRecipe",
                keyColumns: new[] { "MealsId", "RecipesId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "Meal",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
