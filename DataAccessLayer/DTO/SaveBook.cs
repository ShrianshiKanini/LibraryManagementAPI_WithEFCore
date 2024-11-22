namespace DataAccessLayer.DTO
{
    public class SaveBook
    {
        public int Id {  get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BookStatus { get; set; }

    }
}
