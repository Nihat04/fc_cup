using FcCupApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FcCupApi.Contexts
{
    public class FcCupDbContext:DbContext
    {
        public FcCupDbContext(DbContextOptions<FcCupDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tournament> Tournaments { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<TournamentPlayer> TournamentPlayers { get; set; } = null!;
        public DbSet<Club> Clubs { get; set; } = null!;
        public DbSet<Match> Matches { get; set; } = null!;
        public DbSet<FootballerCard> FootballerCards { get; set; } = null!;
        public DbSet<Stage> Stages { get; set; } = null!;
        public DbSet<PlayoffStage> PlayoffStages { get; set; } = null!;
        public DbSet<GroupStage> GroupStages { get; set; } = null!;
        public DbSet<GroupStagePlayer> GroupStagePlayers { get; set; } = null!;
        public DbSet<TimeLine> TimeLines { get; set; } = null!;
        public DbSet<Statistic<Player>> PlayersStats { get; set; } = null!;
        public DbSet<Statistic<Club>> ClubsStats { get; set; } = null!;
        public DbSet<Statistic<FootballerCard>> FootballersStats { get; set; } = null!;
        public DbSet<Lineup> Lineups { get; set; } = null!;
    }
}   
