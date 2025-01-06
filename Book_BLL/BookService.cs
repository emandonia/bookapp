using Book_Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_BLL
{
	public class BookService
	{
		private readonly IbookRepo _bookRepository;

		public BookService(IbookRepo bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<IEnumerable<Book>> GetAllBooksAsync()
		{
			return await _bookRepository.GetAllBooksAsync();
		}

		public async Task<Book> GetBookByIdAsync(int id)
		{
			return await _bookRepository.GetBookByIdAsync(id);
		}

		public async Task AddBookAsync(Book book)
		{
			await _bookRepository.AddBookAsync(book);
		}

		public async Task UpdateBookAsync(Book book)
		{
			await _bookRepository.UpdateBookAsync(book);
		}

		public async Task DeleteBookAsync(int id)
		{
			await _bookRepository.DeleteBookAsync(id);
		}
	}
}
