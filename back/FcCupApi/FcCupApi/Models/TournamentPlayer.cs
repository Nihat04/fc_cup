using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FcCupApi.Models
{
    public class TournamentPlayer
    {
        public int Id { get; set; }
        
        public Player Player { get; set; }
        public Tournament Tournament { get; set; }
        public Club? Club { get; set; }
        public List<Statistic<Player>>? PlayerStats { get; set; }
    }
 }