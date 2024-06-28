using Microsoft.EntityFrameworkCore;

namespace FcCupApi.Models
{
    [Keyless]
    public class PlayerClub
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int ClubId { get; set; }
        public Player Club{ get; set; }
    }
}
