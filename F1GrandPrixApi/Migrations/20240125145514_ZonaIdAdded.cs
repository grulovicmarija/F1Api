using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1GrandPrixApi.Migrations
{
    /// <inheritdoc />
    public partial class ZonaIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rezervacije_zone_zonaid",
                table: "rezervacije");

            migrationBuilder.RenameColumn(
                name: "zonaid",
                table: "rezervacije",
                newName: "ZonaId");

            migrationBuilder.RenameIndex(
                name: "IX_rezervacije_zonaid",
                table: "rezervacije",
                newName: "IX_rezervacije_ZonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_rezervacije_zone_ZonaId",
                table: "rezervacije",
                column: "ZonaId",
                principalTable: "zone",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rezervacije_zone_ZonaId",
                table: "rezervacije");

            migrationBuilder.RenameColumn(
                name: "ZonaId",
                table: "rezervacije",
                newName: "zonaid");

            migrationBuilder.RenameIndex(
                name: "IX_rezervacije_ZonaId",
                table: "rezervacije",
                newName: "IX_rezervacije_zonaid");

            migrationBuilder.AddForeignKey(
                name: "FK_rezervacije_zone_zonaid",
                table: "rezervacije",
                column: "zonaid",
                principalTable: "zone",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
