namespace FcCupApi.Models
{
    public class PlayerTournamentPerformance
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public Lineup ClubLineup { get; set; }
        public List<Statistic<Player>> PlayerStats { get; set; }
        public List<StatisticGroup<FootballerCard>> FootballersStats { get; set; }
    }
}
