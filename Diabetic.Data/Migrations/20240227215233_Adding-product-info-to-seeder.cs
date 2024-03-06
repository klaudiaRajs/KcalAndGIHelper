using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diabetic.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingproductinfotoseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Tłuszcz" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CarbsPer100g", "Fat", "Fibre", "Protein" },
                values: new object[] { 8.1999999999999993, 0.40000000000000002, 5.7999999999999998, 7.0999999999999996 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CarbsPer100g", "Sugar" },
                values: new object[] { 6.5999999999999996, 5.7999999999999998 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CategoryId", "Fat", "GI", "KcalPer100g", "Name" },
                values: new object[] { 9, 100.0, 0, 884, "olej rzepakowy" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CarbsPer100g", "CategoryId", "Fat", "Fibre", "GI", "GramsPerPortion", "KcalPer100g", "Name", "Protein", "Sugar" },
                values: new object[,]
                {
                    { 141, 3.0, 8, 0.0, 0.0, 25, 25, 27, "sos sojowy", 4.0, 0.0 },
                    { 142, 0.0, 4, 0.0, 0.0, 15, null, 630, "mieszanka orzechów", 0.0, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Day_Recipes_BreakfastRecipeId",
                table: "Day_Recipes",
                column: "BreakfastRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Recipes_Recipes_BreakfastRecipeId",
                table: "Day_Recipes",
                column: "BreakfastRecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Recipes_Recipes_BreakfastRecipeId",
                table: "Day_Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Day_Recipes_BreakfastRecipeId",
                table: "Day_Recipes");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CarbsPer100g", "Fat", "Fibre", "Protein" },
                values: new object[] { 0.0, 0.0, 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "CarbsPer100g", "Sugar" },
                values: new object[] { 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "CategoryId", "Fat", "GI", "KcalPer100g", "Name" },
                values: new object[] { 4, 0.0, 15, 630, "mieszanka orzechów" });
        }
    }
}
