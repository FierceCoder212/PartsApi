using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartsApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedSGLDescriptionAndSectionToParts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SGLDescription",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SGLSection",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SGLDescription",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "SGLSection",
                table: "Parts");
        }
    }
}
