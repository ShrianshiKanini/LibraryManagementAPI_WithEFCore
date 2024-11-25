using DataAccessLayer.DTO;

namespace BusinessLayer.Model
{
    public class GenreResponse
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public List<BookDetails> Books { get; set; }
    }
}
