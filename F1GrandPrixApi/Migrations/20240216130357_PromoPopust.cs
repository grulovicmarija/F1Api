using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1GrandPrixApi.Migrations
{
    /// <inheritdoc />
    public partial class PromoPopust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "promoPopust",
                table: "kupci",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "promoPopust",
                table: "kupci");
        }
    }
}
