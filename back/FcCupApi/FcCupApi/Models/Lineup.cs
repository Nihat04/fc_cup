namespace FcCupApi.Models
{
    public class Lineup
    {
        public string Id { get; set; }
        public Club Club { get; set; }
        public DateTime Year { get; set; }
        public List<FootballerCard> Attack {  get; set; }
        public List<FootballerCard> UpperMidfield {  get; set; }
        public List<FootballerCard> BottomMidfield {  get; set; }
        public List<FootballerCard> Defense {  get; set; }
        public FootballerCard GoalKeeper {  get; set; }
        public List<FootballerCard> Subtitutes { get; set; }
    }
}
