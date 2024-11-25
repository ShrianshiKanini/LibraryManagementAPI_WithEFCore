using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class SaveReview
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewComments { get; set; }
        public decimal Ratings { get; set; }
    }
}
