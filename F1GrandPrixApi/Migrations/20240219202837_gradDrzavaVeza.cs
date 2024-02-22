using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1GrandPrixApi.Migrations
{
    /// <inheritdoc />
    public partial class gradDrzavaVeza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "drzavaid",
                table: "gradovi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_gradovi_drzavaid",
                table: "gradovi",
                column: "drzavaid");

            migrationBuilder.AddForeignKey(
                name: "FK_gradovi_drzave_drzavaid",
                table: "gradovi",
                column: "drzavaid",
                principalTable: "drzave",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gradovi_drzave_drzavaid",
                table: "gradovi");

            migrationBuilder.DropIndex(
                name: "IX_gradovi_drzavaid",
                table: "gradovi");

            migrationBuilder.DropColumn(
                name: "drzavaid",
                table: "gradovi");
        }
    }
}
