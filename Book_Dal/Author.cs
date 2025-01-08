using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Dal
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ?ImagePath { get; set; } // Property to store the image path or URL
        public ICollection<Book>? Books { get; set; } // Navigation property for related Books
    }
}
