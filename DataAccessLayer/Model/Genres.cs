using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Model
{
    public class Genres
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Genre { get; set; }
        public virtual ICollection<Books> Books { get; set; } = new List<Books>();
    }
}
