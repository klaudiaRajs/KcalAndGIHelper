using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    public partial class AddKabanos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "GI", "GramsPerPortion", "KcalPer100g", "Name" },
                values: new object[] { 133, 6, 0, 45, 480, "kabanos" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 133);
        }
    }
}
