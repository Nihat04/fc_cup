using FcCupApi.Models;

namespace FcCupApi.DBO
{
    public class ShortTournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ShortTournament(Tournament tournament)
        {
            Id = tournament.Id;
            Name = tournament.Name;
            ImageUrl = tournament.ImageUrl;
        }
    }
}
