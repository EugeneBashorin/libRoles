using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryProject.Models
{
    public class IndexModel
    {
        public List<Book> Books { get; set; }
        public List<Magazine> Magazines { get; set; }
        public List<Newspaper> Newspapers { get; set; }
    }
}