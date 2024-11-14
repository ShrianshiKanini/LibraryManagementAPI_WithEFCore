using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Model
{
    public class Books
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsRequested { get; set; }
    }
}
