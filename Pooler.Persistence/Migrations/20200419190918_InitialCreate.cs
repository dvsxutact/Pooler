using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pooler.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GameId = table.Column<int>(nullable: false),
                    gameType = table.Column<int>(nullable: false),
                    InningCount = table.Column<int>(nullable: false),
                    P1_Defensive = table.Column<int>(nullable: false),
                    P2_Defensive = table.Column<int>(nullable: false),
                    P1_BNR = table.Column<int>(nullable: false),
                    P2_BNR = table.Column<int>(nullable: false),
                    P1_WOS = table.Column<int>(nullable: false),
                    P2_WOS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoolGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlayerOneId = table.Column<int>(nullable: false),
                    PlayerTwoId = table.Column<int>(nullable: false),
                    gameStart = table.Column<DateTime>(nullable: false),
                    gameEnd = table.Column<DateTime>(nullable: false),
                    gameDetailsId = table.Column<int>(nullable: true),
                    WinnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoolGames_Players_PlayerOneId",
                        column: x => x.PlayerOneId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoolGames_Players_PlayerTwoId",
                        column: x => x.PlayerTwoId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoolGames_Players_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoolGames_GameDetails_gameDetailsId",
                        column: x => x.gameDetailsId,
                        principalTable: "GameDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_AccountNumber",
                table: "Players",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoolGames_PlayerOneId",
                table: "PoolGames",
                column: "PlayerOneId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGames_PlayerTwoId",
                table: "PoolGames",
                column: "PlayerTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGames_WinnerId",
                table: "PoolGames",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolGames_gameDetailsId",
                table: "PoolGames",
                column: "gameDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoolGames");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "GameDetails");
        }
    }
}
