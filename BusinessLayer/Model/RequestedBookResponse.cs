using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class RequestedBookResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string UserName { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime Returndate { get; set; }
        public bool RequestStatus { get; set; }

    }
}
