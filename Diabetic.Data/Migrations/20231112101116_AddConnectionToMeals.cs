using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class AddConnectionToMeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_MealRecipes_MealRecipeId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Meal_MealId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_MealId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meal",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Recipes");

            migrationBuilder.RenameTable(
                name: "Meal",
                newName: "Meals");

            migrationBuilder.RenameIndex(
                name: "IX_Meal_MealRecipeId",
                table: "Meals",
                newName: "IX_Meals_MealRecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_MealRecipes_MealRecipeId",
                table: "Meals",
                column: "MealRecipeId",
                principalTable: "MealRecipes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_MealRecipes_MealRecipeId",
                table: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "Meal");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_MealRecipeId",
                table: "Meal",
                newName: "IX_Meal_MealRecipeId");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meal",
                table: "Meal",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MealId",
                table: "Recipes",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_MealRecipes_MealRecipeId",
                table: "Meal",
                column: "MealRecipeId",
                principalTable: "MealRecipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Meal_MealId",
                table: "Recipes",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id");
        }
    }
}
