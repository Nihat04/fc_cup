namespace FcCupApi.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TournamentPlayer> Tournaments { get; set; }
        public string LogoUrl { get; set; }
        public List<Match> Matches { get; set; }
        public Lineup Lineup { get; set; }
        public List<Statistic<FootballerCard>> Stats { get; set; }
        public List<Statistic<FootballerCard>> FootballersStats { get; set; }
    }
}
