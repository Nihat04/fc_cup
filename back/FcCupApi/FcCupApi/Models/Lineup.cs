using System.ComponentModel.DataAnnotations.Schema;

namespace FcCupApi.Models
{
    public class Lineup
    {
        public int Id { get; set; }
        public DateTime Year { get; set; }
        public List<FootballerCard> Attack {  get; set; }
        public List<FootballerCard> UpperMidfield {  get; set; }
        public List<FootballerCard> BottomMidfield {  get; set; }
        public List<FootballerCard> Defense {  get; set; }
        public FootballerCard Goalkeeper {  get; set; }
        public List<FootballerCard> Subtitutes { get; set; }
    }
}
