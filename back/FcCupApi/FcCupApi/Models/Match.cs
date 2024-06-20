namespace FcCupApi.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TournamentPlayer Player1 { get; set; }
        public TournamentPlayer Player2 { get; set; }
        public List<TimeLine> TimeLines { get; set; }
        public List<Statistic<TournamentPlayer>>? GeneralStats { get; set; }
        public List<Statistic<FootballerCard>>? FootballerCardsStats { get; set; }
        public Stage Stage { get; set; }
    }
}