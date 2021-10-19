using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Book
    {
        public int ISBN { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int GenreID { get; set; }

    }
}
