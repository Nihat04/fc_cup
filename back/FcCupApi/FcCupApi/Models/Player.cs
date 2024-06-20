namespace FcCupApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TournamentPlayer> Tournaments { get; set; }
        public List<string> Links { get; set; }
    }
}
