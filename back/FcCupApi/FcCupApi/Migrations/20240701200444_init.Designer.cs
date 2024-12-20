﻿// <auto-generated />
using System;
using FcCupApi.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FcCupApi.Migrations
{
    [DbContext(typeof(FcCupDbContext))]
    [Migration("20240701200444_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
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

                    b.HasKey("Id");

                    b.ToTable("Clubs");
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

                    b.Property<int?>("TimeLineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("LineupId");

                    b.HasIndex("LineupId1");

                    b.HasIndex("LineupId2");

                    b.HasIndex("LineupId3");

                    b.HasIndex("LineupId4");

                    b.HasIndex("TimeLineId");

                    b.ToTable("FootballerCards");
                });

            modelBuilder.Entity("FcCupApi.Models.GroupStagePlayer", b =>
                {
                    b.Property<int>("Draws")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("Loses")
                        .HasColumnType("int");

                    b.Property<int>("MissedGoals")
                        .HasColumnType("int");

                    b.Property<int>("PlayedGames")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("TournamentPlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasIndex("TournamentPlayerId");

                    b.ToTable("GroupStagePlayers");
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

                    b.ToTable("Lineups");
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

                    b.ToTable("Matches");
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

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FcCupApi.Models.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Stages");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Stage");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FcCupApi.Models.Statistic<FcCupApi.Models.Club>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("StatisticGroupId")
                        .HasColumnType("int")
                        .HasColumnName("StatisticGroup<Club>Id");

                    b.Property<int?>("TargetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatisticGroupId");

                    b.HasIndex("TargetId");

                    b.ToTable("ClubsStats");
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

                    b.ToTable("FootballersStats");
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

                    b.Property<int?>("StatisticGroupId")
                        .HasColumnType("int")
                        .HasColumnName("StatisticGroup<Player>Id");

                    b.Property<int?>("TargetId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatisticGroupId");

                    b.HasIndex("TargetId");

                    b.HasIndex("TournamentPlayerId");

                    b.ToTable("PlayersStats");
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("Statistic<TournamentPlayer>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.Club>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ClubsGroupStats");
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

                    b.ToTable("FootballersGruopStats");
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.Player>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PlayersGroupStats");
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

            modelBuilder.Entity("FcCupApi.Models.TimeLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FootballerId")
                        .HasColumnType("int");

                    b.Property<int>("Minute")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FootballerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("TimeLines");
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

                    b.ToTable("Tournaments");
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

                    b.Property<int?>("PlayoffStageId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("PlayoffStageId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentPlayers");
                });

            modelBuilder.Entity("FcCupApi.Models.GroupStage", b =>
                {
                    b.HasBaseType("FcCupApi.Models.Stage");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("GroupStage");
                });

            modelBuilder.Entity("FcCupApi.Models.PlayoffStage", b =>
                {
                    b.HasBaseType("FcCupApi.Models.Stage");

                    b.HasDiscriminator().HasValue("PlayoffStage");
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

                    b.HasOne("FcCupApi.Models.TimeLine", null)
                        .WithMany("OtherFootballers")
                        .HasForeignKey("TimeLineId");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("FcCupApi.Models.GroupStagePlayer", b =>
                {
                    b.HasOne("FcCupApi.Models.TournamentPlayer", "TournamentPlayer")
                        .WithMany()
                        .HasForeignKey("TournamentPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TournamentPlayer");
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

            modelBuilder.Entity("FcCupApi.Models.Stage", b =>
                {
                    b.HasOne("FcCupApi.Models.Tournament", "Tournament")
                        .WithMany("Stages")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("FcCupApi.Models.Statistic<FcCupApi.Models.Club>", b =>
                {
                    b.HasOne("FcCupApi.Models.StatisticGroup<FcCupApi.Models.Club>", null)
                        .WithMany("Stats")
                        .HasForeignKey("StatisticGroupId");

                    b.HasOne("FcCupApi.Models.Club", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId");

                    b.Navigation("Target");
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
                    b.HasOne("FcCupApi.Models.StatisticGroup<FcCupApi.Models.Player>", null)
                        .WithMany("Stats")
                        .HasForeignKey("StatisticGroupId");

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

            modelBuilder.Entity("FcCupApi.Models.TimeLine", b =>
                {
                    b.HasOne("FcCupApi.Models.FootballerCard", "Footballer")
                        .WithMany()
                        .HasForeignKey("FootballerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FcCupApi.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Footballer");

                    b.Navigation("Player");
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

                    b.HasOne("FcCupApi.Models.PlayoffStage", null)
                        .WithMany("TournamentPlayers")
                        .HasForeignKey("PlayoffStageId");

                    b.HasOne("FcCupApi.Models.Tournament", "Tournament")
                        .WithMany("Players")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");

                    b.Navigation("Player");

                    b.Navigation("Tournament");
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

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.Club>", b =>
                {
                    b.Navigation("Stats");
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.FootballerCard>", b =>
                {
                    b.Navigation("Stats");
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.Player>", b =>
                {
                    b.Navigation("Stats");
                });

            modelBuilder.Entity("FcCupApi.Models.StatisticGroup<FcCupApi.Models.TournamentPlayer>", b =>
                {
                    b.Navigation("Stats");
                });

            modelBuilder.Entity("FcCupApi.Models.TimeLine", b =>
                {
                    b.Navigation("OtherFootballers");
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

            modelBuilder.Entity("FcCupApi.Models.PlayoffStage", b =>
                {
                    b.Navigation("TournamentPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
