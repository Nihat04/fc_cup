namespace FcCupApi.Models
{
    public class FootballerCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Club Club { get; set; }
        public string CardTypeUrl { get; set; }
        public int OverallRating { get; set; }
        public List<StatisticGroup<FootballerCard>> Stats { get; set; }
    }
}
