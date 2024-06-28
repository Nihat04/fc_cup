namespace FcCupApi.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Stage> Stages { get; set; }
        public List<TournamentPlayer> Players { get; set; }
        public List<Match> Matches { get; set; }
        public List<StatisticGroup<TournamentPlayer>> Stats { get; set; }
    }
}
