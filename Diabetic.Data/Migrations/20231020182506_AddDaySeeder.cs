using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class AddDaySeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Day_Recipes",
                columns: new[] { "Id", "BreakfastRecipeId", "DayId", "DinnerRecipeId", "LunchRecipeId", "SnackRecipeId", "SupperRecipeId" },
                values: new object[] { 2, 8, 2, 7, 9, null, 10 });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Day 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Day_Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
