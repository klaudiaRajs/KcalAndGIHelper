using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class addingRecipesAndMissingIngredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "GI", "GramsPerPortion", "KcalPer100g", "Name" },
                values: new object[] { 139, 6, 0, 200, 98, "pierś z kurczaka" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Pieczona pierś z kurczaka z suszonymi pomidorami, fasolką szparagową i ryżem brązowym" },
                    { 8, "Owsianka z owocami i orzechami" },
                    { 9, "Sałatka Orzo" },
                    { 10, "Kanapka z szynką i warzywami" }
                });

            migrationBuilder.InsertData(
                table: "Recipe_Ingredients",
                columns: new[] { "Id", "Amount", "ProductId", "RecipeId" },
                values: new object[,]
                {
                    { 14, 200, 36, 7 },
                    { 15, 50, 69, 7 },
                    { 16, 200, 139, 7 },
                    { 17, 20, 37, 7 },
                    { 18, 100, 91, 8 },
                    { 19, 50, 67, 8 },
                    { 20, 200, 137, 8 },
                    { 21, 20, 138, 8 },
                    { 22, 10, 132, 9 },
                    { 23, 40, 19, 9 },
                    { 24, 25, 134, 9 },
                    { 25, 40, 81, 9 },
                    { 26, 40, 81, 10 },
                    { 27, 50, 113, 10 },
                    { 28, 25, 134, 10 },
                    { 29, 40, 19, 10 },
                    { 30, 50, 113, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
