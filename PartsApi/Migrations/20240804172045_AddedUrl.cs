using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartsApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SectonDiagramUrl",
                table: "TempParts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectonDiagramUrl",
                table: "TempParts");
        }
    }
}
