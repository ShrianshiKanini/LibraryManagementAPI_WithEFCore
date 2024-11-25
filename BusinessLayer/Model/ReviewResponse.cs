
namespace BusinessLayer.Model
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string UserName { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewComments { get; set; }
        public decimal Ratings { get; set; }
    }
}
