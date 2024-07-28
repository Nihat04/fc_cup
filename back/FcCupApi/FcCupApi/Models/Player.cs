namespace FcCupApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public List<TournamentPlayer>? Tournaments { get; set; }
        public List<Statistic<Player>>? Stats { get; set; }
        public List<string>? Links { get; set; }
    }
}
