using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Dal
{
	public interface IbookRepo
	{
		Task<List<Book>> GetAllBooksAsync();
		Task<Book> GetBookByIdAsync(int id);
		Task AddBookAsync(Book book);
		Task UpdateBookAsync(Book book);
		Task DeleteBookAsync(int id);
	}
}
