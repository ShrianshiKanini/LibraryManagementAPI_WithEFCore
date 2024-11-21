using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Authors
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public int Ratings {  get; set; }
        public virtual ICollection<Books> Books { get; set; } = new List<Books>();

    }
}
