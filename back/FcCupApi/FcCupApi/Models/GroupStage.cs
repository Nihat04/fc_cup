using System.ComponentModel.DataAnnotations.Schema;

namespace FcCupApi.Models
{
    public class GroupStage: Stage
    {
        public string Name { get; set; }
        [NotMapped]
        public List<GroupStagePlayer> GroupPlayers { get; set; }
        public Tournament Tournament { get; set; }
    }
}
