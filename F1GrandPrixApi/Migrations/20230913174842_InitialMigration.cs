using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1GrandPrixApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drzave",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drzave", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gradovi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gradovi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ucesnici",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ucesnici", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "zone",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kapacitet = table.Column<int>(type: "int", nullable: false),
                    cenaKarte = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    pogodnaZaInvalide = table.Column<bool>(type: "bit", nullable: false),
                    velikiTV = table.Column<bool>(type: "bit", nullable: false),
                    preostaloMesta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zone", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kupci",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kompanija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adresa1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresa2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postanskiBroj = table.Column<int>(type: "int", nullable: false),
                    mesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    potvrdaEmailAdrese = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    promoKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drzavaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kupci", x => x.id);
                    table.ForeignKey(
                        name: "FK_kupci_drzave_drzavaid",
                        column: x => x.drzavaid,
                        principalTable: "drzave",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trke",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumOdrzavanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lokacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dodatneInformacije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gradid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trke", x => x.id);
                    table.ForeignKey(
                        name: "FK_trke_gradovi_gradid",
                        column: x => x.gradid,
                        principalTable: "gradovi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rezervacije",
                columns: table => new
                {
                    KupacId = table.Column<int>(type: "int", nullable: false),
                    TrkaId = table.Column<int>(type: "int", nullable: false),
                    popust = table.Column<int>(type: "int", nullable: false),
                    konacnaCena = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    zonaid = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aktivna = table.Column<bool>(type: "bit", nullable: false),
                    brojKarata = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervacije", x => new { x.KupacId, x.TrkaId });
                    table.ForeignKey(
                        name: "FK_rezervacije_kupci_KupacId",
                        column: x => x.KupacId,
                        principalTable: "kupci",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_rezervacije_trke_TrkaId",
                        column: x => x.TrkaId,
                        principalTable: "trke",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_rezervacije_zone_zonaid",
                        column: x => x.zonaid,
                        principalTable: "zone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ucesca",
                columns: table => new
                {
                    UcesnikId = table.Column<int>(type: "int", nullable: false),
                    TrkaId = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ucesca", x => new { x.UcesnikId, x.TrkaId });
                    table.ForeignKey(
                        name: "FK_ucesca_trke_TrkaId",
                        column: x => x.TrkaId,
                        principalTable: "trke",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ucesca_ucesnici_UcesnikId",
                        column: x => x.UcesnikId,
                        principalTable: "ucesnici",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_kupci_drzavaid",
                table: "kupci",
                column: "drzavaid");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacije_TrkaId",
                table: "rezervacije",
                column: "TrkaId");

            migrationBuilder.CreateIndex(
                name: "IX_rezervacije_zonaid",
                table: "rezervacije",
                column: "zonaid");

            migrationBuilder.CreateIndex(
                name: "IX_trke_gradid",
                table: "trke",
                column: "gradid");

            migrationBuilder.CreateIndex(
                name: "IX_ucesca_TrkaId",
                table: "ucesca",
                column: "TrkaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rezervacije");

            migrationBuilder.DropTable(
                name: "ucesca");

            migrationBuilder.DropTable(
                name: "kupci");

            migrationBuilder.DropTable(
                name: "zone");

            migrationBuilder.DropTable(
                name: "trke");

            migrationBuilder.DropTable(
                name: "ucesnici");

            migrationBuilder.DropTable(
                name: "drzave");

            migrationBuilder.DropTable(
                name: "gradovi");
        }
    }
}
