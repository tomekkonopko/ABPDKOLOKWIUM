using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KolokwiumAPBD.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "championships",
                columns: table => new
                {
                    IdChampionShip = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_championships", x => x.IdChampionShip);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    IdPlayer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.IdPlayer);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.IdTeam);
                });

            migrationBuilder.CreateTable(
                name: "championship_Teams",
                columns: table => new
                {
                    idChampionship = table.Column<int>(type: "int", nullable: false),
                    idTeam = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_championship_Teams", x => x.idChampionship);
                    table.ForeignKey(
                        name: "FK_championship_Teams_championships_idChampionship",
                        column: x => x.idChampionship,
                        principalTable: "championships",
                        principalColumn: "IdChampionShip",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_championship_Teams_Teams_idTeam",
                        column: x => x.idTeam,
                        principalTable: "Teams",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_Teams",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false),
                    IdPlayer = table.Column<int>(type: "int", nullable: false),
                    NumofShirt = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_Teams", x => x.IdTeam);
                    table.ForeignKey(
                        name: "FK_player_Teams_players_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "players",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_player_Teams_Teams_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Teams",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "IdTeam", "MaxAge", "TeamName" },
                values: new object[] { 1, 20, "Legia Warszawa" });

            migrationBuilder.CreateIndex(
                name: "IX_championship_Teams_idTeam",
                table: "championship_Teams",
                column: "idTeam");

            migrationBuilder.CreateIndex(
                name: "IX_player_Teams_IdPlayer",
                table: "player_Teams",
                column: "IdPlayer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "championship_Teams");

            migrationBuilder.DropTable(
                name: "player_Teams");

            migrationBuilder.DropTable(
                name: "championships");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
