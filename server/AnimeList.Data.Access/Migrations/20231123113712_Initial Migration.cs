using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimeList.Data.Access.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Premired",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeasonalTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premired", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PremiredId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    Ranked = table.Column<int>(type: "int", nullable: false),
                    Popularity = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    RelatedAnime = table.Column<int>(type: "int", nullable: false),
                    AnimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_AnimeType_SeriesTypeId",
                        column: x => x.SeriesTypeId,
                        principalTable: "AnimeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seasons_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seasons_Premired_PremiredId",
                        column: x => x.PremiredId,
                        principalTable: "Premired",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_Seasons_SeasonsId",
                        column: x => x.SeasonsId,
                        principalTable: "Seasons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailCount", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "PasswordHash", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("115a1abc-74df-4770-9a58-245c71313b6a"), 0, "user@gmail.com", "user@gmail.com", "User", "User", false, "79655CA3D52A3DBD076E5668561A28DE45BA834B3F2F6D591CB23424F31FEC18318E57822A69769911261EEDA083697E9B0CEBD9DEBF73C6742A8AD1E3130BC6", 1, "User" },
                    { new Guid("7bb59196-88d2-4611-b1a3-9aaec767d0a0"), 0, "admin@gmail.com", "admin@gmail.com", "Admin", "Admin", false, "3A6955ECB2BE2FDE0BCE611575A9BF4DABA76FB528545C74CB0A9A00C7286F92784E03051C83861F0ABD1B9EA3AA6290A86E6B34E82FFD0F256DE4086575BD47", 0, "Admin" },
                    { new Guid("f5165b28-ce08-4527-a477-3f230402f467"), 0, "guest@gmail.com", "guest@gmail.com", "Guest", "Guest", false, "9BD5E0FF0FC707C385129109707B29EAB725246D032E589E37FC14CEC24B48D7F2B5DE2193D239253C9294EE8E77E1B3D4B6EBEA81BBE50EC454A3D470DDA0B4", 2, "Guest" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genre_SeasonsId",
                table: "Genre",
                column: "SeasonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_AnimeId",
                table: "Seasons",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_PremiredId",
                table: "Seasons",
                column: "PremiredId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeriesTypeId",
                table: "Seasons",
                column: "SeriesTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "AnimeType");

            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "Premired");
        }
    }
}
