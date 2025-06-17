using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkmate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    min_age = table.Column<int>(type: "int", nullable: false),
                    max_age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    elo = table.Column<int>(type: "int", nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    min_players = table.Column<int>(type: "int", nullable: false),
                    max_players = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_inscription_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    start_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    current_round = table.Column<int>(type: "int", nullable: false),
                    location_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tournament_Location_location_id",
                        column: x => x.location_id,
                        principalTable: "Location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameRoundPlayerTournaments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tournament_id = table.Column<int>(type: "int", nullable: false),
                    white_id = table.Column<int>(type: "int", nullable: false),
                    white_elo = table.Column<int>(type: "int", nullable: false),
                    black_id = table.Column<int>(type: "int", nullable: false),
                    black_elo = table.Column<int>(type: "int", nullable: false),
                    round = table.Column<int>(type: "int", nullable: false),
                    result = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRoundPlayerTournaments", x => x.id);
                    table.ForeignKey(
                        name: "FK_GameRoundPlayerTournaments_Tournament_tournament_id",
                        column: x => x.tournament_id,
                        principalTable: "Tournament",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRoundPlayerTournaments_Utilisateur_black_id",
                        column: x => x.black_id,
                        principalTable: "Utilisateur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameRoundPlayerTournaments_Utilisateur_white_id",
                        column: x => x.white_id,
                        principalTable: "Utilisateur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InscriptionPlayerTournaments",
                columns: table => new
                {
                    player_id = table.Column<int>(type: "int", nullable: false),
                    tournament_id = table.Column<int>(type: "int", nullable: false),
                    inscription_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    canceled_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscriptionPlayerTournaments", x => new { x.player_id, x.tournament_id, x.inscription_date });
                    table.ForeignKey(
                        name: "FK_InscriptionPlayerTournaments_Tournament",
                        column: x => x.tournament_id,
                        principalTable: "Tournament",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InscriptionPlayerTournaments_Utilisateur",
                        column: x => x.player_id,
                        principalTable: "Utilisateur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MM_Tournament_Category",
                columns: table => new
                {
                    tournament_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MM_Tournament_Category", x => new { x.tournament_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_MM_Tournament_Category_Categories_category_id",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MM_Tournament_Category_Tournament_tournament_id",
                        column: x => x.tournament_id,
                        principalTable: "Tournament",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameRoundPlayerTournaments_black_id",
                table: "GameRoundPlayerTournaments",
                column: "black_id");

            migrationBuilder.CreateIndex(
                name: "IX_GameRoundPlayerTournaments_tournament_id",
                table: "GameRoundPlayerTournaments",
                column: "tournament_id");

            migrationBuilder.CreateIndex(
                name: "IX_GameRoundPlayerTournaments_white_id",
                table: "GameRoundPlayerTournaments",
                column: "white_id");

            migrationBuilder.CreateIndex(
                name: "IX_InscriptionPlayerTournaments_tournament_id",
                table: "InscriptionPlayerTournaments",
                column: "tournament_id");

            migrationBuilder.CreateIndex(
                name: "IX_MM_Tournament_Category_category_id",
                table: "MM_Tournament_Category",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_location_id",
                table: "Tournament",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_email",
                table: "Utilisateur",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_username",
                table: "Utilisateur",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRoundPlayerTournaments");

            migrationBuilder.DropTable(
                name: "InscriptionPlayerTournaments");

            migrationBuilder.DropTable(
                name: "MM_Tournament_Category");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
