using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Dal
{
    public class Reservation
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReservedBy { get; set; }
        public string? UserImagepath { get; set; } // Property to store the image path or URL

        public Book? Book { get; set; }

        // إضافة العلاقات
        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public int? StateId { get; set; }
        public State ?State { get; set; }

        public int? CityId { get; set; }
        public City ?City { get; set; }
    }
}
