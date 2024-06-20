namespace FcCupApi.Models
{
    public class TournamentPlayer
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public Tournament Tournament { get; set; }
        public Club Club { get; set; }
        public List<Statistic<Player>> PlayerStats { get; set; }
    }
}
