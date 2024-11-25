
using DataAccessLayer.DTO;

namespace BusinessLayer.Model
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public int Ratings { get; set; }
        public List<BookDetails> Books { get; set; }
    }
}
