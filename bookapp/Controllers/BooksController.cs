using Book_BLL;
using Book_Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookapp.Controllers
{
	public class BooksController : Controller
	{
		private readonly BookService _bookService;
        private readonly AuthorService _authorService;

        public BooksController(BookService bookService, AuthorService authorService)
		{
			_bookService = bookService;
            _authorService = authorService;

        }

		// GET: Books
		public async Task<IActionResult> Index()
		{
			var books = await _bookService.GetAllBooksAsync();
			return View(books);
		}

		// GET: Books/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var book = await _bookService.GetBookByIdAsync(id.Value);
			if (book == null)
			{
				return NotFound();// If no book is found with that ID
            }

			return View(book); //Pass the book object to the view

        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "AuthorId", "Name");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Title, AuthorId, YearPublished")] Book book)
		{
			if (ModelState.IsValid)
			{
				await _bookService.AddBookAsync(book);
				return RedirectToAction(nameof(Index));
			}
            ViewBag.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "AuthorId", "Name", book.AuthorId);
            return View(book);
		}

		// GET: Books/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var book = await _bookService.GetBookByIdAsync(id.Value);
			if (book == null)
			{
				return NotFound();
			}
            ViewBag.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "AuthorId", "Name", book.AuthorId);
            return View(book);
		}

		// POST: Books/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id, Title, AuthorId, YearPublished")] Book book)
		{
			if (id != book.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				await _bookService.UpdateBookAsync(book);
				return RedirectToAction(nameof(Index));
			}
			return View(book);
		}

		// GET: Books/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var book = await _bookService.GetBookByIdAsync(id.Value);
			if (book == null)
			{
				return NotFound();
			}
			return View(book);
		}

		// POST: Books/Delete/5
		[HttpPost, ActionName("DeleteConfirmed")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _bookService.DeleteBookAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
