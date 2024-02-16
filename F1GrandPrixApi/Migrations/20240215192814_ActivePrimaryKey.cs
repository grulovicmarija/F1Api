using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1GrandPrixApi.Migrations
{
    /// <inheritdoc />
    public partial class ActivePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_rezervacije",
                table: "rezervacije");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rezervacije",
                table: "rezervacije",
                columns: new[] { "KupacId", "TrkaId", "aktivna" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_rezervacije",
                table: "rezervacije");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rezervacije",
                table: "rezervacije",
                columns: new[] { "KupacId", "TrkaId" });
        }
    }
}
