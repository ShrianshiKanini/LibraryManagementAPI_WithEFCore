using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class SaveRequestdBook
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime Returndate { get; set; }
        public bool RequestStatus { get; set; }
    }
}
