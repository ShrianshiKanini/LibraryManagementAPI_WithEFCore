using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Model
{
    public class Books
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Authors Authors { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genres Genres { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string BookStatus { get; set; }

        [Required]
        public int Ratings { get; set; }
    }
}
