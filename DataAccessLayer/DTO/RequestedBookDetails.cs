
namespace DataAccessLayer.DTO
{
    public class RequestedBookDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string UserName { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool RequestStatus { get; set; }
    }
}
