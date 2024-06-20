namespace FcCupApi.Models
{
    public class GroupStagePlayer
    {
        public TournamentPlayer TournamentPlayer {  get; set; }
        public int PlayedGames { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }
        public int Goals { get; set; }
        public int MissedGoals { get; set; }
        public int Points { get; set; }
        public List<Match> Matches { get; set; }
    }
}
