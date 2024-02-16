using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1GrandPrixApi.Migrations
{
    /// <inheritdoc />
    public partial class DrzavaAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<int>(
                name: "drzavaid",
                table: "ucesnici",
                type: "int",
                nullable: true);

           
            migrationBuilder.AddColumn<int>(
                name: "rang",
                table: "ucesnici",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
               name: "status",
               table: "ucesnici",
               type: "nvarchar(max)",
               nullable: false,
               defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ucesnici_drzavaid",
                table: "ucesnici",
                column: "drzavaid");

            migrationBuilder.AddForeignKey(
                name: "FK_ucesnici_drzave_drzavaid",
                table: "ucesnici",
                column: "drzavaid",
                principalTable: "drzave",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ucesnici_drzave_drzavaid",
                table: "ucesnici");

            migrationBuilder.DropIndex(
                name: "IX_ucesnici_drzavaid",
                table: "ucesnici");

            migrationBuilder.DropColumn(
                name: "drzavaid",
                table: "ucesnici");

            migrationBuilder.DropColumn(
                name: "nazivSlikeUcesnika",
                table: "ucesnici");

            migrationBuilder.DropColumn(
                name: "rang",
                table: "ucesnici");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "ucesnici",
                newName: "nazivSlike");
        }
    }
}
