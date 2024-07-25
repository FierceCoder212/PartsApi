using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartsApi.Migrations
{
    /// <inheritdoc />
    public partial class ScraperName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScraperName",
                table: "TempParts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScraperName",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScraperName",
                table: "TempParts");

            migrationBuilder.DropColumn(
                name: "ScraperName",
                table: "Parts");
        }
    }
}
