using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class BookResponse
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int GenreId { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BookStatus { get; set; }
        public int Ratings { get; set; }
    }
}
