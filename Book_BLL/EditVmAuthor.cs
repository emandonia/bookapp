using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_BLL
{
    public class EditVmAuthor
    {
       // public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public IFormFile? ImageFiles { get; set; }
        public string ?CurrentImagePath { get; set; }
    }
}
