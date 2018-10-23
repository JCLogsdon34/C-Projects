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
        public int BookID { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
       // public int AuthorID { get; set; }
      //  public ArrayList Authors = new ArrayList();
 //       public int PublisherID { get; set; }
        public string Publisher { get; set; }
        public int ReleaseDate { get; set; }
    }
}
