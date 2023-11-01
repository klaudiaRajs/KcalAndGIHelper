using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class AddingRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "GI", "GramsPerPortion", "KcalPer100g", "Name" },
                values: new object[,]
                {
                    { 135, 6, 0, 90, 161, "podudzie z kurczaka" },
                    { 136, 5, 0, null, 140, "jajko" },
                    { 137, 2, 55, null, 57, "borówki" },
                    { 138, 4, 15, null, 630, "mieszanka orzechów" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Pieczone podudzia z kurczaka z quinąą i surówką" },
                    { 4, "Jajka, kabanos" },
                    { 5, "Owoce, jogurt, orzechy" },
                    { 6, "Kanapki z warzywami" }
                });

            migrationBuilder.InsertData(
                table: "Recipe_Ingredients",
                columns: new[] { "Id", "Amount", "ProductId", "RecipeId" },
                values: new object[,]
                {
                    { 3, 180, 135, 2 },
                    { 4, 50, 66, 2 },
                    { 5, 100, 19, 2 },
                    { 6, 80, 81, 6 },
                    { 7, 50, 23, 6 },
                    { 8, 25, 134, 6 },
                    { 9, 120, 136, 4 },
                    { 10, 45, 133, 4 },
                    { 11, 100, 137, 5 },
                    { 12, 150, 88, 5 },
                    { 13, 30, 138, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Recipe_Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Kanapka z hummusem i warzywami" });

            migrationBuilder.InsertData(
                table: "Recipe_Ingredients",
                columns: new[] { "Id", "Amount", "ProductId", "RecipeId" },
                values: new object[] { 1, 40, 81, 1 });

            migrationBuilder.InsertData(
                table: "Recipe_Ingredients",
                columns: new[] { "Id", "Amount", "ProductId", "RecipeId" },
                values: new object[] { 2, 19, 19, 1 });
        }
    }
}
