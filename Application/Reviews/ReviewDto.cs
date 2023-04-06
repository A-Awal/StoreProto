using Application.ReviewReplies;

namespace Application.Reviews
{
    public class ReviewDto
    {
        
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DateCommented { get; set; }
        public string Customer { get; set; }
    }
}