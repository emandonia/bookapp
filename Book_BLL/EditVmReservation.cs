using Book_Dal;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_BLL
{
    public class EditVmReservation
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReservedBy { get; set; }
        public string? UserImagepath { get; set; } // Property to store the image path or URL

        public Book? Book { get; set; }
        public IFormFile? ImageFiles { get; set; }
    }
}
