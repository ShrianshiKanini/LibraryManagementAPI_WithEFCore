using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Model
{
    public class RequestedBooks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Books Books { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public DateTime Returndate { get; set; }

        [Required]
        public bool RequestStatus { get; set; }
       
    }
}
