using FcCupApi.Models;

namespace FcCupApi.DBO
{
    public class ShortTournamentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ShortTournamentDTO(Tournament tournament)
        {
            Id = tournament.Id;
            Name = tournament.Name;
            ImageUrl = tournament.ImageUrl;
        }
    }
}
