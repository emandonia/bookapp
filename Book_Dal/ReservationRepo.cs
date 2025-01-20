using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Dal
{
    public class ReservationRepo: IReservationRepo
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all reservations
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations
                .Include(r => r.Book) // Optionally include related Book data
                .ToListAsync();
        }

        // Get a reservation by its ID
        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Book) // Optionally include related Book data
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        // Add a new reservation
        public async Task AddReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        // Delete a reservation by ID
        public async Task DeleteReservationAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }

        // Check if a book is reserved in the specified date range
        public async Task<bool> IsBookReservedAsync(int ?bookId, DateTime startDate, DateTime endDate)
        {
            return await _context.Reservations
                .AnyAsync(r => r.BookId == bookId &&
                    ((startDate >= r.StartDate && startDate <= r.EndDate) ||
                     (endDate >= r.StartDate && endDate <= r.EndDate)));
        }
        //public async Task<IEnumerable<Country>> GetCountries()
        //{
        //    return _context.Countries.ToListAsync();

        //}
        public async Task<List<Country>> GetCountries()
        {
            //return await _context.Books.ToListAsync();
            return await _context.Countries.ToListAsync();
        }

        public List<State> GetStatesByCountry(int countryId)
        {
            return _context.States.Where(s => s.CountryId == countryId).ToList();
        }

        public List<City> GetCitiesByState(int stateId)
        {
            return _context.Cities.Where(c => c.StateId == stateId).ToList();
        }
    }
}
