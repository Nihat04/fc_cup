namespace FcCupApi.Models
{
    public class Comment : SubComment
    {
        public List<SubComment> SubComments { get; set; }
    }
}
