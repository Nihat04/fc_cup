﻿// <auto-generated />
using System;
using FcCupApi.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FcCupApi.Migrations.UsersDb
{
    [DbContext(typeof(UsersDbContext))]
    partial class UsersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("FcCupApi.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("FcCupApi.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("CommentText")
                        .HasColumnType("longtext");

                    b.Property<int>("ForumId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("PublishedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ForumId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FcCupApi.Models.CommentRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("CommentRatings");
                });

            modelBuilder.Entity("FcCupApi.Models.FootballerCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardTypeUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("LineupId")
                        .HasColumnType("int");

                    b.Property<int?>("LineupId1")
                        .HasColumnType("int");

                    b.Property<int?>("LineupId2")
                        .HasColumnType("int");

                    b.Property<int?>("LineupId3")
                        .HasColumnType("int");

                    b.Property<int?>("LineupId4")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OverallRating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("LineupId");

                    b.HasIndex("LineupId1");

                    b.HasIndex("LineupId2");

                    b.HasIndex("LineupId3");

                    b.HasIndex("LineupId4");

                    b.ToTable("FootballerCard");
                });

            modelBuilder.Entity("FcCupApi.Models.Forum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("PublishedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Forums");
                });

            modelBuilder.Entity("FcCupApi.Models.Lineup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GoalkeeperId")
                        .HasColumnType("int");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("GoalkeeperId");

                    b.HasIndex("MatchId");

                    b.ToTable("Lineup");
                });

            modelBuilder.Entity("FcCupApi.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Player1Id")
                        .HasColumnType("int");

                    b.Property<int>("Player2Id")
                        .HasColumnType("int");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2Id");

                    b.HasIndex("StageId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("FcCupApi.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Links")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("FcCupApi.Models.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("FcCupApi.Models.Statistic<FcCupApi.Models.FootballerCard>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("StatisticGroupId")
                        .HasColumnType("int")
                        .HasColumnName("StatisticGroup<FootballerCard>Id");

                    b.Property<int?>("TargetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("StatisticGroupId");

                    b.HasIndex("TargetId");

                    b.ToTable("Statistic<FootballerCard>");
                });

            modelBuilder.Entity("FcCupApi.Models.Statistic<FcCupApi.Models.Player>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TargetId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TargetId");

                    b.HasIndex("TournamentPlayerId");

                    b.ToTable("Statistic<Player>");
                });

            modelBuilder.Entity("FcCupApi.Models.Statistic<FcCupApi.Models.TournamentPlayer>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("varchar(34)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("StatisticGroupId")
                        .HasColumnType("int")
                        .HasColumnName("StatisticGroup<TournamentPlayer>Id");

                    b.Property<int?>("TargetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatisticGroupId");

                    b.HasIndex("TargetId");

                    b.ToTable("Statistic<TournamentPlayer>");

                    b.HasDiscriminator().HasValue("Statistic<TournamentPlayer>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.FootballerCard>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<int?>("FootballerCardId")
                        .HasColumnType("int");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("FootballerCardId");

                    b.HasIndex("MatchId");

                    b.ToTable("StatisticGroup<FootballerCard>");
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.TournamentPlayer>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("StatisticGroup<TournamentPlayer>");
                });

            modelBuilder.Entity("FcCupApi.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("FcCupApi.Models.TournamentPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentPlayer");
                });

            modelBuilder.Entity("FcCupApi.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("CommunityStatus")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("FavouriteClubId")
                        .HasColumnType("int");

                    b.Property<int?>("FavouritePlayerId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RegistrationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("FavouriteClubId");

                    b.HasIndex("FavouritePlayerId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<long>", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FcCupApi.Models.CompareStatistic<FcCupApi.Models.TournamentPlayer>", b =>
                {
                    b.HasBaseType("FcCupApi.Models.Statistic<FcCupApi.Models.TournamentPlayer>");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondTargetId")
                        .HasColumnType("int");

                    b.HasIndex("MatchId");

                    b.HasIndex("SecondTargetId");

                    b.HasDiscriminator().HasValue("CompareStatistic<TournamentPlayer>");
                });

            modelBuilder.Entity("FcCupApi.Models.Club", b =>
                {
                    b.HasOne("FcCupApi.Models.User", null)
                        .WithMany("FollowedClubs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FcCupApi.Models.Comment", b =>
                {
                    b.HasOne("FcCupApi.Models.Forum", null)
                        .WithMany("Comments")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FcCupApi.Models.User", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FcCupApi.Models.FootballerCard", b =>
                {
                    b.HasOne("FcCupApi.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FcCupApi.Models.Lineup", null)
                        .WithMany("Attack")
                        .HasForeignKey("LineupId");

                    b.HasOne("FcCupApi.Models.Lineup", null)
                        .WithMany("BottomMidfield")
                        .HasForeignKey("LineupId1");

                    b.HasOne("FcCupApi.Models.Lineup", null)
                        .WithMany("Defense")
                        .HasForeignKey("LineupId2");

                    b.HasOne("FcCupApi.Models.Lineup", null)
                        .WithMany("Subtitutes")
                        .HasForeignKey("LineupId3");

                    b.HasOne("FcCupApi.Models.Lineup", null)
                        .WithMany("UpperMidfield")
                        .HasForeignKey("LineupId4");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("FcCupApi.Models.Lineup", b =>
                {
                    b.HasOne("FcCupApi.Models.FootballerCard", "Goalkeeper")
                        .WithMany()
                        .HasForeignKey("GoalkeeperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FcCupApi.Models.Match", null)
                        .WithMany("Lineups")
                        .HasForeignKey("MatchId");

                    b.Navigation("Goalkeeper");
                });

            modelBuilder.Entity("FcCupApi.Models.Match", b =>
                {
                    b.HasOne("FcCupApi.Models.Club", null)
                        .WithMany("Matches")
                        .HasForeignKey("ClubId");

                    b.HasOne("FcCupApi.Models.TournamentPlayer", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FcCupApi.Models.TournamentPlayer", "Player2")
                        .WithMany()
                        .HasForeignKey("Player2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FcCupApi.Models.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FcCupApi.Models.Tournament", null)
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");

                    b.Navigation("Player1");

                    b.Navigation("Player2");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("FcCupApi.Models.Player", b =>
                {
                    b.HasOne("FcCupApi.Models.User", null)
                        .WithMany("FollowedPlayers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FcCupApi.Models.Stage", b =>
                {
                    b.HasOne("FcCupApi.Models.Tournament", "Tournament")
                        .WithMany("Stages")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("FcCupApi.Models.Statistic<FcCupApi.Models.FootballerCard>", b =>
                {
                    b.HasOne("FcCupApi.Models.Club", null)
                        .WithMany("Stats")
                        .HasForeignKey("ClubId");

                    b.HasOne("FcCupApi.Models.StatisticGroup<FcCupApi.Models.FootballerCard>", null)
                        .WithMany("Stats")
                        .HasForeignKey("StatisticGroupId");

                    b.HasOne("FcCupApi.Models.FootballerCard", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("FcCupApi.Models.Statistic<FcCupApi.Models.Player>", b =>
                {
                    b.HasOne("FcCupApi.Models.Player", "Target")
                        .WithMany("Stats")
                        .HasForeignKey("TargetId");

                    b.HasOne("FcCupApi.Models.TournamentPlayer", null)
                        .WithMany("PlayerStats")
                        .HasForeignKey("TournamentPlayerId");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("FcCupApi.Models.Statistic<FcCupApi.Models.TournamentPlayer>", b =>
                {
                    b.HasOne("FcCupApi.Models.StatisticGroup<FcCupApi.Models.TournamentPlayer>", null)
                        .WithMany("Stats")
                        .HasForeignKey("StatisticGroupId");

                    b.HasOne("FcCupApi.Models.TournamentPlayer", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.FootballerCard>", b =>
                {
                    b.HasOne("FcCupApi.Models.Club", null)
                        .WithMany("FootballersStats")
                        .HasForeignKey("ClubId");

                    b.HasOne("FcCupApi.Models.FootballerCard", null)
                        .WithMany("Stats")
                        .HasForeignKey("FootballerCardId");

                    b.HasOne("FcCupApi.Models.Match", null)
                        .WithMany("FootballerCardsStats")
                        .HasForeignKey("MatchId");
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.TournamentPlayer>", b =>
                {
                    b.HasOne("FcCupApi.Models.Tournament", null)
                        .WithMany("Stats")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("FcCupApi.Models.TournamentPlayer", b =>
                {
                    b.HasOne("FcCupApi.Models.Club", "Club")
                        .WithMany("Tournaments")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FcCupApi.Models.Player", "Player")
                        .WithMany("Tournaments")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FcCupApi.Models.Tournament", "Tournament")
                        .WithMany("Players")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Player");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("FcCupApi.Models.User", b =>
                {
                    b.HasOne("FcCupApi.Models.Club", "FavouriteClub")
                        .WithMany()
                        .HasForeignKey("FavouriteClubId");

                    b.HasOne("FcCupApi.Models.Player", "FavouritePlayer")
                        .WithMany()
                        .HasForeignKey("FavouritePlayerId");

                    b.Navigation("FavouriteClub");

                    b.Navigation("FavouritePlayer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<long>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("FcCupApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("FcCupApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<long>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FcCupApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("FcCupApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FcCupApi.Models.CompareStatistic<FcCupApi.Models.TournamentPlayer>", b =>
                {
                    b.HasOne("FcCupApi.Models.Match", null)
                        .WithMany("Stats")
                        .HasForeignKey("MatchId");

                    b.HasOne("FcCupApi.Models.TournamentPlayer", "SecondTarget")
                        .WithMany()
                        .HasForeignKey("SecondTargetId");

                    b.Navigation("SecondTarget");
                });

            modelBuilder.Entity("FcCupApi.Models.Club", b =>
                {
                    b.Navigation("FootballersStats");

                    b.Navigation("Matches");

                    b.Navigation("Stats");

                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("FcCupApi.Models.FootballerCard", b =>
                {
                    b.Navigation("Stats");
                });

            modelBuilder.Entity("FcCupApi.Models.Forum", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("FcCupApi.Models.Lineup", b =>
                {
                    b.Navigation("Attack");

                    b.Navigation("BottomMidfield");

                    b.Navigation("Defense");

                    b.Navigation("Subtitutes");

                    b.Navigation("UpperMidfield");
                });

            modelBuilder.Entity("FcCupApi.Models.Match", b =>
                {
                    b.Navigation("FootballerCardsStats");

                    b.Navigation("Lineups");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("FcCupApi.Models.Player", b =>
                {
                    b.Navigation("Stats");

                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.FootballerCard>", b =>
                {
                    b.Navigation("Stats");
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.TournamentPlayer>", b =>
                {
                    b.Navigation("Stats");
                });

            modelBuilder.Entity("FcCupApi.Models.Tournament", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Players");

                    b.Navigation("Stages");

                    b.Navigation("Stats");
                });

            modelBuilder.Entity("FcCupApi.Models.TournamentPlayer", b =>
                {
                    b.Navigation("PlayerStats");
                });

            modelBuilder.Entity("FcCupApi.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FollowedClubs");

                    b.Navigation("FollowedPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
