using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_BLL
{
     public class CreateVmAuthor
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string? ImagePath { get; set; }

        // Optional: you can add a property for file uploads
        public IFormFile? ImageFiles { get; set; }
    }
}
