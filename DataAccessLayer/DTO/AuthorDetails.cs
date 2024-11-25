using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class AuthorDetails
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public int Ratings { get; set; }
        public List<BookDetails> Books { get; set; }
    }
}
