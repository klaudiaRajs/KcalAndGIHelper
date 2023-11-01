using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class AddDietDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Day_Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastRecipeId = table.Column<int>(type: "int", nullable: true),
                    LunchRecipeId = table.Column<int>(type: "int", nullable: true),
                    DinnerRecipeId = table.Column<int>(type: "int", nullable: true),
                    SnackRecipeId = table.Column<int>(type: "int", nullable: true),
                    SupperRecipeId = table.Column<int>(type: "int", nullable: true),
                    DayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Day_Recipes",
                columns: new[] { "Id", "BreakfastRecipeId", "DayId", "DinnerRecipeId", "LunchRecipeId", "SnackRecipeId", "SupperRecipeId" },
                values: new object[] { 1, 6, 1, 2, 4, null, 5 });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Day 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Day_Recipes");

            migrationBuilder.DropTable(
                name: "Days");
        }
    }
}
