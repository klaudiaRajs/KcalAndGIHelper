using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class RemoveMealsDependencyForRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealRecipe");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealRecipeId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealRecipeId",
                table: "Meal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MealRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealsId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRecipes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MealRecipes",
                columns: new[] { "Id", "MealsId", "RecipesId" },
                values: new object[] { 1, 1, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MealId",
                table: "Recipes",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MealRecipeId",
                table: "Recipes",
                column: "MealRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_MealRecipeId",
                table: "Meal",
                column: "MealRecipeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_MealRecipes_MealRecipeId",
                table: "Recipes",
                column: "MealRecipeId",
                principalTable: "MealRecipes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_MealRecipes_MealRecipeId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Meal_MealId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_MealRecipes_MealRecipeId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "MealRecipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_MealId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_MealRecipeId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Meal_MealRecipeId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MealRecipeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MealRecipeId",
                table: "Meal");

            migrationBuilder.CreateTable(
                name: "MealRecipe",
                columns: table => new
                {
                    MealsId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRecipe", x => new { x.MealsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_MealRecipe_Meal_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MealRecipe",
                columns: new[] { "MealsId", "RecipesId" },
                values: new object[] { 1, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_MealRecipe_RecipesId",
                table: "MealRecipe",
                column: "RecipesId");
        }
    }
}
