using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Dal
{
	public class BookRepo: IbookRepo
	{
		private readonly ApplicationDbContext _context;

		public BookRepo(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<Book>> GetAllBooksAsync()
		{
			return await _context.Books.ToListAsync();
		}

		public async Task<Book> GetBookByIdAsync(int id)
		{
			return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
		}

		public async Task AddBookAsync(Book book)
		{
			await _context.Books.AddAsync(book);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateBookAsync(Book book)
		{
			_context.Books.Update(book);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteBookAsync(int id)
		{
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
		}
	}
}
