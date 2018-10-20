using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.BookShelf.Models
{
    public class Book
    {
        public int bookID { get; set; }
        public string Title { get; set; }
        public int authorID { get; set; }
        public ArrayList Authors = new ArrayList();
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        public int ReleaseDate { get; set; }
    }
}
