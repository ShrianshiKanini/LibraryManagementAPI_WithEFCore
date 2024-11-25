
namespace DataAccessLayer.DTO
{
    public class GenreDetails
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public List<BookDetails> Books { get; set; }
    }
}
