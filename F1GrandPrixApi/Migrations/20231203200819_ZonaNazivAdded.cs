using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1GrandPrixApi.Migrations
{
    /// <inheritdoc />
    public partial class ZonaNazivAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "naziv",
                table: "zone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "naziv",
                table: "zone");
        }
    }
}
