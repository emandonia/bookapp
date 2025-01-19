using Book_BLL;
using Book_Dal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace bookapp.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationRepo _reservationRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;  // For saving files to the server
        private readonly BookService _bookService;
        public ReservationsController(IReservationRepo reservationRepository, BookService bookService, IWebHostEnvironment webHostEnvironment)
        {
            _reservationRepository = reservationRepository;
            _webHostEnvironment = webHostEnvironment;
            _bookService= bookService;
        }
        public async Task<IActionResult> Index()
        {
            // Retrieve all reservations from the repository
            var reservations = await _reservationRepository.GetAllReservationsAsync();

            // Return the Index view with the list of reservations
            return View(reservations);
        }


        // GET: Create Reservation
        public async Task<IActionResult> Create()
        {
            // Populate the Books for the dropdown

            ViewData["Books"] = new SelectList(await _bookService.GetAllBooksAsync(), "Id", "Title");
            //var books = await _reservationRepository.GetAllReservationsAsync();
            //ViewData["Books"] = books.Select(book => new SelectListItem
            //{
            //    Value = book.BookId.ToString(),
            //    Text = book.Book.Title
            //}).ToList();
            return View();
        }

        // POST: Create Reservation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVMReservation viewModel)
        {
            if (ModelState.IsValid)
            {
                bool isReserved = await _reservationRepository.IsBookReservedAsync(
           viewModel.BookId, viewModel.StartDate, viewModel.EndDate);
                if (!isReserved)
                {
                    // Handle file upload for the image
                    if (viewModel.ImageFiles != null)
                    {
                        // Upload the file and get the file path
                        var fileName = Path.GetFileNameWithoutExtension(viewModel.ImageFiles.FileName);
                        var extension = Path.GetExtension(viewModel.ImageFiles.FileName);
                        var newFileName = fileName + "_" + Guid.NewGuid().ToString() + extension;
                        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", newFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await viewModel.ImageFiles.CopyToAsync(fileStream);
                        }

                        // Update the UserImagepath in the reservation view model
                        viewModel.UserImagepath = "/images/" + newFileName;
                    }

                    // Create Reservation object and save
                    var reservation = new Reservation
                    {
                        BookId = viewModel.BookId,
                        StartDate = viewModel.StartDate,
                        EndDate = viewModel.EndDate,
                        ReservedBy = viewModel.ReservedBy,
                        UserImagepath = viewModel.UserImagepath,
                         CountryId = viewModel.CountryId,
                        StateId = viewModel.StateId,
                        CityId = viewModel.CityId
                    };

                    await _reservationRepository.AddReservationAsync(reservation);

                    return RedirectToAction(nameof(Index)); // Redirect to a list or details page after successful creation
                }
            }
            ModelState.AddModelError(string.Empty, "The book is already reserved for the selected dates.");
            // If something goes wrong, return the same view with the current data
            ViewData["Books"] = new SelectList(await _bookService.GetAllBooksAsync(), "Id", "Title", viewModel.BookId);
            viewModel.Countries = _reservationRepository.GetCountries()  // Synchronous method, no await
            .Select(c => new SelectListItem
            {
                Value = c.CountryId.ToString(),
                Text = c.Name
            })
            .ToList();
            return View(viewModel);
        }
        // GET: Delete Reservation
        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Delete Reservation
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            await _reservationRepository.DeleteReservationAsync(id);
            return RedirectToAction(nameof(Index)); // Redirect back to the index page after deletion
        }
        // Get States by Country
        public JsonResult GetStates(int countryId)
        {
            var states = _reservationRepository.GetStatesByCountry(countryId).Select(s => new SelectListItem
            {
                Value = s.StateId.ToString(),
                Text = s.Name
            }).ToList();

            return Json(states);
        }

        // Get Cities by State
        public JsonResult GetCities(int stateId)
        {
            var cities = _reservationRepository.GetCitiesByState(stateId).Select(c => new SelectListItem
            {
                Value = c.CityId.ToString(),
                Text = c.Name
            }).ToList();

            return Json(cities);
        }
    }
    }
