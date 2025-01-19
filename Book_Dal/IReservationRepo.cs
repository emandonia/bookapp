using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Dal
{
    public interface IReservationRepo
    {
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task AddReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(int id);
        Task<bool> IsBookReservedAsync(int ?bookId, DateTime startDate, DateTime endDate);
        public List<Country> GetCountries();
        public List<State> GetStatesByCountry(int countryId);
        public List<City> GetCitiesByState(int stateId);
    }
}
