namespace FcCupApi.Models
{
    public class SubComment
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public long AuthorId { get; set; }
        public string CommentText { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public int Rating { get; set; }
        public int ForumId { get; set; }
    }

}
