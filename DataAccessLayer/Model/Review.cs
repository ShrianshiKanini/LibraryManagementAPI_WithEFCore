using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Review
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
        public DateTime ReviewDate { get; set; }
        [Required]
        public string ReviewComments { get; set; }
        [Required]
        [Range(0, 10)]
        public decimal Ratings {  get; set; }
    }
}
