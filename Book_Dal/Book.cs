using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Dal
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
	
		public int YearPublished { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
