using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_ThomasMore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumToegevoegd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsWerkschoenen = table.Column<bool>(type: "bit", nullable: false),
                    IsKleding = table.Column<bool>(type: "bit", nullable: false),
                    IsBadge = table.Column<bool>(type: "bit", nullable: false),
                    AantalPlaatsen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gemeente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Straat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Huisnummer = table.Column<int>(type: "int", nullable: false),
                    BankrekeningNummer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatumToegevoegd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producten_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bestellingen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bestellingen_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orderlijnen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestellingId = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderlijnen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orderlijnen_Bestellingen_BestellingId",
                        column: x => x.BestellingId,
                        principalTable: "Bestellingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orderlijnen_Producten_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Producten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DatumToegevoegd", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 26, 12, 35, 45, 943, DateTimeKind.Local).AddTicks(6945), "Pc Software" },
                    { 2, new DateTime(2024, 9, 26, 12, 35, 45, 943, DateTimeKind.Local).AddTicks(6990), "Pc Hardware" }
                });

            migrationBuilder.InsertData(
                table: "Klanten",
                columns: new[] { "Id", "BankrekeningNummer", "Gemeente", "Huisnummer", "Naam", "PostCode", "Straat", "Voornaam" },
                values: new object[] { 1, "123", "Antwerpen", 12, "Wouters", "3390", "Steenweg", "Michiel" });

            migrationBuilder.InsertData(
                table: "Bestellingen",
                columns: new[] { "Id", "KlantId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Producten",
                columns: new[] { "Id", "CategorieId", "DatumToegevoegd", "Naam", "Prijs" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), "Baldur's gate", 49.99m },
                    { 2, 1, new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), "Hello Kitty, Island adventure", 69.99m },
                    { 3, 2, new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), "Geforce RTX 4080", 699.99m }
                });

            migrationBuilder.InsertData(
                table: "Orderlijnen",
                columns: new[] { "Id", "Aantal", "BestellingId", "ProductID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 200, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_KlantId",
                table: "Bestellingen",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlijnen_BestellingId",
                table: "Orderlijnen",
                column: "BestellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlijnen_ProductID",
                table: "Orderlijnen",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Producten_CategorieId",
                table: "Producten",
                column: "CategorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Orderlijnen");

            migrationBuilder.DropTable(
                name: "Bestellingen");

            migrationBuilder.DropTable(
                name: "Producten");

            migrationBuilder.DropTable(
                name: "Klanten");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
