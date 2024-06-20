namespace FcCupApi.Models
{
    public class Stage
    {
        public int Id { get; set; }
        public Tournament Tournament { get; set; }
        public List<Match> Matches { get; set; }
    }
}
