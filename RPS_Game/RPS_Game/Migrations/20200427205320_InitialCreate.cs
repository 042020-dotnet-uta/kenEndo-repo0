using Microsoft.EntityFrameworkCore.Migrations;

namespace RPS_Game.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    playerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    Ties = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.playerId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    P1playerId = table.Column<int>(nullable: true),
                    P2playerId = table.Column<int>(nullable: true),
                    WinnerplayerId = table.Column<int>(nullable: true),
                    RoundNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Players_P1playerId",
                        column: x => x.P1playerId,
                        principalTable: "Players",
                        principalColumn: "playerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_P2playerId",
                        column: x => x.P2playerId,
                        principalTable: "Players",
                        principalColumn: "playerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Players_WinnerplayerId",
                        column: x => x.WinnerplayerId,
                        principalTable: "Players",
                        principalColumn: "playerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WinnnerplayerId = table.Column<int>(nullable: true),
                    P1Choice = table.Column<string>(nullable: true),
                    P2Choice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Rounds_Players_WinnnerplayerId",
                        column: x => x.WinnnerplayerId,
                        principalTable: "Players",
                        principalColumn: "playerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_P1playerId",
                table: "Games",
                column: "P1playerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_P2playerId",
                table: "Games",
                column: "P2playerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerplayerId",
                table: "Games",
                column: "WinnerplayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_WinnnerplayerId",
                table: "Rounds",
                column: "WinnnerplayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
