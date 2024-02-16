using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1GrandPrixApi.Migrations
{
    /// <inheritdoc />
    public partial class NazivSlikeDodat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nazivSlike",
                table: "trke",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nazivSlike",
                table: "trke");
        }
    }
}
