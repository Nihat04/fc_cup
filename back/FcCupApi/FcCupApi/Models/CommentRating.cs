namespace FcCupApi.Models
{
    public class CommentRating
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public long UserId { get; set; }
        public int Rate { get; set; }
    }
}
