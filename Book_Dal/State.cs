using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Dal
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        // Navigation property
        public ICollection<City> Cities { get; set; }
    }
}
