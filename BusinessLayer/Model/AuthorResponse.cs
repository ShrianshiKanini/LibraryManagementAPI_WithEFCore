using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public int Ratings { get; set; }
    }
}
