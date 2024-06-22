using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FcCupApi.Models
{
    public class TournamentPlayer
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public int ClubLineUpId { get; set; }
        [ForeignKey(nameof(ClubLineUpId))]
        public Lineup ClubLineup { get; set; }
        public List<Statistic<Player>> PlayerStats { get; set; }
    }
}
