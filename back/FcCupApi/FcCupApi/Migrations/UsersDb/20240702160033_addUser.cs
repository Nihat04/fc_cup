using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FcCupApi.Migrations.UsersDb
{
    /// <inheritdoc />
    public partial class addUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tournament",
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
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stage_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
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
                        name: "FK_StatisticGroup<TournamentPlayer>_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FavouriteClubId = table.Column<int>(type: "int", nullable: true),
                    FavouritePlayerId = table.Column<int>(type: "int", nullable: true),
                    CommunityStatus = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Club_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Links = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CommentText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublishedDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ForumId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubComment_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubComment_Forums_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubComment_SubComment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "SubComment",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TournamentPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Match",
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
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Stage_StageId",
                        column: x => x.StageId,
                        principalTable: "Stage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_TournamentPlayer_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "TournamentPlayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_TournamentPlayer_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "TournamentPlayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Statistic<Player>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TargetId = table.Column<int>(type: "int", nullable: true),
                    TournamentPlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic<Player>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistic<Player>_Player_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Player",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statistic<Player>_TournamentPlayer_TournamentPlayerId",
                        column: x => x.TournamentPlayerId,
                        principalTable: "TournamentPlayer",
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
                        name: "FK_Statistic<TournamentPlayer>_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statistic<TournamentPlayer>_StatisticGroup<TournamentPlayer>~",
                        column: x => x.StatisticGroupTournamentPlayerId,
                        principalTable: "StatisticGroup<TournamentPlayer>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statistic<TournamentPlayer>_TournamentPlayer_SecondTargetId",
                        column: x => x.SecondTargetId,
                        principalTable: "TournamentPlayer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statistic<TournamentPlayer>_TournamentPlayer_TargetId",
                        column: x => x.TargetId,
                        principalTable: "TournamentPlayer",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FootballerCard",
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
                    LineupId4 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballerCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballerCard_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lineup",
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
                    table.PrimaryKey("PK_Lineup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lineup_FootballerCard_GoalkeeperId",
                        column: x => x.GoalkeeperId,
                        principalTable: "FootballerCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lineup_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StatisticGroup<FootballerCard>",
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
                    table.PrimaryKey("PK_StatisticGroup<FootballerCard>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticGroup<FootballerCard>_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatisticGroup<FootballerCard>_FootballerCard_FootballerCard~",
                        column: x => x.FootballerCardId,
                        principalTable: "FootballerCard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatisticGroup<FootballerCard>_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Statistic<FootballerCard>",
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
                    table.PrimaryKey("PK_Statistic<FootballerCard>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistic<FootballerCard>_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statistic<FootballerCard>_FootballerCard_TargetId",
                        column: x => x.TargetId,
                        principalTable: "FootballerCard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Statistic<FootballerCard>_StatisticGroup<FootballerCard>_Sta~",
                        column: x => x.StatisticGroupFootballerCardId,
                        principalTable: "StatisticGroup<FootballerCard>",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavouriteClubId",
                table: "AspNetUsers",
                column: "FavouriteClubId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavouritePlayerId",
                table: "AspNetUsers",
                column: "FavouritePlayerId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Club_UserId",
                table: "Club",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCard_ClubId",
                table: "FootballerCard",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCard_LineupId",
                table: "FootballerCard",
                column: "LineupId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCard_LineupId1",
                table: "FootballerCard",
                column: "LineupId1");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCard_LineupId2",
                table: "FootballerCard",
                column: "LineupId2");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCard_LineupId3",
                table: "FootballerCard",
                column: "LineupId3");

            migrationBuilder.CreateIndex(
                name: "IX_FootballerCard_LineupId4",
                table: "FootballerCard",
                column: "LineupId4");

            migrationBuilder.CreateIndex(
                name: "IX_Lineup_GoalkeeperId",
                table: "Lineup",
                column: "GoalkeeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineup_MatchId",
                table: "Lineup",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_ClubId",
                table: "Match",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Player1Id",
                table: "Match",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Player2Id",
                table: "Match",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_StageId",
                table: "Match",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TournamentId",
                table: "Match",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_UserId",
                table: "Player",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stage_TournamentId",
                table: "Stage",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic<FootballerCard>_ClubId",
                table: "Statistic<FootballerCard>",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic<FootballerCard>_StatisticGroup<FootballerCard>Id",
                table: "Statistic<FootballerCard>",
                column: "StatisticGroup<FootballerCard>Id");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic<FootballerCard>_TargetId",
                table: "Statistic<FootballerCard>",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic<Player>_TargetId",
                table: "Statistic<Player>",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic<Player>_TournamentPlayerId",
                table: "Statistic<Player>",
                column: "TournamentPlayerId");

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
                name: "IX_StatisticGroup<FootballerCard>_ClubId",
                table: "StatisticGroup<FootballerCard>",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticGroup<FootballerCard>_FootballerCardId",
                table: "StatisticGroup<FootballerCard>",
                column: "FootballerCardId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticGroup<FootballerCard>_MatchId",
                table: "StatisticGroup<FootballerCard>",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticGroup<TournamentPlayer>_TournamentId",
                table: "StatisticGroup<TournamentPlayer>",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubComment_AuthorId",
                table: "SubComment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubComment_CommentId",
                table: "SubComment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubComment_ForumId",
                table: "SubComment",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_ClubId",
                table: "TournamentPlayer",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_PlayerId",
                table: "TournamentPlayer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_TournamentId",
                table: "TournamentPlayer",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Club_FavouriteClubId",
                table: "AspNetUsers",
                column: "FavouriteClubId",
                principalTable: "Club",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Player_FavouritePlayerId",
                table: "AspNetUsers",
                column: "FavouritePlayerId",
                principalTable: "Player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCard_Lineup_LineupId",
                table: "FootballerCard",
                column: "LineupId",
                principalTable: "Lineup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCard_Lineup_LineupId1",
                table: "FootballerCard",
                column: "LineupId1",
                principalTable: "Lineup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCard_Lineup_LineupId2",
                table: "FootballerCard",
                column: "LineupId2",
                principalTable: "Lineup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCard_Lineup_LineupId3",
                table: "FootballerCard",
                column: "LineupId3",
                principalTable: "Lineup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballerCard_Lineup_LineupId4",
                table: "FootballerCard",
                column: "LineupId4",
                principalTable: "Lineup",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_UserId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_AspNetUsers_UserId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCard_Club_ClubId",
                table: "FootballerCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Club_ClubId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentPlayer_Club_ClubId",
                table: "TournamentPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentPlayer_Player_PlayerId",
                table: "TournamentPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCard_Lineup_LineupId",
                table: "FootballerCard");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCard_Lineup_LineupId1",
                table: "FootballerCard");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCard_Lineup_LineupId2",
                table: "FootballerCard");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCard_Lineup_LineupId3",
                table: "FootballerCard");

            migrationBuilder.DropForeignKey(
                name: "FK_FootballerCard_Lineup_LineupId4",
                table: "FootballerCard");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Statistic<FootballerCard>");

            migrationBuilder.DropTable(
                name: "Statistic<Player>");

            migrationBuilder.DropTable(
                name: "Statistic<TournamentPlayer>");

            migrationBuilder.DropTable(
                name: "SubComment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "StatisticGroup<FootballerCard>");

            migrationBuilder.DropTable(
                name: "StatisticGroup<TournamentPlayer>");

            migrationBuilder.DropTable(
                name: "Forums");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Lineup");

            migrationBuilder.DropTable(
                name: "FootballerCard");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Stage");

            migrationBuilder.DropTable(
                name: "TournamentPlayer");

            migrationBuilder.DropTable(
                name: "Tournament");
        }
    }
}
