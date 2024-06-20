namespace FcCupApi.Models
{
    public class GroupStage: Stage
    {
        public string Name { get; set; }
        public List<GroupStagePlayer> GroupPlayers { get; set; }
        public Tournament Tournament { get; set; }
    }
}
