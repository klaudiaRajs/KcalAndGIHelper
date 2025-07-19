using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    KcalTarget = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarbsPer100G",
                value: 5.0999999999999996);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarbsPer100G",
                value: 5.0999999999999996);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CarbsPer100G",
                value: 11.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CarbsPer100G",
                value: 10.800000000000001);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CarbsPer100G",
                value: 15.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CarbsPer100G",
                value: 10.1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CarbsPer100G",
                value: 71.400000000000006);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CarbsPer100G",
                value: 17.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CarbsPer100G",
                value: 3.7999999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CarbsPer100G",
                value: 7.2999999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CarbsPer100G",
                value: 5.2000000000000002);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CarbsPer100G",
                value: 7.2999999999999998);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CarbsPer100G",
                value: 45.899999999999999);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CarbsPer100G",
                value: 2.6000000000000001);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CarbsPer100G",
                value: 4.9000000000000004);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CarbsPer100G",
                value: 4.2000000000000002);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CarbsPer100G",
                value: 5.2000000000000002);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CarbsPer100G",
                value: 2.3999999999999999);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CarbsPer100G",
                value: 4.5999999999999996);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CarbsPer100G",
                value: 2.5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CarbsPer100G",
                value: 2.6000000000000001);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CarbsPer100G",
                value: 2.3999999999999999);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CarbsPer100G",
                value: 3.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CarbsPer100G",
                value: 5.2000000000000002);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CarbsPer100G",
                value: 2.1000000000000001);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "CarbsPer100G",
                value: 1.5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMealDays");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "KcalPer100G",
                table: "Products",
                newName: "KcalPer100g");

            migrationBuilder.RenameColumn(
                name: "Gi",
                table: "Products",
                newName: "GI");

            migrationBuilder.RenameColumn(
                name: "CarbsPer100G",
                table: "Products",
                newName: "CarbsPer100g");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Ingredient_Meal_Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    RecipePortion = table.Column<float>(type: "real", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient_Meal_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Meal_Days_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredient_Meal_Days_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredient_Meal_Days_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "CarbsPer100g",
                value: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_Meal_Days_MealId",
                table: "Ingredient_Meal_Days",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_Meal_Days_ProductId",
                table: "Ingredient_Meal_Days",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_Meal_Days_RecipeId",
                table: "Ingredient_Meal_Days",
                column: "RecipeId");
        }
    }
}
