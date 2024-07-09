using FcCupApi.Entities;
using Microsoft.AspNetCore.Identity;

namespace FcCupApi.Models
{
    public class User : IdentityUser, IBaseEntity
    {
        public long Id {  get; set; }
        public override string Email {  get; set; }
        public override string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public List<Comment>? Comments { get ; set; }
        public Club? FavouriteClub { get; set; }
        public Player? FavouritePlayer { get; set; }
        public List<Club>? FollowedClubs {  get; set; }
        public List<Player>? FollowedPlayers { get; set; }
        public Status? CommunityStatus { get; set; }
        // rating 
    }

    public enum Status
    {
        Loh,
        OldMan,
        NewFag,
        RonaldoSon
    }
}
