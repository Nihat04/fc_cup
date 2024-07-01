using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FcCupApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClubsGroupStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubsGroupStats", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Links = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlayersGroupStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersGroupStats", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClubsStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    StatisticGroupClubId = table.Column<int>(name: "StatisticGroup<Club>Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubsStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubsStats_ClubsGroupStats_StatisticGroup<Club>Id",
                        column: x => x.StatisticGroupClubId,
                        principalTable: "ClubsGroupStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClubsStats_Clubs_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Clubs",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StatisticGroup<TournamentPlayer>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TournamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticGroup<TournamentPlayer>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticGroup<TournamentPlayer>_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TournamentPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    PlayoffStageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentPlayers_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentPlayers_Stages_PlayoffStageId",
                        column: x => x.PlayoffStageId,
                        principalTable: "Stages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TournamentPlayers_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GroupStagePlayers",
                columns: table => new
                {
                    TournamentPlayerId = table.Column<int>(type: "int", nullable: false),
                    PlayedGames = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Draws = table.Column<int>(type: "int", nullable: false),
                    Loses = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    MissedGoals = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_GroupStagePlayers_TournamentPlayers_TournamentPlayerId",
                        column: x => x.TournamentPlayerId,
                        principalTable: "TournamentPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Player1Id = table.Column<int>(type: "int", nullable: false),
                    Player2Id = table.Column<int>(type: "int", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_TournamentPlayers_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "TournamentPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_TournamentPlayers_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "TournamentPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlayersStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    StatisticGroupPlayerId = table.Column<int>(name: "StatisticGroup<Player>Id", type: "int", nullable: true),
                    TournamentPlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayersStats_PlayersGroupStats_StatisticGroup<Player>Id",
                        column: x => x.StatisticGroupPlayerId,
                        principalTable: "PlayersGroupStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayersStats_Players_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayersStats_TournamentPlayers_TournamentPlayerId",
                        column: x => x.TournamentPlayerId,
                        principalTable: "TournamentPlayers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Statistic<TournamentPlayer>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "varchar(34)", maxLength: 34, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatisticGroupTournamentPlayerId = table.Column<int>(name: "StatisticGroup<TournamentPlayer>Id", type: "int", nullable: true),
                    SecondTargetId = table.Column<int>(type: "int", nullable: true),
                    MatchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic<TournamentPlayer>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistic<TournamentPlayer>_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statistic<TournamentPlayer>_StatisticGroup<TournamentPlayer>~",
                        column: x => x.StatisticGroupTournamentPlayerId,
                        principalTable: "StatisticGroup<TournamentPlayer>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statistic<TournamentPlayer>_TournamentPlayers_SecondTargetId",
                        column: x => x.SecondTargetId,
                        principalTable: "TournamentPlayers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statistic<TournamentPlayer>_TournamentPlayers_TargetId",
                        column: x => x.TargetId,
                        principalTable: "TournamentPlayers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FootballerCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    CardTypeUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OverallRating = table.Column<int>(type: "int", nullable: false),
                    LineupId = table.Column<int>(type: "int", nullable: true),
                    LineupId1 = table.Column<int>(type: "int", nullable: true),
                    LineupId2 = table.Column<int>(type: "int", nullable: true),
                    LineupId3 = table.Column<int>(type: "int", nullable: true),
                    LineupId4 = table.Column<int>(type: "int", nullable: true),
                    TimeLineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballerCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballerCards_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FootballersGruopStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    FootballerCardId = table.Column<int>(type: "int", nullable: true),
                    MatchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballersGruopStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballersGruopStats_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FootballersGruopStats_FootballerCards_FootballerCardId",
                        column: x => x.FootballerCardId,
                        principalTable: "FootballerCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FootballersGruopStats_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lineups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GoalkeeperId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lineups_FootballerCards_GoalkeeperId",
                        column: x => x.GoalkeeperId,
                        principalTable: "FootballerCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lineups_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TimeLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Minute = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    FootballerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeLines_FootballerCards_FootballerId",
                        column: x => x.FootballerId,
                        principalTable: "FootballerCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeLines_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FootballersStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    StatisticGroupFootballerCardId = table.Column<int>(name: "StatisticGroup<FootballerCard>Id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballersStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballersStats_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FootballersStats_FootballerCards_TargetId",
                        column: x => x.TargetId,
                        principalTable: "FootballerCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FootballersStats_FootballersGruopStats_StatisticGroup<Footba~",
                        column: x => x.StatisticGroupFootballerCardId,
                        principalTable: "FootballersGruopStats",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClubsStats_StatisticGroup<Club>Id",
                table: "ClubsStats",
                column: "StatisticGroup<Club>Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClubsStats_TargetId",
                table: "ClubsStats",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCards_ClubId",
                table: "FootballerCards",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCards_LineupId",
                table: "FootballerCards",
                column: "LineupId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCards_LineupId1",
                table: "FootballerCards",
                column: "LineupId1");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCards_LineupId2",
                table: "FootballerCards",
                column: "LineupId2");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCards_LineupId3",
                table: "FootballerCards",
                column: "LineupId3");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCards_LineupId4",
                table: "FootballerCards",
                column: "LineupId4");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCards_TimeLineId",
                table: "FootballerCards",
                column: "TimeLineId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballersGruopStats_ClubId",
                table: "FootballersGruopStats",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballersGruopStats_FootballerCardId",
                table: "FootballersGruopStats",
                column: "FootballerCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballersGruopStats_MatchId",
                table: "FootballersGruopStats",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballersStats_ClubId",
                table: "FootballersStats",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballersStats_StatisticGroup<FootballerCard>Id",
                table: "FootballersStats",
                column: "StatisticGroup<FootballerCard>Id");

            migrationBuilder.CreateIndex(
                name: "IX_FootballersStats_TargetId",
                table: "FootballersStats",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStagePlayers_TournamentPlayerId",
                table: "GroupStagePlayers",
                column: "TournamentPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineups_GoalkeeperId",
                table: "Lineups",
                column: "GoalkeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineups_MatchId",
                table: "Lineups",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ClubId",
                table: "Matches",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player1Id",
                table: "Matches",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player2Id",
                table: "Matches",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StageId",
                table: "Matches",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentId",
                table: "Matches",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStats_StatisticGroup<Player>Id",
                table: "PlayersStats",
                column: "StatisticGroup<Player>Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStats_TargetId",
                table: "PlayersStats",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersStats_TournamentPlayerId",
                table: "PlayersStats",
                column: "TournamentPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_TournamentId",
                table: "Stages",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic<TournamentPlayer>_MatchId",
                table: "Statistic<TournamentPlayer>",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic<TournamentPlayer>_SecondTargetId",
                table: "Statistic<TournamentPlayer>",
                column: "SecondTargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic<TournamentPlayer>_StatisticGroup<TournamentPlayer>~",
                table: "Statistic<TournamentPlayer>",
                column: "StatisticGroup<TournamentPlayer>Id");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic<TournamentPlayer>_TargetId",
                table: "Statistic<TournamentPlayer>",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticGroup<TournamentPlayer>_TournamentId",
                table: "StatisticGroup<TournamentPlayer>",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLines_FootballerId",
                table: "TimeLines",
                column: "FootballerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLines_PlayerId",
                table: "TimeLines",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayers_ClubId",
                table: "TournamentPlayers",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayers_PlayerId",
                table: "TournamentPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayers_PlayoffStageId",
                table: "TournamentPlayers",
                column: "PlayoffStageId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayers_TournamentId",
                table: "TournamentPlayers",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCards_Lineups_LineupId",
                table: "FootballerCards",
                column: "LineupId",
                principalTable: "Lineups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCards_Lineups_LineupId1",
                table: "FootballerCards",
                column: "LineupId1",
                principalTable: "Lineups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCards_Lineups_LineupId2",
                table: "FootballerCards",
                column: "LineupId2",
                principalTable: "Lineups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCards_Lineups_LineupId3",
                table: "FootballerCards",
                column: "LineupId3",
                principalTable: "Lineups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCards_Lineups_LineupId4",
                table: "FootballerCards",
                column: "LineupId4",
                principalTable: "Lineups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCards_TimeLines_TimeLineId",
                table: "FootballerCards",
                column: "TimeLineId",
                principalTable: "TimeLines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCards_Clubs_ClubId",
                table: "FootballerCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Clubs_ClubId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentPlayers_Clubs_ClubId",
                table: "TournamentPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCards_Lineups_LineupId",
                table: "FootballerCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCards_Lineups_LineupId1",
                table: "FootballerCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCards_Lineups_LineupId2",
                table: "FootballerCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCards_Lineups_LineupId3",
                table: "FootballerCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCards_Lineups_LineupId4",
                table: "FootballerCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCards_TimeLines_TimeLineId",
                table: "FootballerCards");

            migrationBuilder.DropTable(
                name: "ClubsStats");

            migrationBuilder.DropTable(
                name: "FootballersStats");

            migrationBuilder.DropTable(
                name: "GroupStagePlayers");

            migrationBuilder.DropTable(
                name: "PlayersStats");

            migrationBuilder.DropTable(
                name: "Statistic<TournamentPlayer>");

            migrationBuilder.DropTable(
                name: "ClubsGroupStats");

            migrationBuilder.DropTable(
                name: "FootballersGruopStats");

            migrationBuilder.DropTable(
                name: "PlayersGroupStats");

            migrationBuilder.DropTable(
                name: "StatisticGroup<TournamentPlayer>");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Lineups");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "TournamentPlayers");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "TimeLines");

            migrationBuilder.DropTable(
                name: "FootballerCards");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
