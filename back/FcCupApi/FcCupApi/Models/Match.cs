using System.ComponentModel.DataAnnotations.Schema;

namespace FcCupApi.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TournamentPlayer Player1 { get; set; }
        public TournamentPlayer Player2 { get; set; }
        [NotMapped]
        public List<TimeLine> TimeLines { get; set; }
        public List<CompareStatistic<TournamentPlayer>>? Stats { get; set; }
        public List<StatisticGroup<FootballerCard>>? FootballerCardsStats { get; set; }
        public Stage Stage { get; set; }
    }
}