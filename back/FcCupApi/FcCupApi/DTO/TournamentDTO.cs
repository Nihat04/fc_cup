using FcCupApi.Models;

namespace FcCupApi.DTO
{
    public class TournamentDTO
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? BannerImage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
