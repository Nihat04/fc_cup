using System.Runtime.CompilerServices;

namespace FcCupApi.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime PublishedDateTime { get; set; }
    }
}
