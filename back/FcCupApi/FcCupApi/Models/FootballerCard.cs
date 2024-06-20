namespace FcCupApi.Models
{
    public class FootballerCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string CardTypeUrl { get; set; }
        public int OverallRating { get; set; }
        public List<Statistic<FootballerCard>> Stats { get; set; }
    }
}
