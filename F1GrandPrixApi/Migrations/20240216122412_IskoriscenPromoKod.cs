using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1GrandPrixApi.Migrations
{
    /// <inheritdoc />
    public partial class IskoriscenPromoKod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "iskoriscenPromoKod",
                table: "kupci",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "iskoriscenPromoKod",
                table: "kupci");
        }
    }
}
