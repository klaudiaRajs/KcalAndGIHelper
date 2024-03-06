using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diabetic.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingchickenseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Fat", "Protein" },
                values: new object[] { 1.0, 22.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Fat", "Protein" },
                values: new object[] { 0.0, 0.0 });
        }
    }
}
