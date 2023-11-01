using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class AddRecipesWithSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe_Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipe_Ingredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipe_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                values: new object[] { 2, 19, 81, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_Ingredients_ProductId",
                table: "Recipe_Ingredients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_Ingredients_RecipeId",
                table: "Recipe_Ingredients",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipe_Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
