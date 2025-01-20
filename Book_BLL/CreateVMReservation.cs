using Book_Dal;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;


namespace Book_BLL
{
    public class CreateVMReservation
    {
        public int? BookId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReservedBy { get; set; }
        public string? UserImagepath { get; set; } // Property to store the image path or URL

        public Book? Book { get; set; }
        public IFormFile? ImageFiles { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }

        public List <SelectListItem> ? Countries { get; set; }
        public List<SelectListItem> ? States { get; set; }
        public List<SelectListItem> ? Cities { get; set; }
    }
}
